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

namespace GA.GUI
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

        enum ModifierCombination { SurvivorElite, EliteSurvivor, Elite, Survivor, None };
        Dictionary<String, ModifierCombination> ModifierCombinationDict = new Dictionary<String, ModifierCombination> {
            { "Brak modyfikatora", ModifierCombination.None },
            { "Elite", ModifierCombination.Elite },
            { "Survivor", ModifierCombination.Survivor },
            { "Survivor przed Elite", ModifierCombination.SurvivorElite },
            { "Elite przed Survivor", ModifierCombination.EliteSurvivor },
        };

        enum SelectionStrategies { NoSelectionStrategy, RouletteWheelSelectionStrategy, StochasticUniversalSamplingStrategy, TournamentSelectionStrategy };
        Dictionary<String, SelectionStrategies> SelectionStrategiesDict = new Dictionary<String, SelectionStrategies> {
            { "Bran selekcji", SelectionStrategies.NoSelectionStrategy },
            { "Selekcja koła ruletki", SelectionStrategies.RouletteWheelSelectionStrategy },
            { "Selekcja SUS", SelectionStrategies.StochasticUniversalSamplingStrategy },
            { "Selekcja turniejowa", SelectionStrategies.TournamentSelectionStrategy },
        };

        public MainForm()
        {
            InitializeComponent();

            selecitonModifierComboBox.DisplayMember = "Key";
            selecitonModifierComboBox.ValueMember = "Value";
            selecitonModifierComboBox.DataSource = new BindingSource(ModifierCombinationDict, null);

            selectionAlgorithmComboBox.DisplayMember = "Key";
            selectionAlgorithmComboBox.ValueMember = "Value";
            selectionAlgorithmComboBox.DataSource = new BindingSource(SelectionStrategiesDict, null);


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
                this.crossoverAlgorithmComboBox.DataSource = crossoverStategies;
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
                this.mutationAlgorithmComboBox.DataSource = mutationStategies;
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
            chromosomePrototype.MutationStrategy = (PermutationChromosome.IMutationStrategy)mutationAlgorithmComboBox.SelectedItem;
            chromosomePrototype.CrossOverStrategy = (PermutationChromosome.ICrossOverStrategy)crossoverAlgorithmComboBox.SelectedItem;
            chromosomePrototype.RandomGenerator = new ThreadSafeRandomGenerator();
            chromosomePrototype.Fitness = new TSPFitness(costMatrix);

            /*
             * Populacja
             */
            population = new DefaultPopulation(chromosomePrototype, (UInt32)populationSpinner.Value);
            population.RandomGenerator = new ThreadSafeRandomGenerator();
            population.StopCondition = stopCondition;
            
            /*
             * Selekcja
             */
            ISelectionSizeStrategy selectionSizeStrategy = selectionSizeCheckBox.Checked ? (ISelectionSizeStrategy)new ProportionalSizeStrategy((Double)selectionSizeSpinner.Value) : (ISelectionSizeStrategy)new FixedSizeStrategy((UInt32)selectionSizeSpinner.Value);
            switch ((SelectionStrategies)selectionAlgorithmComboBox.SelectedValue)
            {
                case SelectionStrategies.NoSelectionStrategy:
                    population.SelectionStrategy = new NoSelectionStrategy();
                    break;
                case SelectionStrategies.RouletteWheelSelectionStrategy:
                    population.SelectionStrategy = new RouletteWheelSelectionStrategy(selectionSizeStrategy, new ThreadSafeRandomGenerator());
                    break;
                case SelectionStrategies.StochasticUniversalSamplingStrategy:
                    population.SelectionStrategy = new StochasticUniversalSamplingStrategy(selectionSizeStrategy, new ThreadSafeRandomGenerator());
                    break;
                case SelectionStrategies.TournamentSelectionStrategy:
                    ISelectionSizeStrategy tournamentGroupSizeStrategy = tournamentGroupSizeCheckBox.Checked ? (ISelectionSizeStrategy)new ProportionalSizeStrategy((Double)tournamentGroupSizeSpinner.Value) : (ISelectionSizeStrategy)new FixedSizeStrategy((UInt32)tournamentGroupSizeSpinner.Value);
                    population.SelectionStrategy = new TournamentSelectionStrategy(selectionSizeStrategy, tournamentGroupSizeStrategy, new ThreadSafeRandomGenerator());
                    break;
                default:
                    return;
            }

            ISelectionSizeStrategy eliteSizeStrategy = eliteSizeCheckBox.Checked ? (ISelectionSizeStrategy)new ProportionalSizeStrategy((Double)eliteSizeSpinner.Value) : (ISelectionSizeStrategy)new FixedSizeStrategy((UInt32)eliteSizeSpinner.Value);
            ISelectionSizeStrategy survivorSizeStrategy = eliteSizeCheckBox.Checked ? (ISelectionSizeStrategy)new ProportionalSizeStrategy((Double)survivorSizeSpinner.Value) : (ISelectionSizeStrategy)new FixedSizeStrategy((UInt32)survivorSizeSpinner.Value);
            switch ((ModifierCombination)selecitonModifierComboBox.SelectedValue)
            {
                case ModifierCombination.None:
                    break;
                case ModifierCombination.Elite:
                    population.SelectionStrategy = new EliteSelectionStrategyAdapter(population.SelectionStrategy, eliteSizeStrategy);
                    break;
                case ModifierCombination.Survivor:
                    population.SelectionStrategy = new SurvivorSelectionStrategyAdapter(population.SelectionStrategy, survivorSizeStrategy);
                    break;
                case ModifierCombination.EliteSurvivor:
                    population.SelectionStrategy = new EliteSelectionStrategyAdapter(population.SelectionStrategy, eliteSizeStrategy);
                    population.SelectionStrategy = new SurvivorSelectionStrategyAdapter(population.SelectionStrategy, survivorSizeStrategy);
                    break;
                case ModifierCombination.SurvivorElite:
                    population.SelectionStrategy = new SurvivorSelectionStrategyAdapter(population.SelectionStrategy, survivorSizeStrategy);
                    population.SelectionStrategy = new EliteSelectionStrategyAdapter(population.SelectionStrategy, eliteSizeStrategy);
                    break;
            }

            /*
             * Warunek stopu. Zachować referencję dla wskazania lidera.
             */
            stopCondition = new NoChangeStopCondion((UInt32)stopSpinner.Value);
            population.StopCondition = stopCondition;

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
            StringBuilder builder = new StringBuilder();
            dataListBox.Items.Clear();
            for (Int32 i = 0; i < dane.GetLength(0); i++)
            {
                for (Int32 j = 0; j < dane.GetLength(1); j++)
                {
                    Double d = dane[i, j];
                    if (Double.IsInfinity(d))
                        builder.Append("INF");
                    else
                        builder.Append(d);

                    builder.Append('\t');
                }
                dataListBox.Items.Add(builder.ToString());
                builder.Clear();
            }
        }
        /// <summary>
        /// Wczytuje macierz danych z pliku.
        /// </summary>
        private Double[,] LoadFile(String sciezka)
        {
            Double[,] matrix = new Double[,] {{0}};
            using (StreamReader stream = new StreamReader(sciezka))
            {
                Int32 i = 0;
                String line;
                while ((line = stream.ReadLine()) != null)
                {
                    String[] tokens = line.Split(new char[] {';', ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                    if (matrix.Length == 1)
                    {
                        matrix = new Double[tokens.Length, tokens.Length];
                    }
                    for (Int32 k = 0; k < matrix.GetLength(0); k++)
                    {
                        String token = tokens[k].Trim();
                        if (token.Equals("INF"))
                        {
                            matrix[i, k] = Double.PositiveInfinity;
                        }
                        else
                        {
                            matrix[i, k] = Convert.ToDouble(token);
                        }
                    }
                    i++;
                }
            }
            return matrix;
        }
        /// <summary>
        /// Zapisuje macierz danych z pliku.
        /// </summary>
        private void SaveFile(String sciezka, Double[,] matrix)
        {
            using (StreamWriter stream = new StreamWriter(sciezka))
            {
                for (Int32 i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (Int32 j = 0; j < matrix.GetLength(1); ++j)
                    {
                        stream.Write(Double.IsInfinity(matrix[i, j]) ? "INF" : matrix[i, j].ToString());
                        stream.Write("; ");
                    }
                    stream.WriteLine();
                }
            }
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
                try
                {
                    costMatrix = LoadFile(openFileDialog.FileName);
                    InsertData(costMatrix);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można wczytać pliku z danymi: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Tworzy okno dialogowe dla zapisania danych do pliku.
        /// </summary>
        private void saveDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    SaveFile(saveFileDialog.FileName, costMatrix);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można zapisać pliku z danymi: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Metoda pomocnicza, która modyfikuje format wprowadzanych wartości liczbowych zależnie od wybranej opcji.
        /// </summary>
        private void eliteSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Decimal value = eliteSizeSpinner.Value;
            if (eliteSizeCheckBox.Checked)
            {
                eliteSizeSpinner.Maximum = 1.0M;
                eliteSizeSpinner.DecimalPlaces = 4;
                eliteSizeSpinner.Value = value / 1000;
            }
            else
            {
                eliteSizeSpinner.Maximum = 1000;
                eliteSizeSpinner.DecimalPlaces = 0;
                eliteSizeSpinner.Value = value * 1000;
            }
        }
        /// <summary>
        /// Metoda pomocnicza, która modyfikuje format wprowadzanych wartości liczbowych zależnie od wybranej opcji.
        /// </summary>
        private void survivorSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Decimal value = eliteSizeSpinner.Value;
            if (survivorSizeCheckBox.Checked)
            {
                survivorSizeSpinner.Maximum = 1.0M;
                survivorSizeSpinner.DecimalPlaces = 4;
                survivorSizeSpinner.Value = value / 1000;
            }
            else
            {
                survivorSizeSpinner.Maximum = 1000;
                survivorSizeSpinner.DecimalPlaces = 0;
                survivorSizeSpinner.Value = value * 1000;
            }
        }
        /// <summary>
        /// Metoda pomocnicza, która modyfikuje format wprowadzanych wartości liczbowych zależnie od wybranej opcji.
        /// </summary>
        private void selectionSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Decimal value = selectionSizeSpinner.Value;
            if (selectionSizeCheckBox.Checked)
            {
                selectionSizeSpinner.Maximum = 1.0M;
                selectionSizeSpinner.DecimalPlaces = 4;
                selectionSizeSpinner.Value = value / 1000;
            }
            else
            {
                selectionSizeSpinner.Maximum = 1000;
                selectionSizeSpinner.DecimalPlaces = 0;
                selectionSizeSpinner.Value = value * 1000;
            }
        }
        /// <summary>
        /// Metoda pomocnicza, która modyfikuje format wprowadzanych wartości liczbowych zależnie od wybranej opcji.
        /// </summary>
        private void tournamentGroupSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Decimal value = tournamentGroupSizeSpinner.Value;
            if (tournamentGroupSizeCheckBox.Checked)
            {
                tournamentGroupSizeSpinner.Maximum = 1.0M;
                tournamentGroupSizeSpinner.DecimalPlaces = 4;
                tournamentGroupSizeSpinner.Value = value / 1000;
            }
            else
            {
                tournamentGroupSizeSpinner.Maximum = 1000;
                tournamentGroupSizeSpinner.DecimalPlaces = 0;
                tournamentGroupSizeSpinner.Value = value * 1000;
            }
        }
        /// <summary>
        /// Metoda pomocnicza, która ukrywa/pokazuje opcje dla selekcji turniejowe, zależnie od wybranej metody selekcji..
        /// </summary>
        private void selectionAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionStrategies strategy = (SelectionStrategies)selectionAlgorithmComboBox.SelectedValue;
            if (strategy == SelectionStrategies.TournamentSelectionStrategy)
            {
                selectionTournamentGroupBox.Visible = true;
            }
            else
            {
                selectionTournamentGroupBox.Visible = false;
            }
        }
    }
}