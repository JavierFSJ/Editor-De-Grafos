using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public class Hash
    {
        public int Cubetas { get; set; }
        public int tamRegistro { get; set; }
        public int NumRegisro { get; set; }
        private int EOF;
        private int NumCubeta = 1;
       
        public int Vacias { get; set; }
        private List<CajonHash> cajonHashes;
        private List<Cubeta> cubetas;
        private Stack<Cubeta> vacias;


        public Hash(int Cubetas)
        {
            this.Cubetas =  Cubetas;
            tamRegistro = 50;
            NumRegisro = 4;
            Vacias = 0;
            EOF = 48;

            vacias = new Stack<Cubeta>();
            cubetas = new List<Cubeta>();
            cajonHashes = new List<CajonHash>();
            for (int i = 0; i < this.Cubetas; i++)
            {
                cajonHashes.Add(new CajonHash(NumRegisro));
            }

        }

        public Hash()
        {
            EOF = 48;
            cajonHashes = new List<CajonHash>();
            cubetas = new List<Cubeta>();
            vacias = new Stack<Cubeta>();
            AbrirArchivo();
        }


        public int  Insetar(int Clave)
        {
            int res = 0;
            CajonHash cajon = cajonHashes[FuncionHash(Clave)];
            if (cajon.CajonVacio() || cajon.CubetasLlenas())
            {
                Cubeta cubeta;
                if (vacias.Count == 0)
                {
                    cubeta = new Cubeta(EOF, NumRegisro, NumCubeta);
                    cubetas.Add(cubeta);
                    EOF += 208;
                    NumCubeta++;
                }
                else
                {
                    cubeta = vacias.Pop();
                    ActualizaVacias();
                }
                cajon.AgregarCubeta(cubeta);
                res = cajon.Insertar(Clave);
                
            }
            else
            {
                res = cajon.Insertar(Clave);
                
            }
            return res;
        }


        public int  Eliminar(int Clave)
        {
            int res = 0;
            CajonHash cajon = cajonHashes[FuncionHash(Clave)];
            res  = cajon.Eliminar(Clave);
            if (res == 1)
            {
                Cubeta vacia = cajon.CubetaVacia();
                if (vacia != null)
                {

                    if (vacias.Count > 0)
                    {
                        Cubeta anterior = vacias.Peek();
                        vacia.Siguiente = anterior.Direccion;
                    }
                    vacias.Push(vacia);
                    Vacias = vacia.Direccion;
                }
            }
            return res;
        }



        private int FuncionHash(int clave)
        {
            return clave % this.Cubetas;
        }

        public List<string> getDirecciones()
        {
            List<string> direcciones = new List<string>();
            for (int i = 0; i < cajonHashes.Count; i++)
            {
                direcciones.Add(cajonHashes[i].Direccion.ToString());
            }
            return direcciones;
        }

        public List<string> ListarCajon(int posicion)
        {
            List<string> datos = new List<string>();
            if (cajonHashes[posicion].Direccion != 0)
            {
                datos = cajonHashes[posicion].getDatos();
            }
            return datos;
        }


        private void AbrirArchivo()
        {
            OpenFileDialog VentanaAbrir = new OpenFileDialog();
            VentanaAbrir.Filter = "Precargado (*.txt)|*.txt";
            if (VentanaAbrir.ShowDialog() == DialogResult.OK)
            {
                List<int> Claves = new List<int>();
                StreamReader Lector = new StreamReader(VentanaAbrir.FileName);
                string Inicio = Lector.ReadLine();
                string[] datos =  Inicio.Split(',');

                Cubetas = Convert.ToInt32(datos[0]);
                NumRegisro = Convert.ToInt32(datos[1]);
                tamRegistro = Convert.ToInt32(datos[2]);
                Vacias = Convert.ToInt32(datos[3]);
                

                for (int i = 0; i < Cubetas; i++)
                {
                    string cadena = Lector.ReadLine();
                    datos = cadena.Split(',');
                    cajonHashes.Add(new CajonHash(NumRegisro , GetEntero(datos[1])));
                    
                }
                EOF = 48;

                while (!Lector.EndOfStream)
                {
                    string cadena = Lector.ReadLine();
                    if (cadena.Length > 0)
                    {
                        string[] Values = cadena.Split(',');
                        if (Values.Length == 1)
                        {
                            Claves.Add(GetEntero(Values[0]));
                        }
                        else if (Values.Length == 4)
                        {
                            Cubeta cubeta = new Cubeta(GetEntero(Values[0]), NumRegisro, NumCubeta, GetEntero(Values[3]));
                            cubetas.Add(cubeta);
                            EOF += 208;
                            NumCubeta++;
                        }

                    }

                }

                Lector.Close();
                AlmacenaCubetasVacias(Vacias);
                AsignaCubetas();
                for (int i = 0; i < Claves.Count; i++)
                {
                    Insetar(Claves[i]);
                }
                
            }
        }

        public void GuardarArchivo()
        {
            SaveFileDialog VentanaGuardar = new SaveFileDialog();
            VentanaGuardar.Filter = "Precargado (*.txt)|*.txt";
            if (VentanaGuardar.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(VentanaGuardar.FileName);
                writer.WriteLine(Cubetas.ToString()+","+NumRegisro.ToString()+","+tamRegistro.ToString()+","+Vacias.ToString()+",208;");
                for (int i = 0; i < Cubetas; i++)
                {
                    writer.WriteLine(i.ToString() + "," + cajonHashes[i].Direccion.ToString());
                }

                for (int i = 0; i < cubetas.Count; i++)
                {
                    writer.WriteLine(cubetas[i].Direccion.ToString() + "," + cubetas[i].getDatos().Count.ToString() + "," + cubetas[i].NumeroCubeta.ToString() + "," + cubetas[i].Siguiente.ToString());
                    List<string> valores = cubetas[i].getDatos();
                    for (int j = 0; j < valores.Count; j++)
                    {
                        writer.WriteLine(valores[j]);
                    }
                }

                writer.Flush();
                writer.Close();
            }
        }

        private int GetEntero(string dato)
        {
            string aux = "";
            foreach (char caracter in dato)
            {
                if (char.IsDigit(caracter))
                {
                    aux += caracter;
                }
            }
            //MessageBox.Show(aux);
            return Convert.ToInt32(aux);
        }

        private void AsignaCubetas()
        {
            for (int i = 0; i < cajonHashes.Count; i++)
            {
                if (cajonHashes[i].Direccion != 0)
                {
                    ColocaCubeta(cajonHashes[i] , cajonHashes[i].Direccion);
                }
            }
        }

        private void AlmacenaCubetasVacias(int direccion)
        {
            if (direccion != 0)
            {
                Cubeta cubeta = GetCubeta(direccion);
                int sig = cubeta.Siguiente;
                AlmacenaCubetasVacias(sig);
                vacias.Push(cubeta);
            }
        }

        private void ActualizaVacias()
        {
            if (vacias.Count > 0)
            {
             
                Vacias = vacias.Peek().Direccion;
            }
            else
            {
           
                Vacias = 0;
            }
        }


        private void ColocaCubeta(CajonHash c , int Direccion)
        {
            if (Direccion != 0)
            {
                Cubeta cubeta = GetCubeta(Direccion);
                int sig = cubeta.Siguiente;
                c.AgregarCubeta(cubeta);
                ColocaCubeta(c, sig);
            }
        }
        

        private Cubeta GetCubeta(int Direccion)
        {
            for (int i = 0; i < cubetas.Count; i++)
            {
                if (Direccion == cubetas[i].Direccion)
                {
                    return cubetas[i];
                }
            }
            return null;
        }

        public List<string> getCubetasVacias()
        {
            List<string> valores = new List<string>();
            if (vacias.Count > 0)
            {
                Cubeta[] aux = vacias.ToArray();
                for (int i = 0; i < aux.Length; i++)
                {
                    valores.Add(aux[i].Cabecera());
                }
            }
            return valores;
        }
    }
}
