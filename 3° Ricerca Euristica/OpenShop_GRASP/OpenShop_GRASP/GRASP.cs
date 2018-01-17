using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShop_GRASP
{
    class GRASP
    {
        int nJobs, nMachines;
        int[][] M, d;
        int[] tMacchine;//salvo i tempi della macchina e dei lavori
        int[] tLavori;
        int[][] vettvicini;
        int[] fitnesses;
        int[] bestSol;

        public GRASP(int nJobs, int nMachines)
        {
            this.nJobs = nJobs;
            this.nMachines = nMachines;
        }

        public void setMachineMatrix(int[][] M)
        {
            this.M = M;
        }
        public int[][] getMachineMatrix()
        {
            return this.M;
        }

        public void setCostMatrix(int[][] d)
        {
            this.d = d;
        }
        public int[][] getCostMatrix()
        {
            return this.d;
        }

        public int getBestFit()
        {
            return fitnesses.First(); //piglia il fitness minore dal vettore dei fitness(massimo tempo che ci impiego la soluzione)
        }


        public int[] getBestSol()
        {
            return bestSol;
        }
        public void setBestSol(int[] Msolouzione)
        {
            this.bestSol = Msolouzione;
        }

        public int[] costruct(double valgrd)//crea soluzione iniziale
        {
            List<int> sol_iniziale = new List<int>();
            List<int> candidati = new List<int>();
            int[] sysMalus;
            int sMax, sMin;
            int index;
            Random rand = new Random(DateTime.Now.Millisecond);
            tMacchine = new int[nMachines];//tempi della macchina
            tLavori = new int[nMachines];//tempi del lavoro

            for (int j = 1; j <= (nMachines * nJobs); j++)//copre le operazioni che deve fare ciascun job per ogni macchina
            {
                candidati.Add(j);//array da 1 a nMachines * nJobs
            }

            while (candidati.Count != 0)
            {
                sysMalus = getSystemMalus(candidati.ToArray());
                sMax = sysMalus.Max();//prendo tempo max 
                sMin = sysMalus.Min();//e min dal rispettivo vettore
                //seleziona i canditati con il malus di X, li filtra con i <= di x
                var RCL = candidati.Where(x => getSystemMalus(x) <= (sMin + valgrd * (sMax - sMin))).ToList();//valori filtrati
                index = rand.Next(RCL.Count());
                sol_iniziale.Add(RCL[index]);//in modo casuale
                candidati.Remove(RCL[index]);//per non selezionare la stessa operazione due volte
                updateTime(RCL[index]);
            }
            return sol_iniziale.ToArray();
        }

        public int[] getSystemMalus(int[] vector)//valuta il costo aggiunto al sistema se si schedulano le operazioni(tempi sprecati)
        {
            int lavori, operazioni;
            int OpTime = 0;
            int[] tempi = new int[vector.Length]; //vettore di tempi risultanti per operazione
            for (int i = 0; i < vector.Length; i++)
            {
                //calcolo il lavoro corrispondente al numero di operazione nel vettore
                lavori = (int)Math.Ceiling((vector[i] / (double)nMachines));//arrotonda x eccesso
                //calcolo l'indice dell'operazione relativa al lavoro
                operazioni = vector[i] - ((lavori - 1) * nMachines);
                //trovo il tempo delle macchine e dei lavori schedulando le operazioni in ordine secondo vector
                //la macchina deve aspettare che il lavoro sia pronto
                if (tLavori[lavori - 1] >= tMacchine[(M[operazioni - 1][lavori - 1]) - 1])
                {
                    //se il tempo relativo del lavoro (tempo in cui il lavoro stato impegnato in operazioni) è >
                    //del tempo relativo della macchina (tempo in cui la macchina è stata occupata in operazioni)
                    OpTime = tLavori[lavori - 1] + d[operazioni - 1][lavori - 1];
                    //salva il tempo assoluto dell operazione
                    //la macchina dovrà aspettare che il lavoro sia pronto 
                    //(in quanto le operazioni devono essere eseguite nell'ordine indicato da vector).
                    if (OpTime > tMacchine.Max())
                    {
                        //se la schedulazione dell'operazione selezionata fa sprecare tempo all'intero sistema
                        //inserisco in result il tempo sprecato
                        tempi[i] = OpTime - tMacchine.Max();//vettore dei tempi sprecati
                    }
                    else
                    {
                        //altrimenti l'operazione non incide sul tempo del sistema
                        tempi[i] = 0;
                    }
                }
                else
                {
                    //altrimenti il lavoro dovrà aspettare che la macchina sia libera

                    OpTime = tMacchine[(M[operazioni - 1][lavori - 1]) - 1] + d[operazioni - 1][lavori - 1];
                    if (OpTime > tMacchine.Max()) //come sopra
                    {
                        tempi[i] = OpTime - tMacchine.Max();
                    }
                    else
                    {
                        tempi[i] = 0;
                    }
                }
            }
            return tempi;
        }
        public int getSystemMalus(int nOp)//valuta il costo aggiunto al sistema se si schedulano le operazioni
        {
 
            int job_selected;
            int operation_selected;
            int OpTime = 0;
            int result;//salvo il valore sprecato
                //calcolo il lavoro corrispondente al numero di operazione nel vettore
            job_selected = (int)Math.Ceiling((nOp / (double)nMachines));//arrotonda x eccesso
            //calcolo l'indice dell'operazione relativa al lavoro
            operation_selected = nOp - ((job_selected - 1) * nMachines);
            //trovo il tempo delle macchine e dei lavori schedulando le operazioni in ordine secondo vector
            if (tLavori[job_selected - 1] >= tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1])
            {
                //se il tempo relativo del lavoro (tempo in cui il lavoro stato impegnato in operazioni) è > del tempo relativo della macchina (tempo in cui la macchina è stata occupata in operazioni)
                OpTime = tLavori[job_selected - 1] + d[operation_selected - 1][job_selected - 1];
                //la macchina dovrà aspettare che il lavoro sia pronto (in quanto le operazioni devono essere eseguite nell'ordine indicato da vector).

                if (OpTime > tMacchine.Max())
                {
                    //se la schedulazione dell'operazione selezionata fa sprecare tempo all'intero sistema
                    //inserisco in result il tempo sprecato
                    result = OpTime - tMacchine.Max();
                }
                else
                {
                    //altrimenti l'operazione non incide sul tempo del sistema
                    result = 0;
                }
            }
            else
            {
                //altrimenti il lavoro dovrà aspettare che la macchina sia libera

                OpTime = tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1] + d[operation_selected - 1][job_selected - 1];
                if (OpTime > tMacchine.Max())
                {
                    result = OpTime - tMacchine.Max();
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public void updateTime(int nOp)//gli passo il val di RLC, aggiorno i tempi macchine e lavori
        {   
            int job_selected;
            int operation_selected;
            //calcolo il lavoro corrispondente al numero di operazione nel vettore
            job_selected = (int)Math.Ceiling((nOp / (double)nMachines));//arrotonda x eccesso
            //calcolo l'indice dell'operazione relativa al lavoro
            operation_selected = nOp - ((job_selected - 1) * nMachines);
            //in questo si aggiornano i tempi,caso macchina deve aspettare
            if (tLavori[job_selected - 1] >= tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1])
            {
                //se il tempo relativo del lavoro (tempo in cui il lavoro stato impegnato in operazioni) è > del tempo relativo della macchina (tempo in cui la macchina è stata occupata in operazioni)
                tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1] = tLavori[job_selected - 1] + d[operation_selected - 1][job_selected - 1];
                //la macchina dovrà aspettare che il lavoro sia pronto (in quanto le operazioni devono essere eseguite nell'ordine indicato da vector).
                tLavori[job_selected - 1] += d[operation_selected - 1][job_selected - 1];
                //sarà uguale al tempo del lavoro più il costo dell operazione
            }
            else
            {
                tLavori[job_selected - 1] = tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1] + d[operation_selected - 1][job_selected - 1];
                //altrimenti il lavoro dovrà aspettare che la macchina sia libera
                tMacchine[(M[operation_selected - 1][job_selected - 1]) - 1] += d[operation_selected - 1][job_selected - 1];
                //caso contrario
            }

        }

        public void ricerca(int[] solution)
        {
            List<int[]> res = vicini(solution);//gli passo la sol_iniziale
            res.Add(this.getBestSol());//aggiungo la migliore, utile per confronti
            //trova la soluzione migliore tra i vicini
            vettvicini = res.ToArray();
            solutiontemp(0, vettvicini.Length);//mi valuta il tempo che impiega quello soluzione,restituisce temp max
            this.setBestSol(vettvicini.First());//setto la soluzione migliore

        }

        public List<int[]> vicini(int[] solution)//trova i vicini facendo tutti i possibili switch tra 2 posizioni
        {                                              //nella soluzione
            //trova tutte le possibili soluszioni effettuando uno swap di due
            //elementi della soluzione iniziale
            int temp;
            int[] temp_vett = new int[solution.Length];
            List<int[]> neighbor = new List<int[]>();
            neighbor.Add(solution);
            for (int i = 0; i < solution.Length - 1; i++) //eseguo lo switch dei vicini
            {
                for (int k = i + 1; k < solution.Length; k++)
                {
                    Array.Copy(solution, temp_vett, solution.Length);
                    temp = temp_vett[i];
                    temp_vett[i] = temp_vett[k];
                    temp_vett[k] = temp;

                    neighbor.Add(temp_vett.Clone() as int[]);
                }
            }
            return neighbor;
        }

        public void solutiontemp(int from, int to)//valuta il tempo impiegato per schedulare in ordine la soluzione data
        {  //valuta per ogni soluzione dentro il vettore dei vicini, valuta il tempo macchina e dei lavori
          // restituisce il tempo massimo
            int sellavoro;//utile per ricavare l indice
            int vettoperazioni;
            fitnesses = new int[vettvicini.Length];

            for (int k = from; k < to; k++)
            {
                sellavoro = 0;
                vettoperazioni = 0;
                int[] tMacchine = new int[nMachines];
                int[] tLavori = new int[nMachines];
                for (int i = 0; i < vettvicini[k].Length; i++)
                {
                    //calcolo il lavoro corrispondente al numero di operazione nel vettore
                    sellavoro = (int)Math.Ceiling((vettvicini[k][i] / (double)nMachines));//arrotonda x eccesso
                    //calcolo l'indice dell'operazione relativa al lavoro
                    vettoperazioni = vettvicini[k][i] - ((sellavoro - 1) * nMachines);
                    //trovo il tempo delle macchine e dei lavori schedulando le operazioni in ordine secondo vector
                    if (tLavori[sellavoro - 1] >= tMacchine[(M[vettoperazioni - 1][sellavoro - 1]) - 1])
                    {
                        //se il tempo relativo del lavoro (tempo in cui il lavoro stato impegnato in operazioni) è > del tempo relativo della macchina (tempo in cui la macchina è stata occupata in operazioni)
                        tMacchine[(M[vettoperazioni - 1][sellavoro - 1]) - 1] = tLavori[sellavoro - 1] + d[vettoperazioni - 1][sellavoro - 1];
                        //la macchina dovrà aspettare che il lavoro sia pronto (in quanto le operazioni devono essere eseguite nell'ordine indicato da vector).
                        tLavori[sellavoro - 1] += d[vettoperazioni - 1][sellavoro - 1];
                    }
                    else
                    {
                        tLavori[sellavoro - 1] = tMacchine[(M[vettoperazioni - 1][sellavoro - 1]) - 1] + d[vettoperazioni - 1][sellavoro - 1];
                        //altrimenti il lavoro dovrà aspettare che la macchina sia libera
                        tMacchine[(M[vettoperazioni - 1][sellavoro - 1]) - 1] += d[vettoperazioni - 1][sellavoro - 1];
                    }
                }
                fitnesses[k] = tMacchine.Max();

            }
            Array.Sort(fitnesses, vettvicini); //li ordino( i vicini) a seconda del fitness
        }

    }
}
