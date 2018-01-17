using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//codice relativo al pdf che spiega come generare il problema
namespace OpenShop_GA
{
    class GenerateOpenShop
    {
        const int m = int.MaxValue;
        const int a = 16807;
        const int b = 127773;
        const int c = 2836;
        int[][] M;
        int[][] d;
        int seed, nJobs, nMachines;

        public GenerateOpenShop(int nJobs, int nMachines)
        {
            this.nJobs = nJobs;
            this.nMachines = nMachines;
            int[][] Mac = new int[nJobs][];
            int[][] cos = new int[nJobs][];
            for (int i = 0; i < nJobs; i++)
            {
                Mac[i] = new int[nMachines];
                cos[i] = new int[nMachines];
            }
            M = Mac;
            d = cos;
        }

        private int unif(int low, int high)
        {//Genera un valore casuale tra low e high
            int k = seed / b;
            double val;

            seed = a * (seed % b) - (k * c);
            if (seed < 0)
                seed += m;
            val = (seed / (double)m);
            int ret = (low + (int)(val * (high - low + 1)));
            return ret;
        }

        public void generateOpenShop(int timeSeed, int machineSeed)
        {//Genera le matrici d[i,j] che indica il tempo richiesto pel l'operazione i-esima nel lavoro j-esimo
            //e M[i,j] che indica la macchina che dovrà eseguire l'operazione i-esima per il lavoro j-esimo
            int i, j;
            seed = timeSeed;
            for (j = 0; j < nJobs; j++)
                for (i = 0; i < nMachines; i++)
                {
                    d[i] [j] = unif(1, 99);
                    M[i] [j] = (i + 1);
                }
            seed = machineSeed;
            for (j = 0; j < nJobs; j++)
                for (i = 0; i < nMachines; i++)
                {
                    int temp = M[i] [j];
                    int ii = unif(i, nMachines - 1);
                    M[i] [j] = M[ii] [j];
                    M[ii] [j] = temp;
                }
        }
        public int[][] getMachineMatrix()
        {
            return M;
        }
        public int[][] getCostMatrix()
        {
            return d;
        }
    }
}
