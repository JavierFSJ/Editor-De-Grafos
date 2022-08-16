using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    public class NodoArbol
    {
        public long DirNodo { get; set; }
        public long DirPadre { get; set; }
        public char Tipo { get; set; }
        public int Orden { get; set; }
        public List<int> Claves { get; set; }
        public List<long> Direcciones { get; set; }

        public NodoArbol(int Orden)
        {
            DirPadre = -1;
            this.Orden = Orden;
            Claves = new List<int>();
            Direcciones = new List<long>();
        }
        public NodoArbol(long DirNodo, char Tipo, int Orden)
        {
            this.Orden = Orden;
            this.DirNodo = DirNodo;
            this.Tipo = Tipo;
            DirPadre = -1;
            Claves = new List<int>();
            Direcciones = new List<long>();
        }



        public bool ExisteClave(int Clave)
        {
            return (Claves.Contains(Clave));
        }
        public bool IsOverFlow()
        {
            if (Claves.Count == Orden)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Para Hoja
        public void Insertar(int Clave, long Direccion)
        {
            if (Tipo == 'H')
            {
                InsertarHoja(Clave, Direccion);
            }
            else
            {
                InsertarRaiz(Clave, Direccion);
            }
        }

        private void InsertarHoja(int Clave, long direccion)
        {

            int indice = GetIndiceInsercion(Clave);
            if (indice == -1)
            {
                Claves.Add(Clave);
                Direcciones.Add(direccion);

            }
            else
            {
                Claves.Insert(indice, Clave);
                Direcciones.Insert(indice, direccion);

            }

        }

        private void InsertarRaiz(int Clave, long Direccion)
        {
            int indice = GetIndiceInsercion(Clave);
            if (indice == -1)
            {
                Claves.Add(Clave);
                Direcciones.Add(Direccion);

            }
            else
            {
                Claves.Insert(indice, Clave);
                indice++;
                Direcciones.Insert(indice, Direccion);

            }
        }


        #region Auxiliares
        private int GetIndiceInsercion(int Clave)
        {
            int res = -1;
            if (Claves.Count > 0)
            {
                for (int i = 0; i < Claves.Count; i++)
                {
                    if (Clave < Claves[i])
                    {
                        res = i;
                        break;
                    }
                }
            }
            return res;
        }


        #endregion

        #region Listas
        public List<int> GetClavesToPrint()
        {
            List<int> AuxClaves = new List<int>();
            for (int i = 0; i < Claves.Count; i++)
            {
                AuxClaves.Add(Claves[i]);
            }

            int Max = (Orden - 1) - Claves.Count;
            for (int i = 0; i < Max; i++)
            {
                AuxClaves.Add(-1);
            }
            return AuxClaves;
        }

        public List<long> GetDireccionesToPrint()
        {
            List<long> AuxDirecciones = new List<long>();
            for (int i = 0; i < Direcciones.Count; i++)
            {
                AuxDirecciones.Add(Direcciones[i]);
            }

            int Max = Orden - Direcciones.Count;
            for (int i = 0; i < Max; i++)
            {
                AuxDirecciones.Add(-1);
            }

            return AuxDirecciones;
        }

        public void SetListClaves(List<int> AuxClaves)
        {
            Claves.Clear();
            for (int i = 0; i < AuxClaves.Count; i++)
            {
                if (AuxClaves[i] != -1)
                {
                    Claves.Add(AuxClaves[i]);
                }
            }
        }
        public void SetListDirecciones(List<long> AuxDirecciones)
        {
            Direcciones.Clear();
            for (int i = 0; i < AuxDirecciones.Count; i++)
            {
                if (AuxDirecciones[i] != -1)
                {
                    Direcciones.Add(AuxDirecciones[i]);
                }
            }
        }
        #endregion



        #region Archivo
        public void GuardarNodo(BinaryWriter writer)
        {
            writer.BaseStream.Position = DirNodo;
            List<int> AuxClaves = GetClavesToPrint();
            List<long> AuxDirecciones = GetDireccionesToPrint();
            writer.Write(DirNodo);
            writer.Write(DirPadre);
            writer.Write(Tipo);
            for (int i = 0; i < Orden; i++)
            {
                writer.Write(AuxDirecciones[i]);
                if (i != Orden - 1)
                {
                    writer.Write(AuxClaves[i]);
                }
            }
            writer.Flush();
            writer.Close();
        }
        #endregion

    }
}
