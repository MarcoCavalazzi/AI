using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenShop_GA
{
    public partial class Form1 : Form
    {
        bool fileOk = false, popOk = false, estrOk = false, nIterOk = false, mutProbOk = false;
        int nJobs, nMachines;
        List<int> Ltempi = new List<int>();
        List<int> Lmacchine = new List<int>();
        List<int> Lottimi = new List<int>();

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
                            Lottimi.Add(optimum);

                            Ltempi.Add(timeSeed); //aggiungo alla lista dei tempi
                            Lmacchine.Add(machineSeed);//aggiungo alla lista delle machine
                        }
                        nRiga++;
                    }
                    textBox1.Text = nJobs.ToString();
                    textBox2.Text = nMachines.ToString();

                    sr.Close();
                    fileOk = true;
                }

                if (fileOk && mutProbOk && popOk && nIterOk && estrOk)//se tutto è inserito correttamente posso calcolare
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


                    if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
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
                    System.Windows.Forms.MessageBox.Show("il valore delle generazioni deve essere maggiore di zero", "Warning", MessageBoxButtons.OK);
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


                if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
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

        private void DimPop_Leave(object sender, EventArgs e)
        {
            int dimPop;
            if (DimPop.Text != "")
            {
                try
                {
                    dimPop = int.Parse(DimPop.Text);
                    if (dimPop <= 0)
                    {
                        DimPop.Select();
                        popOk = false;
                        System.Windows.Forms.MessageBox.Show("Il valore della popolazione deve essere maggiore di zero", "Warning", MessageBoxButtons.OK);
                    }
                    else
                    {
                        popOk = true;
                    }

                    if (nCrossover.Text != "")
                    {
                        if (int.Parse(nCrossover.Text) > (dimPop - 1))
                        {
                            DimPop.Select();
                            popOk = false;
                            System.Windows.Forms.MessageBox.Show("Il numero di figli deve essere minore della dimensione della popolazione", "Warning", MessageBoxButtons.OK);
                        }
                    }

                    if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
                    {
                        calc.Enabled = true;
                    }
                    else
                    {
                        calc.Enabled = false;
                    }
                }
                catch (Exception exep)
                {
                    DimPop.Select();
                    popOk = false;
                    calc.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("Inserire un valore intero >0 per la dimensione della popolazione", "Errore", MessageBoxButtons.OK);
                }
            }
        }
        private void DimPop_TextChanged(object sender, EventArgs e)
        {
            int dimPop;
            try
            {
                dimPop = int.Parse(DimPop.Text);
                if (dimPop <= 0)
                {
                    popOk = false;
                }
                else
                {
                    popOk = true;
                }

                if (nCrossover.Text != "")
                {
                    if (int.Parse(nCrossover.Text) > (dimPop - 1))
                    {
                        popOk = false;
                    }
                }

                if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
            catch (Exception exep)
            {
                popOk = false;
                calc.Enabled = false;
            }
        }

        private void nCrossover_Leave(object sender, EventArgs e)
        {
            int nCross;
            if (nCrossover.Text != "")
            {
                try
                {
                    nCross = int.Parse(nCrossover.Text);

                    if ((nCross <= 0)||(nCross%2!=0))
                    {
                        nCrossover.Select();
                        estrOk = false;
                        System.Windows.Forms.MessageBox.Show("Inserire un valore pari maggiore di zero per il numero di figli per generazione", "Errore", MessageBoxButtons.OK);
                    }
                    else
                    {
                        estrOk = true;
                    }

                    if (DimPop.Text != "")
                    {
                        if (nCross > (int.Parse(DimPop.Text) - 1))
                        {
                            nCrossover.Select();
                            estrOk = false;
                            System.Windows.Forms.MessageBox.Show("Il numero di figli deve essere < della dimensione della popolazione", "Errore", MessageBoxButtons.OK);
                        }
                    }

                    if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
                    {
                        calc.Enabled = true;
                    }
                    else
                    {
                        calc.Enabled = false;
                    }
                }
                catch (Exception exe)
                {
                    nCrossover.Select();
                    estrOk = false;
                    calc.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("Il valore della popolazione deve essere intero", "Warning", MessageBoxButtons.OK);
                }
            }
        }
        private void nCrossover_TextChanged(object sender, EventArgs e)
        {
            int nCross;
            try
            {
                nCross = int.Parse(nCrossover.Text);

                if ((nCross <= 0)||(nCross%2!=0))
                {
                    estrOk = false;
                }
                else
                {
                    estrOk = true;
                }

                if (DimPop.Text != "")
                {
                    if (nCross > (int.Parse(DimPop.Text) - 1))
                    {
                        estrOk = false;
                    }
                }

                if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
            catch (Exception exe)
            {
                estrOk = false;
                calc.Enabled = false;
            }
        }

        private void MutProb_Leave(object sender, EventArgs e)
        {
            double val;
            if (MutProb.Text != "")
            {
                try
                {
                    val = double.Parse(MutProb.Text);
                    if (val >= 0 && val <= 1)
                    {
                        mutProbOk = true;
                    }
                    else
                    {
                        MutProb.Select();
                        mutProbOk = false;
                        System.Windows.Forms.MessageBox.Show("Il valore della probabilità deve essere compreso tra 0 e 1", "Warning", MessageBoxButtons.OK);
                    }

                    if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
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
                    MutProb.Select();
                    calc.Enabled = false;
                    mutProbOk = false;
                    System.Windows.Forms.MessageBox.Show("Il valore della probabilità deve essere compreso tra 0 e 1", "Warning", MessageBoxButtons.OK);
                }
            }
        }
        private void MutProb_TextChanged(object sender, EventArgs e)
        {
            double val;
            try
            {
                val = double.Parse(MutProb.Text);
                if (val >= 0 && val <= 1)
                {
                    mutProbOk = true;
                }
                else
                {
                    mutProbOk = false;
                }

                if (fileOk && mutProbOk && popOk && nIterOk && estrOk)
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
                mutProbOk = false;
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            resultList.Visible = true;
            int figli;
            double mutationProb;
            int[][] MachineMat, CostMat;
            GenerateOpenShop gen = new GenerateOpenShop(nJobs, nMachines);//passo il valore del costo e il numero delle macchine
            figli = int.Parse(nCrossover.Text);//salvo i figli dati in input
            mutationProb = double.Parse(MutProb.Text);//salvo la probabilità
            GeneticAlgorithm ga = new GeneticAlgorithm(nMachines, nJobs, figli, mutationProb);
            resultList.HorizontalScrollbar = true;
            resultList.Items.Clear();
            for (int i = 0; i < Ltempi.Count(); i++)
            {
                gen.generateOpenShop(Ltempi[i], Lmacchine[i]);//genera il problema
                MachineMat = gen.getMachineMatrix(); //ottiene dalla generazione del problema
                CostMat = gen.getCostMatrix(); //ottiene dalla generazione del problema
                ga.setCostMatrix(CostMat);//setto i valori
                ga.setMachineMatrix(MachineMat);
                ga.generaPopolazione(int.Parse(DimPop.Text));//genera popolazione
                ga.tempvalue(0, int.Parse(DimPop.Text));//tempo valutato in funzione della dimensione popolazione
                for (int iter = 0; iter < int.Parse(NIter.Text); iter++)
                {      //Bestfi restituisce il primo valore 
                    if (ga.getBestFit() <= Lottimi[i])//lista degli ottimi(presi da file di testo, quelli *)
                    {
                        break; //esce dal ciclo
                    }
                    ga.proxgenerazione();

                }
                resultList.Items.Add("Istanza " + (i + 1) + "  >  Soluzione: " + stampList(ga.getCurrentBest()) + " Fitness = " + ga.getBestFit());
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
