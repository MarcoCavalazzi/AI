using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShop_GA
{
    class GeneticAlgorithm
    {
        private int[][] popolazione;
        int[] fitnesses;
        int Lavori, Macchine, figli;
        Random rand;
        int[][] M;
        int[][] d;
        double Pmutazione;

        public GeneticAlgorithm(int nMachines, int nJobs, int figli, double mutationProb)
        {
            rand = new Random();
            this.Macchine = nMachines;
            this.Lavori = nJobs;
            this.figli = figli;
            this.Pmutazione = mutationProb;
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

        public void getPopolazione(int[][] popolazione)
        {
            this.popolazione = popolazione;
        }
        public int[][] getPopolazione()
        {
            return popolazione;
        }

        public int[] getCurrentBest()
        {
            return popolazione.First();//restituisce primo elemento
        }
        public int getBestFit()
        {
            return fitnesses.First();//restituisce primo elemento
        }

        public void generaPopolazione(int size)//passto il valore della dimensione
        {
            //Genera la popolazione iniziale su cui applicare l'algoritmo
            this.popolazione = new int[size][];
            fitnesses = new int[size];
            int[] vet;
            List<int> numeri = new List<int>();

            for (int i = 0; i < size; i++)
            {
                vet = new int[Macchine * Lavori];
                numeri.Clear();
                int j;
                //Ogni operazione di un job ha un numero univoco
                for (j = 1; j <= (Macchine * Lavori); j++)//copre le operazioni che deve fare ciascun job per ogni macchina
                    numeri.Add(j);//array da 1 a Macchine * Lavori
                for (j = 0; j < (Macchine * Lavori); j++)//riempe l array vet
                {
                    vet[j] = numeri[rand.Next(numeri.Count())];//in modo casuale
                    numeri.Remove(vet[j]);//per evitare di ricopiare 2 volte lo stesso valore rimuove
                }
                popolazione[i] = vet;//aggiorno l array popolazione
            }
        }
        public void tempvalue(int val, int dimpopo)//valuta il tempo impiegato per schedulare in ordine la soluzione data,passato il valore della popolazione
        {
            int lavoro, operazione;

            for (int k = val; k < dimpopo; k++)
            {
                lavoro = 0;
                operazione = 0;
                int[] tmacchine = new int[Macchine];
                int[] tlavori = new int[Macchine];
                for (int i = 0; i < popolazione[k].Length; i++)
                {
                    //calcolo il lavoro corrispondente al numero di operazione nel vettore
                    lavoro = (int)Math.Ceiling((popolazione[k][i] / (double)Macchine));//arrotonda x eccesso
                    //calcolo l'indice dell'operazione relativa al lavoro
                    operazione = popolazione[k][i] - ((lavoro - 1) * Macchine);
                    //trovo il tempo delle macchine e dei lavori schedulando le operazioni in ordine 
                    if (tlavori[lavoro - 1] >= tmacchine[(M[operazione - 1][lavoro - 1]) - 1])
                    {
                        //se il tempo relativo del lavoro (tempo in cui il lavoro stato impegnato in operazioni) è > del tempo relativo della macchina (tempo in cui la macchina è stata occupata in operazioni)
                        tmacchine[(M[operazione - 1][lavoro - 1]) - 1] = tlavori[lavoro - 1] + d[operazione - 1][lavoro - 1];//dove d è il vettore dei costi
                        //la macchina dovrà aspettare che il lavoro sia pronto (in quanto le operazioni devono essere eseguite nell'ordine indicato da vector).
                        tlavori[lavoro - 1] += d[operazione - 1][lavoro - 1];
                    }
                    else
                    {
                        tlavori[lavoro - 1] = tmacchine[(M[operazione - 1][lavoro - 1]) - 1] + d[operazione - 1][lavoro - 1];
                        //altrimenti il lavoro dovrà aspettare che la macchina sia libera
                        tmacchine[(M[operazione - 1][lavoro - 1]) - 1] += d[operazione - 1][lavoro - 1];//dove d è il vettore dei costi
                    }
                }
                fitnesses[k] = tmacchine.Max();

            }
            Array.Sort(fitnesses, popolazione);//riordina la popolazione secondo il fitness
        }

        public void proxgenerazione()//genera la prossima generazione di popolazione
        {
            int ind = 0;
            int[] samples = parent_casual(figli);//selezione casuale dei genitori
            int[][] children = new int[figli][];
            int[] popFit = new int[popolazione.Length];
            int[] indexPop = new int[popolazione.Length];

            int[] fitp = new int[popolazione.Count()];
            //servono 2 figli
            for (int i = 0; i < samples.Count(); i = i + 2)
            {

                children[ind] = createChild(samples[i], samples[i + 1]);

                if (rand.NextDouble() >= Pmutazione)
                {
                    swap(children[ind]);
                }
                ind++;
                // lo rifà invertendo i parent perchè deve avere 2 figli dagli stessi gentori
                children[ind] = createChild(samples[i + 1], samples[i]);

                if (rand.NextDouble() >= Pmutazione)
                {
                    swap(children[ind]);
                }
                ind++;
            }
            //popolazione è ordinata per fitness,tolgo gli ultimi elementi dalla popolazione e li sostituisco con i figli
            //k rappresenta il numero dei figli.
            for (int k = 1; k <= children.Length; k++)
            {
                Array.Copy(children[k - 1], popolazione[popolazione.Length - k], children[k - 1].Length);
            }
            tempvalue((popolazione.Length - figli), popolazione.Length);//richiamo tempvaule  perchè mi riordina la popolazione

        }

        private int[] parent_casual(int amount)//seleziona n genitori in modo casuale,(servono per i figli)
        {   //cerca di dare priorità ai genitori con fitness migliore
            //hanno probabilità di essere selezione quelli con alto fitness, ma serve il contraio
            int[] risultato = new int[amount];
            double[] fitness_inverso = new double[popolazione.Count()];//numore degli elementi di popolazione
            double totalFit = 0;

            double val; //per il random
            double j = 0, tot;
            int cont = 0;
            bool duplicato = false;

            totalFit = fitnesses.Sum();//somma di tutte le fitness

            for (int i = 0; i < fitnesses.Length; i++)
            {   //forza la scelta
                fitness_inverso[i] = totalFit / fitnesses[i];//calcolo in modo da avere un valore maggiore con fitness minore, e vice
            }
            tot = fitness_inverso.Sum();//somma dei valori in sequenza

            while (cont < amount)//lo fa per tutti i figli
            {
                duplicato = false;
                val = rand.NextDouble();//0 o 1
                j = 0;
                for (int i = 0; i < fitness_inverso.Length; i++)
                {//scorre tutte le soluzioni nella popolazione
                    if (val >= j && val < j + fitness_inverso[i] / tot) //fitness_inverso = fitness totale / fitness relativo ad una soluzione 
                    {   //prende i genitori con fitness migliore
                        //j parte da zero ed ad ogni iterazione viene incrementato di fitness_inverso/somma di tutti gli fitness_inverso

                        //Utilizzo l'indice del genitore nel vettore popolazione
                        for (int k = 0; k < cont; k++)
                        {//controllo se la soluzione è presente nei genitori già selezionati
                            if (risultato[k] == i)
                            {
                                duplicato = true;
                                break; //esce dal ciclo
                            }
                        }
                        if (!duplicato)//se non è duplicato,metto nel risultato l indice
                        {
                            risultato[cont] = i;
                            cont++;
                            break;
                        }
                    }
                    j += fitness_inverso[i] / tot;
                }
            }

            return risultato;
        }

        private int[] createChild(int parent1, int parent2)//unisce 2 array in modo randonm
        {   // ho dei genitori, da zero al primo pezzo lo prende "parent 1", da li alla fine il 2. Controllando che nn ci siano
            //elementi doppi
            int[] child = new int[popolazione[parent1].Length];
            int ind = 0;
            bool duplicato = false;
            int value = rand.Next(1, popolazione[parent1].Length - 1);
            ind = value;
            Array.ConstrainedCopy(popolazione[parent1], 0, child, 0, value);//parte da zero e arriva a value, valori inseriti dentro child da 0 a value
            for (int i = 0; i < popolazione[parent2].Length; i++)
            {//scorro tutto il secondo genitore e inserisco le operazioni mancanti nel figlio in modo da avere sempre una sol accettabile
                duplicato = false;
                for (int k = 0; k < ind; k++)
                {
                    if ((popolazione[parent2])[i] == child[k])
                    {
                        duplicato = true;
                    }
                }
                if (!duplicato)
                {
                    child[ind] = (popolazione[parent2])[i];//lo aggiungo ai figli se non è presente
                    ind++;
                }
            }
            return child;
        }
        //passo il figlio
        private void swap(int[] vector)//probabilità del ga di mutazione del figlio
        {//esegue uno swap casuale tra due operazioni, genera un numero random.
            //se la probabilità, calcolata sopra è maggiore di quella passata in input, fa lo switch tra 2 elemti
            int index1 = rand.Next(0, vector.Length - 1);
            int index2;
            do
            {
                index2 = rand.Next(0, vector.Length - 1);
            } while (index2 == index1);

            int temp = vector[index1];
            vector[index1] = vector[index2];
            vector[index2] = temp;
        }

   }
}
