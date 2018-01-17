using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenShop_GRASP
{
    public partial class Form1 : Form
    {
        bool fileOk = false, nIterOk = false, greedyOk = false;
        int nJobs, nMachines;
        List<int> costi = new List<int>();
        List<int> macchine = new List<int>();
        List<int> optimumList = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void SelFile_Click(object sender, EventArgs e)
        {
            String Riga;
            String[] param;
            int nRiga = 0;
            int timeSeed, machineSeed, optimum;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);


                    while (!sr.EndOfStream)
                    {
                        Riga = sr.ReadLine();
                        param = Riga.Split(' ').Where(item => item != "").ToArray();
                        if (nRiga == 0)
                        {
                            nJobs = int.Parse(param[0]);//salvo il numero di lavori
                            nMachines = int.Parse(param[1]);//salvo il numero di macchine
                        }
                        else
                        {
                            timeSeed = int.Parse(param[0]); //memorizzo per riga 
                            machineSeed = int.Parse(param[1]);
                            if (param[2].Contains('*'))
                            {
                                optimum = int.Parse(param[2].Substring(0, param[2].IndexOf('*')));
                            }
                            else
                            {
                                if (param[3].Contains('*'))
                                {
                                    optimum = int.Parse(param[3].Substring(0, param[3].IndexOf('*')));
                                }
                                else
                                {
                                    optimum = 0;
                                }
                            }
                            optimumList.Add(optimum);

                            costi.Add(timeSeed); //aggiungo alla lista dei tempi
                            macchine.Add(machineSeed);//aggiungo alla lista delle machine
                        }
                        nRiga++;
                    }
                    textBox1.Text = nJobs.ToString();
                    textBox2.Text = nMachines.ToString();

                    sr.Close();
                    fileOk = true;
                }

                if (fileOk && nIterOk && greedyOk)
                {
                    calc.Enabled = true;
                }
            }
            catch (Exception exept)
            {
                fileOk = false;
                System.Windows.Forms.MessageBox.Show("Errore nel caricamento del file", "Errore", MessageBoxButtons.OK);
            }
        }

        private void NIter_Leave(object sender, EventArgs e)
        {
            int nIter;
            if (NIter.Text != "")
            {
                try
                {
                    nIter = int.Parse(NIter.Text);
                    if (nIter <= 0)
                    {
                        NIter.Select();
                        nIterOk = false;
                        System.Windows.Forms.MessageBox.Show("Inserire un valore intero >0 per il numero di generazioni", "Errore", MessageBoxButtons.OK);
                    }
                    else
                    {
                        nIterOk = true;
                    }


                    if (fileOk && nIterOk && greedyOk)
                    {
                        calc.Enabled = true;
                    }
                    else
                    {
                        calc.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    NIter.Select();
                    nIterOk = false;
                    calc.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("Inserire un valore intero >0 per il numero di generazioni", "Errore", MessageBoxButtons.OK);
                }
            }
        }
        private void NIter_TextChanged(object sender, EventArgs e)
        {
            int nIter;
            try
            {
                nIter = int.Parse(NIter.Text);
                if (nIter <= 0)
                {
                    nIterOk = false;
                }
                else
                {
                    nIterOk = true;
                }


                if (fileOk && nIterOk && greedyOk)
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                nIterOk = false;
                calc.Enabled = false;
            }
        }

        private void Greediness_Leave(object sender, EventArgs e)
        {
            double alfa;
            if (Greediness.Text != "")
            {
                try
                {
                    alfa = double.Parse(Greediness.Text);
                    if (alfa >= 0 && alfa <= 1)
                    {
                        greedyOk = true;
                    }
                    else
                    {
                        Greediness.Select();
                        greedyOk = false;
                        System.Windows.Forms.MessageBox.Show("Il valore del livello di greediness deve essere compreso tra 0 e 1", "Warning", MessageBoxButtons.OK);
                    }

                    if (fileOk && nIterOk && greedyOk)
                    {
                        calc.Enabled = true;
                    }
                    else
                    {
                        calc.Enabled = false;
                    }
                }
                catch (Exception exept)
                {
                    Greediness.Select();
                    calc.Enabled = false;
                    greedyOk = false;
                    System.Windows.Forms.MessageBox.Show("Il valore del livello di greediness deve essere compreso tra 0 e 1", "Warning", MessageBoxButtons.OK);
                }
            }
        }

        private void Greediness_TextChanged(object sender, EventArgs e)
        {
            double alfa;
            try
            {
                alfa = double.Parse(Greediness.Text);
                if (alfa >= 0 && alfa <= 1)
                {
                    greedyOk = true;
                }
                else
                {
                    greedyOk = false;
                }

                if (fileOk && nIterOk && greedyOk)
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
            catch (Exception exept)
            {
                calc.Enabled = false;
                greedyOk = false;
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            resultList.Visible = true;
            double valgrd;//valore greediness
            int[][] MachineMat, CostMat;
            int[] sol_iniziale;
            GenerateOpenShop gen = new GenerateOpenShop(nJobs, nMachines);//passo costi e macchine
            valgrd = double.Parse(Greediness.Text);//salvo il valore della probabilità
            GRASP grasp = new GRASP(nMachines, nJobs);
            resultList.HorizontalScrollbar = true;
            resultList.Items.Clear();
            for (int i = 0; i < costi.Count(); i++)
            {
                gen.generateOpenShop(costi[i], macchine[i]);//genera problema passando macchine e costi
                MachineMat = gen.getMachineMatrix();//setta il valore
                CostMat = gen.getCostMatrix();
                grasp.setCostMatrix(CostMat);//setta i valori
                grasp.setMachineMatrix(MachineMat);
                sol_iniziale = grasp.costruct(valgrd);//passo la probabilità
                grasp.setBestSol(sol_iniziale);//setto con il valore ricavato
                for (int gn = 0; gn < int.Parse(NIter.Text); gn++)//niter da input
                {
                    grasp.ricerca(sol_iniziale);//per i vicini
                    if (grasp.getBestFit() <= optimumList[i])
                    {
                        break;
                    }
                    sol_iniziale = grasp.costruct(valgrd);
                }
                resultList.Items.Add("Istanza " + (i + 1) + "  >  Soluzione: " + stampList(grasp.getBestSol()) + " Fitness = " + grasp.getBestFit());
            }
        }
        //stampa del risultato
        private String stampList(int[] list)
        {
            String result = "[ ";
            for (int i = 0; i < list.Length - 1; i++)
            {
                result += list[i].ToString() + ", ";
            }
            result += list[(list.Length - 1)].ToString() + "]";
            return result;
        }
    }
}
