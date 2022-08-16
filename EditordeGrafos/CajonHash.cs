using System.Collections.Generic;


namespace EditordeGrafos
{
    public class CajonHash
    {

        public int Direccion { get; set; }
        private LinkedList<Cubeta> cubetas;
        private List<int> Claves;
        private int Limite;

        public CajonHash(int Limite)
        {
            Direccion = 0;
            cubetas = new LinkedList<Cubeta>();
            Claves = new List<int>();
            this.Limite = Limite;
        }

        public CajonHash(int Limite , int Direccion)
        {
            this.Direccion = Direccion;
            cubetas = new LinkedList<Cubeta>();
            Claves = new List<int>();
            this.Limite = Limite;
        }


        public int Insertar(int clave)
        {
            int res = 0;
            if (!ValorExistente(clave))
            {
               
                Claves.Add(clave);
                Claves.Sort();

                LimpiaCubetas();
                LLenaCubetas();
                res = 1;
            }
            return res;
        }


        public int Eliminar(int clave)
        {
            int res = 0;
            if (ValorExistente(clave))
            {

                Claves.Remove(clave);
                Claves.Sort();

                LimpiaCubetas();
                LLenaCubetas();
                res = 1;
            }
            return res;
        }

        
        public List<string> getDatos()
        {
            List<string> datos = new List<string>();


            LinkedListNode<Cubeta> itr = cubetas.First;
            while (itr != null)
            {
                datos.Add("//////////////////////////");
                string cadena = itr.Value.Direccion.ToString() + "    -    " + itr.Value.GetNumeroDeElementos()+ "    -   " +itr.Value.NumeroCubeta.ToString()+"   -   "+ itr.Value.Siguiente.ToString();
                datos.Add(cadena);
                List<string> ValoresCubeta = itr.Value.getDatos();
                for (int i = 0; i < ValoresCubeta.Count; i++)
                {
                    datos.Add(ValoresCubeta[i]);
                }
                datos.Add("//////////////////////////");
                itr = itr.Next;
            }

            return datos;
        }


        private void ColocarDireccion()
        {
            if (cubetas.First != null)
            {
                Direccion = cubetas.First.Value.Direccion;
            }
        }


        private bool ValorExistente(int Clave)
        {
            return Claves.Contains(Clave);
        }


        private void LimpiaCubetas()
        {
            LinkedListNode<Cubeta> itr = cubetas.First;
            while (itr != null)
            {
                itr.Value.Limpia();
                itr = itr.Next;
            }
        }

        private void LLenaCubetas()
        {
            LimpiaCubetas();
            LinkedListNode<Cubeta> itr = cubetas.First;
            for (int i = 0; i < Claves.Count; i++)
            {
                itr.Value.Inserta(Claves[i]);
                if (itr.Value.Lleno())
                {
                    itr = itr.Next;
                }
                
            }
        }

        private void ColacaDireccionSig()
        {
            for (LinkedListNode<Cubeta> tmp = cubetas.First; tmp != null; tmp = tmp.Next)
            {
                if (tmp.Next == null)
                {
                    tmp.Value.Siguiente = 0;
                }
                else
                {
                    tmp.Value.Siguiente = tmp.Next.Value.Direccion;
                }
            }
        }

        public bool CubetasLlenas()
        {
            bool flag = false;
            LinkedListNode<Cubeta> itr = cubetas.First;
            while (itr != null)
            {
                if (itr.Value.Lleno())
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
                itr = itr.Next;
            }
            return flag;
        }

        public Cubeta CubetaVacia()
        {
            Cubeta vacia = null;
            LinkedListNode<Cubeta> itr = cubetas.First;
            while (itr != null)
            {
                if (itr.Value.Vacia())
                {
                    vacia = itr.Value;
                    cubetas.Remove(itr);
                    break;
                }
                itr = itr.Next;
            }
            ColacaDireccionSig();
            GetDireccion();
            return vacia;
        }

        public void AgregarCubeta(Cubeta cubeta)
        {
            LinkedListNode<Cubeta> nueva = new LinkedListNode<Cubeta>(cubeta);
            cubetas.AddLast(nueva);
            ColocarDireccion();
            ColacaDireccionSig();
        }

        public bool CajonVacio()
        {
            if (Direccion == 0)
                return true;
            else
                return false;
        }

        private void GetDireccion()
        {
            if (cubetas.Count == 0)
            {
                Direccion = 0;
            }
            else
            {
                Direccion = cubetas.First.Value.Direccion;
            }
        }    
    
    }
}
