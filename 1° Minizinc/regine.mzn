%programma di Marco Cavalazzi , matricola: 0000644460
int: n; %n passato dal file nregine.dzn reppresenta il numero di regine ed anche la grandezza della scacchiera

set of int: size = 0 .. n-1; % in size mettiamo il valore passato per la grandezza della scacchiera

array [size, size] of var 0 .. 1: q; % array bidimensionale della grandezza del valore passato, riempito di zeri e 1

%con l'assert controllo l input, che dovrà essere =1 o >4 
constraint assert(n=1 \/ n>4 ,"Errore: " ++"valore di input non soddisfa il problema, ricorda di inserire un valore uguale a 1 o maggiore di 4");

constraint forall (i in size) ( %scorro la scacchiera
	( sum (j in size) (q[i, j])=  1 ) /\ ( sum (j in size) (q[j, i])=  1 ) %controllo che la somma della riga =1 e somma della colonna =1 

/\	( sum (j, k in size where j - k = - i) (q[j, k]) <= 1 )% controllo dalla diagonale principale, partendo dalla posizione 0,0 e mi sposto verso destra
										                   %quindi 0,1 0,2 ecc...
														   
/\	( sum (j, k in size where j - k = i) (q[j, k]) <= 1 ) %come sopra ma si controllando le diagonali sotto la principale,
														  % quindi quelle che nascono in 1,0 2,0 3,0 ecc...

														  %per analogia diagonale sx
/\( sum (j, k in size where j - k = - i) (q[n - 1 - j, k]) <= 1 )% controllo della diagonale in basso a sx, e partendo dalla posizione [n-1,0] mi sposto 
															     % verso destra

/\( sum (j, k in size where j - k = i) (q[n - 1 - j, k])<= 1 )%contrario di sopra, mi sposto verso l alto
);

solve satisfy; 
	
output ["il numero di regine corrispondente al numero di caselle inserito e': "] ++[ show(n) ] 
		++ [",la scacchiera risultate e' la seguente:\n"] ++
	[	if j = 0 then "\n" else "" endif ++	show(q[i, j])|	i, j in size]; %stampa per righe 