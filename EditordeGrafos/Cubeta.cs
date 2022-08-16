using System.Collections.Generic;


namespace EditordeGrafos
{
    public class Cubeta
    {
        public int Direccion { get; set; }
        public int Siguiente { get; set; }
        public int Limite { get; set; }
        private List<int> Datos;
        public int NumeroCubeta { get; set; }

        public Cubeta(int Direccion , int Limite , int NumeroCubeta)
        {
            this.Direccion = Direccion;
            this.Siguiente = 0;
            this.Datos = new List<int>();
            this.Limite = Limite;
            this.NumeroCubeta = NumeroCubeta;
        }

        public Cubeta(int Direccion, int Limite, int NumeroCubeta , int Siguiente)
        {
            this.Direccion = Direccion;
            this.Siguiente = Siguiente;
            this.Datos = new List<int>();
            this.Limite = Limite;
            this.NumeroCubeta = NumeroCubeta;
        }


        public bool Vacia()
        {
            if (Datos.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Lleno()
        {
            if (Datos.Count == Limite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Inserta(int clave)
        {
            Datos.Add(clave);
            Datos.Sort();
        }

        public List<string> getDatos()
        {
            List<string> datos = new List<string>();
            for (int i = 0; i < Datos.Count; i++)
            {
                datos.Add(Datos[i].ToString());
            }
            return datos;
        }

        public void Limpia()
        {
            Datos.Clear();
        }

        public string GetNumeroDeElementos()
        {
            return Datos.Count.ToString();
        }

        public string Cabecera()
        {
            return Direccion.ToString() + " -- " + Datos.Count.ToString() + " -- " + NumeroCubeta.ToString() + " -- " + Siguiente.ToString();
        }
    }
}
