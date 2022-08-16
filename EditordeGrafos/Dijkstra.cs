using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    class Dijkstra
    {
        const int INF = 100000;
        int NumNodos;
        public int[,] MatrizRelacion { get; set; }
        int NodoOrigen = -1;
        public int[] Distancias { get; set; }
        bool istLetter;

        public Dijkstra(int N, int[,] MR, string Origen)
        {
            NumNodos = N;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (MR[i, j] == 0)
                    {
                        MR[i, j] = INF;
                    }
                }
            }
            MatrizRelacion = MR;
            NodoOrigen = ConvierteLetra(Origen);
            if (int.TryParse(Origen, out int x))
            {
                istLetter = true;
            }
            else
            {
                istLetter = false;
            }
            Distancias = new int[NumNodos];
            //ALgoritmoDIjkstra();
        }

        public List<List<int>> ALgoritmoDIjkstra()
        {
            bool[] NodoVisitado = new bool[NumNodos];
            Distancias = new int[NumNodos];
            List<List<int>> Caminos = new List<List<int>>();
            for (int i = 0; i < NumNodos; i++)
            {
                Distancias[i] = MatrizRelacion[NodoOrigen, i];
                NodoVisitado[i] = false;
                Caminos.Add(new List<int>());
                Caminos[i].Add(NodoOrigen);
            }
            //MessageBox.Show("Distancias Iniciales: ");
            Distancias[NodoOrigen] = 0;
            for (int n = 0; n < NumNodos - 1; n++)
            {
                int Indice = ObtenIndiceValorMinimo(Distancias, NodoVisitado);
                //MessageBox.Show("Indice que estoy visitando: " + Indice);
                NodoVisitado[Indice] = true;
                for (int v = 0; v < NumNodos; v++)
                {
                    if (!NodoVisitado[v] && MatrizRelacion[Indice, v] != INF && Distancias[Indice]
                        + MatrizRelacion[Indice, v] < Distancias[v])
                    {

                        //Console.WriteLine("He encontrado un camino menor hacia {0} desde {1}", v + 1, Indice + 1);
                        for (int i = 1; i < Caminos[Indice].Count; i++)
                        {
                            if (Caminos[Indice][i] != NodoOrigen)
                            {
                                Caminos[v].Add(Caminos[Indice][i]);
                            }

                        }
                        Caminos[v].Add(Indice);
                        Distancias[v] = Distancias[Indice] + MatrizRelacion[Indice, v];
                    }
                }
            }
            int IndiceLista = 0;
            for (int i = 0; i < Caminos.Count; i++)
            {
                for (int j = 0; j < Caminos[i].Count; j++)
                {
                    Caminos[i][j] += 1;
                }
            }
            foreach (List<int> ListI in Caminos)
            {
                ListI.Add(IndiceLista + 1);
                string CadAux = "Camino del origen a: " + (IndiceLista + 1) + "\n";
                foreach (int i in ListI)
                {
                    CadAux += (i) + " - ";
                }
                IndiceLista++;
                //MessageBox.Show(CadAux);
            }
            Caminos.RemoveAt(NodoOrigen);
            for (int i = 0; i < NumNodos; i++)
            {
                if (Distancias[i] == INF)
                {
                    Caminos.RemoveAt(i);
                }
            }
            // ImprimeDistancias();
            return Caminos;
        }
        public int ObtenIndiceValorMinimo(int[] ArregloDistancias, bool[] NodosVisitados)
        {
            int min = INF, min_index = -1;

            for (int v = 0; v < NumNodos; v++)
                if (NodosVisitados[v] == false && ArregloDistancias[v] <= min)
                {
                    min = ArregloDistancias[v];
                    min_index = v;
                }

            return min_index;
        }

        public void ImprimeDistancias()
        {
            string CADAUX = "\t**************ALGORITMO DE DIJKSTRA**************\n";
            if (!istLetter)
            {
                for (int i = 0; i < Distancias.Length; i++)
                {
                    if (Distancias[i] != INF)
                    {
                        CADAUX += "\t     Distancia mínima desde " + ConvierteNum(NodoOrigen) + "  hacía: " + ConvierteNum(i) + "   es de: " + Distancias[i] + "\n";
                    }
                    else
                    {
                        CADAUX += "\t     Distancia mínima desde " + ConvierteNum(NodoOrigen) + "  hacía: " + ConvierteNum(i) + "   no existe" + "\n";
                    }

                }
            }
            else
            {
                for (int i = 0; i < Distancias.Length; i++)
                {
                    if (Distancias[i] != INF)
                    {
                        CADAUX += "\t     Distancia mínima desde " + (NodoOrigen) + "  hacía: " + (i) + "   es de: " + Distancias[i] + "\n";
                    }
                    else
                    {
                        CADAUX += "\t     Distancia mínima desde " + (NodoOrigen) + "  hacía: " + (i) + "   no existe" + "\n";
                    }

                }
            }

            //MessageBox.Show(CADAUX);
        }

        private int ConvierteLetra(string letra)
        {
            int Num = 0;


            if (letra == "A")
            {
                Num = 0;
            }
            else if (letra == "B")
            {
                Num = 1;
            }
            else if (letra == "C")
            {
                Num = 2;
            }
            else if (letra == "D")
            {
                Num = 3;
            }
            else if (letra == "E")
            {
                Num = 4;
            }
            else if (letra == "F")
            {
                Num = 5;
            }
            else if (letra == "G")
            {
                Num = 6;
            }
            else if (letra == "H")
            {
                Num = 7;
            }
            else if (letra == "I")
            {
                Num = 8;
            }
            else if (letra == "J")
            {
                Num = 9;
            }
            else if (letra == "K")
            {
                Num = 10;
            }
            else if (letra == "L")
            {
                Num = 11;
            }
            else if (letra == "M")
            {
                Num = 12;
            }
            else if (letra == "N")
            {
                Num = 13;
            }
            else if (letra == "O")
            {
                Num = 14;
            }
            else if (letra == "P")
            {
                Num = 15;
            }
            else if (letra == "Q")
            {
                Num = 16;
            }
            else if (letra == "R")
            {
                Num = 17;
            }
            else if (letra == "S")
            {
                Num = 18;
            }
            else if (letra == "T")
            {
                Num = 19;
            }
            else if (letra == "U")
            {
                Num = 20;
            }
            else if (letra == "V")
            {
                Num = 21;
            }
            else if (letra == "W")
            {
                Num = 22;
            }
            else if (letra == "X")
            {
                Num = 23;
            }
            else if (letra == "Y")
            {
                Num = 24;
            }
            else if (letra == "Z")
            {
                Num = 25;
            }
            else if (int.TryParse(letra, out Num))
            {
                int.TryParse(letra, out Num);
            }

            return Num;

        }


        private string ConvierteNum(int num)
        {
            string c = "";


            if (num == 0)
            {
                c = "A";
            }
            else if (num == 1)
            {
                c = "B";
            }
            else if (num == 2)
            {
                c = "C";
            }
            else if (num == 3)
            {
                c = "D";
            }
            else if (num == 4)
            {
                c = "E";
            }
            else if (num == 5)
            {
                c = "F";
            }
            else if (num == 6)
            {
                c = "G";
            }
            else if (num == 7)
            {
                c = "H";
            }
            else if (num == 8)
            {
                c = "I";
            }
            else if (num == 9)
            {
                c = "J";
            }
            else if (num == 10)
            {
                c = "K";
            }
            else if (num == 11)
            {
                c = "L";
            }
            else if (num == 12)
            {
                c = "M";
            }
            else if (num == 13)
            {
                c = "N";
            }
            else if (num == 14)
            {
                c = "O";
            }
            else if (num == 15)
            {
                c = "P";
            }
            else if (num == 16)
            {
                c = "R";
            }
            else if (num == 17)
            {
                c = "S";
            }
            else if (num == 18)
            {
                c = "T";
            }
            else if (num == 19)
            {
                c = "U";
            }
            else if (num == 20)
            {
                c = "V";
            }
            else if (num == 21)
            {
                c = "W";
            }
            else if (num == 22)
            {
                c = "X";
            }
            else if (num == 23)
            {
                c = "Y";
            }
            else if (num == 24)
            {
                c = "Z";
            }
            return c;

        }
    }
}
