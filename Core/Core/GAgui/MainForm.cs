using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

using GA.Core.Chromosome;
using GA.Core.Chromosome.Permutation;
using GA.Core.Util;
using GA.Core.Population;
using GA.Core.Selection;
using GA.Core.Fitness;
using GA.Core.Stop;

using System.IO;

namespace GAgui
{
    public partial class MainForm : Form
    {
        Double[,] costMatrix;
        List<Object> crossoverStategies;
        List<Object> mutationStategies;
        List<String> selectionStrategies;

        private BackgroundWorker worker;
        private DefaultPopulation population;
        private NoChangeStopCondion stopCondition;

        DateTime TimeStart;
        DateTime TimeStop;

        public MainForm()
        {
            InitializeComponent();
            {
                selectionStrategies = new List<String>();
                selectionStrategies.Add("StochasticUniversalSamplingStrategy");
                selectionStrategies.Add("RouletteWheelSelectionStrategy");
                selectionStrategies.Add("TournamentSelectionStrategy");
                selectionStrategies.Add("NoSelectionStrategy");
                this.selectionComboBox.DataSource = selectionStrategies;
            }
            {
                crossoverStategies = new List<Object>();
                var type = typeof(PermutationChromosome.ICrossOverStrategy);
                var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && !type.IsEquivalentTo(p));

                foreach (var t in types)
                {
                    PermutationChromosome.ICrossOverStrategy crossoverStrategy 
                        = (PermutationChromosome.ICrossOverStrategy)t.GetConstructor(Type.EmptyTypes).Invoke(null);
                    crossoverStategies.Add(crossoverStrategy);
                }
                this.crossoverComboBox.DataSource = crossoverStategies;
            }
            {
                mutationStategies = new List<Object>();
                var type = typeof(PermutationChromosome.IMutationStrategy);
                var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && !type.IsEquivalentTo(p));

                foreach (var t in types)
                {
                    PermutationChromosome.IMutationStrategy mutationStrategy 
                        = (PermutationChromosome.IMutationStrategy)t.GetConstructor(Type.EmptyTypes).Invoke(null);
                    mutationStategies.Add(mutationStrategy);
                }
                this.mutationComboBox.DataSource = mutationStategies;
            }

            this.Text = "Algorytmów genetycznych na przykładzie problemu komiwojażera";

            Double INF = Double.PositiveInfinity;

            // Miasta - odleglości miedzy miastami.
            costMatrix = new Double[,]
            {
                { INF,    304.0,  486.0,  584.0,  341.0},   //Gdansk
                { 304.0,  INF,    280.0,  403.0,  304.0},    //poznan
                { 486.0,  280.0,  INF,    304.0,  341.0},  //wrocla
                { 584.0,  403.0,  304.0,  INF,    299},      //krakow
                { 341.0,  304,    341.0,  299,    INF},        //warszawa
            };

            InsertData(costMatrix);

            /*
             * Utwórz background workera dla asynchronicznego przetwarzania.
             */
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler((Object sender, DoWorkEventArgs args) =>
                {
                    worker.ReportProgress(0);
                    while (population.NextGeneration() && !worker.CancellationPending)
                    {
                        if (population.Generation % 1000 == 0)
                        {
                            worker.ReportProgress((Int32)population.Generation);
                        }
                    }
                    worker.ReportProgress((Int32)population.Generation);
                });
            worker.ProgressChanged += new ProgressChangedEventHandler((Object sender, ProgressChangedEventArgs args) =>
                {
                    progressLabel.Text = "Iteracja: " + args.ProgressPercentage;

                    if (showAllCheckbox.Checked && stopCondition.Leader != null)
                    {
                        textBox1.AppendText("Najlepsze dopasowanie: " + (1.0 / stopCondition.Leader.Evaluate()) + Environment.NewLine);
                        textBox1.AppendText(stopCondition.Leader.ToString() + Environment.NewLine);
                    }
                });
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((Object sender, RunWorkerCompletedEventArgs args) =>
                {
                    textBox1.AppendText("Najlepsze dopasowanie: " + (1.0 / stopCondition.Leader.Evaluate()) + Environment.NewLine);
                    textBox1.AppendText(stopCondition.Leader.ToString() + Environment.NewLine);
                    startProcessingButton.Text = "Start";
                    TimeStop = DateTime.Now;
                    TimeSpan roznica = TimeStop - TimeStart;
                    textBox1.AppendText("Czas pracy: " + roznica.TotalMilliseconds + "ms" + Environment.NewLine);
                    textBox1.AppendText("====================" + Environment.NewLine);
                });
        }

        private void startProcessingButton_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                return;
            }
            if (costMatrix == null)
            {
                MessageBox.Show("Macierz jest pusta. Uzupełnij graf.");
                return;
            }
            /*
             * Prototyp chromosomu.
             */
            PermutationChromosome chromosomePrototype = new PermutationChromosome(0, costMatrix.GetLength(0) - 1);
            chromosomePrototype.MutationStrategy = (PermutationChromosome.IMutationStrategy)mutationComboBox.SelectedItem;
            chromosomePrototype.CrossOverStrategy = (PermutationChromosome.ICrossOverStrategy)crossoverComboBox.SelectedItem;
            /*
             * Inne parametry.
             */
            chromosomePrototype.RandomGenerator = new ThreadSafeRandomGenerator();
            /*
             * Funkcja oceny dopasowania.
             */
            chromosomePrototype.Fitness = new TSPFitness(costMatrix);
            /*
             * Warunek stopu. Zachować referencję dla wskazania lidera.
             */
            stopCondition = new NoChangeStopCondion((UInt32)stopSpinner.Value);
            /*
             * Rozmiar populacji
             */
            UInt32 populationSize = (UInt32)populationSpinner.Value;
            /*
             * Populacja.
             */
            population = new DefaultPopulation(chromosomePrototype, populationSize);
            population.RandomGenerator = new ThreadSafeRandomGenerator();
            population.StopCondition = stopCondition;
            /*
             * Strategia selekcji.
             */
            string SelectionStrategy = this.selectionComboBox.Text;
            switch (SelectionStrategy)
            {
                case "NoSelectionStrategy":
                    population.SelectionStrategy = new NoSelectionStrategy();
                    break;
                case "RouletteWheelSelectionStrategy":
                    population.SelectionStrategy = new RouletteWheelSelectionStrategy(new FixedSizeStrategy(populationSize), new ThreadSafeRandomGenerator());
                    break;
                case "StochasticUniversalSamplingStrategy":
                    population.SelectionStrategy = new StochasticUniversalSamplingStrategy(new FixedSizeStrategy(populationSize), new ThreadSafeRandomGenerator());
                    break;
                case "TournamentSelectionStrategy":
                    population.SelectionStrategy = new TournamentSelectionStrategy(new FixedSizeStrategy(populationSize), new ThreadSafeRandomGenerator());
                    break;
                default:
                    return;
            }
            if (eliteSpinner.Value > 0)
            {
                population.SelectionStrategy = new EliteSelectionStrategyAdapter(population.SelectionStrategy, new FixedSizeStrategy((UInt32)eliteSpinner.Value));
            }
            if (survivorSpinner.Value > 0)
            {
                population.SelectionStrategy = new SurvivorSelectionStrategyAdapter(population.SelectionStrategy, new FixedSizeStrategy((UInt32)eliteSpinner.Value));
            }
            /*
             * Rozpocznij przetwarzanie.
             */
            startProcessingButton.Text = "Stop";
            TimeStart = DateTime.Now;
            worker.RunWorkerAsync(stopCondition);
        }
        /// <summary>
        /// Wstawia dane do kontrolki je wyświetlającej.
        /// </summary>
        private void InsertData(Double[,] dane)
        {
            Double d1;
            string s1 = String.Empty;
            string s2 = String.Empty;
            dataListBox.Items.Clear();
            for (int i = 0; i < dane.GetLength(0) ; i++)
            {
                for (int j = 0; j < dane.GetLength(1); j++)
                {
                    d1 = dane[i, j];
                    if(d1==Double.PositiveInfinity)
                        s2 = "INF";
                    else
                        s2 = d1.ToString();

                    if (String.IsNullOrEmpty(s1))
                    {
                        s1 = s1 + s2;
                    }
                    else
                    {
                        s1 = s1 + "; " + s2;
                    }
                }
                dataListBox.Items.Add(s1);
                s1 = String.Empty;
            }
        }
        /// <summary>
        /// Wczytuje macierz danych z pliku.
        /// </summary>
        private void OpenFileAndCreateMatrix(string sciezka)
        {
            Double d1;
            string s1 = String.Empty;
            string s2 = String.Empty;
            Double INF = Double.PositiveInfinity;
            Double[,] Matrix = null;
            int j = 0;
            int i = 0;
            int MaxMatrix = 0;
            try
            {
                using (StreamReader sr = new StreamReader(sciezka))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        s1 = line;
                        string[] sx = s1.Split(';');
                        if(Matrix==null)
                        {
                            Matrix = new Double[sx.Length,sx.Length];
                            MaxMatrix = sx.Length;
                        }
                        for (int k = 0; k < MaxMatrix; k++)
                        {
                            s2 = sx[k];
                            s2 = s2.Trim();
                            if(s2.Equals("INF"))
                            {
                                Matrix[i,k] = INF;
                            }else
                            {
                                Matrix[i, k] = Convert.ToDouble(s2);
                            }
                        }
                        i++;
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            costMatrix = null;
            costMatrix = Matrix;
            InsertData(costMatrix);
        }
        /// <summary>
        /// Tworzy okno dialogowe dla wczytania danych z pliku.
        /// </summary>
        private void loadDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                OpenFileAndCreateMatrix(openFileDialog.FileName);
            }
        }
    }
}