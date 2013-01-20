using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GA.Core.Chromosome.Permutation;
using GA.Core.Util;
using GA.Core.Population;
using GA.Core.Selection;
using GA.Core.Fitness;
using GA.Core.Stop;

using System.IO;

namespace GAgui
{
    public partial class Form1 : Form
    {
        Double[,] costMatrix;
        UInt32 RozmiarPopulacji;
        PermutationChromosome prototype;
        List<string> operacjieKrzyzowania;
        List<string> strategieMutacji;
        List<string> selekcja;

        private Thread m_thread;        //dodanie watku
        private DefaultPopulation population;
        private NoChangeStopCondion stopCondition;
        public Form1()
        {
            InitializeComponent();
            selekcja = new List<string>();
            selekcja.Add("StochasticUniversalSamplingStrategy");
            selekcja.Add("NoSelectionStrategy");
            selekcja.Add("RouletteWheelSelectionStrategy");
            selekcja.Add("TournamentSelectionStrategy");
            selekcja.Add("EliteSelectionStrategyAdapter");
            this.comboBox_Selekcja.DataSource = selekcja;

            operacjieKrzyzowania = new List<string>();
            operacjieKrzyzowania.Add("CycleCrossOverStrategy");
            operacjieKrzyzowania.Add("OrderCrossOverStrategy");
            operacjieKrzyzowania.Add("PartiallyMappedCrossOverStrategy");
            this.comboBox_krzyzowanie.DataSource = operacjieKrzyzowania;

            strategieMutacji = new List<string>();
            strategieMutacji.Add("InsertMutationStrategy");
            strategieMutacji.Add("SwapMutationStrategy");
            strategieMutacji.Add("InverseMutationStrategy");
            strategieMutacji.Add("ScrambleMutationStrategy");
            this.comboBox_mutacja.DataSource = strategieMutacji;

            this.Text = "Algorytmów genetycznych - na przykładzie problemu komiwojażera";

            Double INF = Double.PositiveInfinity;
            costMatrix = new Double[,]
            {
                { INF,   2.0,    4.0,   22.0,    2.0,    INF},
                { 2.0,   INF,    8.0,   15.0,   13.0,   10.0},
                { 4.0,   8.0,    INF,    5.0,    2.0,    INF},
                {22.0,  15.0,    5.0,    INF,   11.0,   12.0},
                { 2.0,  13.0,    2.0,   11.0,    INF,   14.0},
                { INF,  10.0,    INF,   12.0,   14.0,    INF},
            };

           
            // miasta - odleglosci miedzy miastami
            costMatrix = new Double[,]
            {
                { INF,   304.0,    486.0,   584.0,    341.0}, //Gdansk
                { 304.0,   INF,    280.0,   403.0,   304.0}, //poznan
                { 486.0,   280.0,    INF,    304.0,    341.0}, //wrocla
                { 584.0,  403.0,    304.0,    INF,   299},    //krakow
                { 341.0,  304,    341.0,   299,    INF},    //warszawa
            };
            /*
            costMatrix = new Double[,]
            {
                { INF,   10.0, INF, INF}, 
                { 10.0,   INF, 50.0 , INF}, 
                { INF,   INF, 50.0 , 100.0},
                { INF,   INF, 100.0, INF},
            };*/
            InsetyList(costMatrix);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (costMatrix == null)
            {
                MessageBox.Show("Macierz jest pusta. Uzupełnij graf.");
                return;
            }
            RozmiarPopulacji = UInt32.Parse(textBox_RozmiarPopulacji.Text);
            prototype = new PermutationChromosome(0, costMatrix.GetLength(0) - 1);
            //wybor strategi mutacji
            string MutationStrategy = this.comboBox_mutacja.Text;
            switch (MutationStrategy)
            {
                case "SwapMutationStrategy":
                    prototype.MutationStrategy = new PermutationChromosome.SwapMutationStrategy();
                    break;
                case "InsertMutationStrategy":
                    prototype.MutationStrategy = new PermutationChromosome.InsertMutationStrategy();
                    break;
                case "InverseMutationStrategy":
                    prototype.MutationStrategy = new PermutationChromosome.InverseMutationStrategy();;
                    break;
                case "ScrambleMutationStrategy":
                    prototype.MutationStrategy = new PermutationChromosome.ScrambleMutationStrategy();
                    break;
                default:
                    return;
            }
            // wybor strategi krzyzowania
            string CorssOver = this.comboBox_krzyzowanie.Text;
            switch (CorssOver)
            {
                case "OrderCrossOverStrategy":
                    prototype.CrossOverStrategy = new PermutationChromosome.OrderCrossOverStrategy();
                    break;
                case "PartiallyMappedCrossOverStrategy":
                    prototype.CrossOverStrategy = new PermutationChromosome.PartiallyMappedCrossOverStrategy();
                    break;
                case "CycleCrossOverStrategy":
                    prototype.CrossOverStrategy = new PermutationChromosome.CycleCrossOverStrategy();
                    break;
                default:
                    return;
            }
            prototype.RandomGenerator = new ThreadSafeRandomGenerator();
            prototype.Fitness = new TSPFitness(costMatrix);
            // warunek zatrzymania
            // stop condition, keep reference for selecting the leader
            stopCondition = new NoChangeStopCondion(10);
            // tworzenie populacji - domyslnej.
            population = new DefaultPopulation(prototype, RozmiarPopulacji);
            //wybor seleckji
            string SelectionStrategy = this.comboBox_Selekcja.Text;
            switch (SelectionStrategy)
            {
                case "NoSelectionStrategy":
                    population.SelectionStrategy = new NoSelectionStrategy();
                    break;
                case "RouletteWheelSelectionStrategy":
                    population.SelectionStrategy = new RouletteWheelSelectionStrategy(new FixedSizeStrategy((uint) RozmiarPopulacji), new ThreadSafeRandomGenerator());
                    break;
                case "StochasticUniversalSamplingStrategy":
                    population.SelectionStrategy = new StochasticUniversalSamplingStrategy(new FixedSizeStrategy((uint)RozmiarPopulacji), new ThreadSafeRandomGenerator());
                    break;
                case "TournamentSelectionStrategy":
                    population.SelectionStrategy = new TournamentSelectionStrategy(new FixedSizeStrategy((uint)RozmiarPopulacji), new FixedSizeStrategy((uint)RozmiarPopulacji), new ThreadSafeRandomGenerator()); // sprawwdz to!
                    break;
                case "EliteSelectionStrategyAdapter":
                    population.SelectionStrategy = new EliteSelectionStrategyAdapter(null, new FixedSizeStrategy((uint)RozmiarPopulacji)); // spradz to!!
                    break;
                default:
                    return;
            }
            // set population's parameters
            if (checkBox_show_all_result.Checked)
            {

                while (population.NextGeneration())
                {
                    textBox1.AppendText("Best fitness: " + (1.0 / stopCondition.Leader.Evaluate()));
                    textBox1.AppendText(stopCondition.Leader.ToString());
                }
            }
            else
            {
                if (!checkBox_thread.Checked)
                {
                    population.RandomGenerator = new ThreadSafeRandomGenerator();
                    population.StopCondition = stopCondition;
                    while (population.NextGeneration()) ;
                    textBox1.AppendText("Best fitness:  \t" + (1.0 / stopCondition.Leader.Evaluate()) + "\n");
                    textBox1.AppendText(stopCondition.Leader.ToString() + "\n");
                }
                else
                {
                    try
                    {
                        // uruchomic w watku zadania
                        ThreadStart ts = new ThreadStart(StartAG);
                        m_thread = new Thread(ts);                      // create the worker thread
                        m_thread.Start();                               // go ahead and start the worker thread
                        Thread.Sleep(Int32.Parse(textTime.Text) * 100);
                        m_thread.Abort();
                        m_thread.Join();

                        textBox1.AppendText("Best fitness:  \t" + (1.0 / stopCondition.Leader.Evaluate()) + "\n");
                        textBox1.AppendText(stopCondition.Leader.ToString() + "\n");
                    }
                    catch (Exception ex) // wszystkie niewylapane wczesniej, czyli takie, po ktorych sie nie da kontynuowac
                    {
                        MessageBox.Show("blad z czymstam:" + ex.ToString());
                    }
                }
            }
        }
        private void StartAG()
        {
            population.RandomGenerator = new ThreadSafeRandomGenerator();
            population.StopCondition = stopCondition;
            while (population.NextGeneration()) ;
            //textBox1.AppendText("Best fitness:  \t" + (1.0 / stopCondition.Leader.Evaluate()) + "\n");
            //textBox1.AppendText(stopCondition.Leader.ToString() + "\n");
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            string s1 = textBox_oneList.Text;
            listBox_wezly.Items.Add(s1);
        }
        private void InsetyList(Double[,] dane)
        {
            Double d1;
            string s1 = String.Empty;
            string s2 = String.Empty;
            listBox_wezly.Items.Clear();
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
                listBox_wezly.Items.Add(s1);
                s1 = String.Empty;
            }
        }
        private void SaveToFile(Double[,] dane, string sciezka)
        {
            Double d1;
            string s1 = String.Empty;
            string s2 = String.Empty;
            StreamWriter sw = new StreamWriter(sciezka);

            for (int i = 0; i < dane.GetLength(0); i++)
            {
                for (int j = 0; j < dane.GetLength(1); j++)
                {
                    d1 = dane[i, j];
                    if (d1 == Double.PositiveInfinity)
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
                sw.WriteLine(s1);
                s1 = String.Empty;
            }
            sw.Close();
        }
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
            InsetyList(costMatrix);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox_wezly.SelectedItem != null)
            {
                this.listBox_wezly.Items.Remove(listBox_wezly.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox_wezly.Items.Clear();
            this.costMatrix = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                OpenFileAndCreateMatrix(openFileDialog1.FileName);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //DialogResult result = openFileDialog1.ShowDialog();
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                SaveToFile(costMatrix, saveFileDialog1.FileName);
            }
            
        }
    }
}