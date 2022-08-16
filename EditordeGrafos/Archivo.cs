using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public class Archivo
    {
        private FileStream Arbol;
        private FileStream Cabecera;
        private string RutaArchivo;
        private string RutaCabecera;
        private string RutaCarpeta;
        private int OrdenArbol = 5;

        public int Insertar(int Clave, char[] Dato)
        {
            int res = 0;
            res = InsertarArbol(Clave, Dato, GetRaizDireccion());
            return res;
        }

        public List<Elemento> Listar()
        {
            List<Elemento> DatosArchivos = getTipoDireccion();
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                foreach (Elemento e in DatosArchivos)
                {
                    if (e.Tipo == 'R')
                    {
                        //essageBox.Show(e.DireccionElemento.ToString());
                        Registro registro = getRegistro(e.DireccionElemento);
                        e.Dato = registro;
                    }
                    else if (e.Tipo == 'T')
                    {
                        NodoArbol nodo = getNodoArbol(e.DireccionElemento);
                        e.Dato = nodo;
                    }
                }

            }
            return DatosArchivos;
        }

        #region Archivos
        private bool CrearDirectorio()
        {
            bool Creado = false;
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.ShowDialog();
                RutaCarpeta = guardar.FileName;
                string aux = RutaCarpeta;
                DirectoryInfo directorio = Directory.CreateDirectory(RutaCarpeta);
                RutaArchivo = RutaCarpeta += ObtenerNombreCarpeta(RutaCarpeta);
                RutaCabecera = aux += "\\Cab.dd";
                Creado = true;
            }
            catch (Exception)
            {

                Creado = false;
            }
            return Creado;

        }
        private string ObtenerNombreCarpeta(string dir)
        {
            string[] aux = dir.Split('\\');
            int longitud = aux.Length;
            string res = "\\";
            res += aux[longitud - 1];
            return res += ".dd";
        }
        public bool CrearArchivos()
        {
            bool Creados = false;
            if (CrearDirectorio())
            {
                if (!File.Exists(RutaArchivo) && !File.Exists(RutaCabecera))
                {
                    Arbol = new FileStream(RutaArchivo, FileMode.Create);
                    Cabecera = new FileStream(RutaCabecera, FileMode.Create);

                    if (Arbol != null && Cabecera != null)
                    {
                        Creados = true;
                        Arbol.Close();
                        Cabecera.Close();
                        long Dir = 1000;
                        NodoArbol inicial = new NodoArbol(Dir, 'H', OrdenArbol);
                        EscribeCabeceraRegistro(-1);
                        EscribeRaizDireccion(inicial.DirNodo);
                        EscribeUltimaRegistroDireccion(-1);
                        CrearGuardarElemento(inicial, 'T', inicial.DirNodo);

                    }
                }
            }
            return Creados;
        }
        private void EscribeCabeceraRegistro(long R)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Write);
                if (Cabecera != null)
                {
                    BinaryWriter writer = new BinaryWriter(Cabecera);
                    writer.BaseStream.Position = 0;
                    writer.Write(R);
                    writer.Flush();
                    writer.Close();
                    Cabecera.Close();
                }
            }
        }
        private void EscribeRaizDireccion(long A)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Write);
                if (Cabecera != null)
                {
                    BinaryWriter writer = new BinaryWriter(Cabecera);
                    writer.BaseStream.Position = 8;
                    writer.Write(A);
                    writer.Flush();
                    writer.Close();
                    Cabecera.Close();
                }
            }
        }
        private void EscribeUltimaRegistroDireccion(long U)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Write);
                if (Cabecera != null)
                {
                    BinaryWriter writer = new BinaryWriter(Cabecera);
                    writer.BaseStream.Position = 16;
                    writer.Write(U);
                    writer.Flush();
                    writer.Close();
                    Cabecera.Close();
                }
            }
        }
        private long GetRaizDireccion()
        {
            long Direccion = -6;
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Read);
                if (Cabecera != null)
                {
                    BinaryReader reader = new BinaryReader(Cabecera);
                    reader.BaseStream.Position = 8;
                    Direccion = reader.ReadInt64();
                    reader.Close();
                    Cabecera.Close();
                }
            }
            return Direccion;
        }
        private long GetUltimoRegistro()
        {
            long Direccion = -6;
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Read);
                if (Cabecera != null)
                {
                    BinaryReader reader = new BinaryReader(Cabecera);
                    reader.BaseStream.Position = 16;
                    Direccion = reader.ReadInt64();
                    reader.Close();
                    Cabecera.Close();
                }
            }
            return Direccion;
        }
        private void GuardarElemento(Elemento nuevo, long Direccion)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Write);
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Write);
                if (Arbol != null && Cabecera != null)
                {
                    BinaryWriter writerElemento = new BinaryWriter(Arbol);
                    BinaryWriter writerTipo = new BinaryWriter(Cabecera);
                    if (nuevo.Tipo == 'R')
                    {
                        Registro registro = (Registro)nuevo.Dato;
                        registro.GuardaRegistro(writerElemento);
                        nuevo.GuardaTipo(writerTipo, Direccion);
                    }
                    else
                    {
                        NodoArbol nodo = (NodoArbol)nuevo.Dato;
                        nodo.GuardarNodo(writerElemento);
                        nuevo.GuardaTipo(writerTipo, Direccion);
                    }
                    Arbol.Close();
                    Cabecera.Close();
                }

            }
        }
        private void GuardaRegistro(Registro registro)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Write);

                if (Arbol != null)
                {
                    BinaryWriter writerElemento = new BinaryWriter(Arbol);
                    registro.GuardaRegistro(writerElemento);
                    Arbol.Close();
                }
            }
        }

        private long GetLegthArchivo()
        {
            long Direccion = -1;
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open);
                if (Arbol != null)
                {
                    Direccion = Arbol.Length;
                    Arbol.Close();
                }

            }
            return Direccion;
        }
        private long GetLegthArchivoCab()
        {
            long Direccion = -1;
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open);
                if (Cabecera != null)
                {
                    Direccion = Cabecera.Length;
                    Cabecera.Close();
                }

            }
            return Direccion;
        }

        private void GuardaNodo(NodoArbol nodo)
        {
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Write);

                if (Arbol != null)
                {
                    BinaryWriter writerElemento = new BinaryWriter(Arbol);
                    nodo.GuardarNodo(writerElemento);
                    Arbol.Close();
                }
            }
        }

        private Registro getRegistro(long Direccion)
        {
            Registro registro = null;
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read);
                if (Arbol != null)
                {
                    BinaryReader reader = new BinaryReader(Arbol);
                    reader.BaseStream.Position = Direccion;
                    registro = new Registro();
                    registro.Direccion = reader.ReadInt64();
                    registro.Clave = reader.ReadInt32();
                    registro.Dato = reader.ReadChars(10);
                    registro.Siguiente = reader.ReadInt64();
                    reader.Close();
                    Arbol.Close();
                }

            }
            return registro;
        }
        private NodoArbol getNodoArbol(long Direccion)
        {
            NodoArbol nodo = new NodoArbol(OrdenArbol);
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Arbol = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read);
                if (Arbol != null)
                {
                    BinaryReader reader = new BinaryReader(Arbol);
                    reader.BaseStream.Position = Direccion;
                    nodo.DirNodo = reader.ReadInt64();
                    nodo.DirPadre = reader.ReadInt64();
                    nodo.Tipo = reader.ReadChar();
                    List<long> Direcciones = new List<long>();
                    List<int> Claves = new List<int>();

                    for (int i = 0; i < OrdenArbol - 1; i++)
                    {
                        Direcciones.Add(reader.ReadInt64());
                        Claves.Add(reader.ReadInt32());
                    }
                    Direcciones.Add(reader.ReadInt64());
                    nodo.SetListClaves(Claves);
                    nodo.SetListDirecciones(Direcciones);
                    reader.Close();
                    Arbol.Close();

                }

            }
            return nodo;
        }
        public bool AbrirArchivo()
        {
            bool Abierto = false;
            RutaArchivo = "";
            RutaCabecera = "";
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != DialogResult.OK)
                return false;
            RutaArchivo = open.FileName;
            RutaCabecera = GetRutaCab(RutaArchivo);
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Abierto = true;
            }
            return Abierto;
        }
        private string GetRutaCab(string Ruta)
        {
            string Cab = "";
            string[] cad = RutaArchivo.Split('\\');
            for (int i = 0; i < cad.Length - 1; i++)
            {
                Cab += cad[i] + "\\";

            }
            Cab += "Cab.dd";
            MessageBox.Show(Cab);
            return Cab;
        }
        private List<Elemento> getTipoDireccion()
        {
            long Direccion = 24;
            List<Elemento> elementos = new List<Elemento>();
            if (File.Exists(RutaArchivo) && File.Exists(RutaCabecera))
            {
                Cabecera = new FileStream(RutaCabecera, FileMode.Open, FileAccess.Read);
                if (Cabecera != null)
                {
                    BinaryReader reader = new BinaryReader(Cabecera);
                    while (Direccion < Cabecera.Length)
                    {
                        reader.BaseStream.Position = Direccion;
                        Elemento elemento = new Elemento();
                        elemento.DireccionElemento = reader.ReadInt64();
                        elemento.Tipo = reader.ReadChar();
                        elementos.Add(elemento);
                        Direccion += 9;
                    }
                    Cabecera.Close();
                }
            }
            return elementos;
        }

        private void CrearGuardarElemento(object obj, char Tipo, long Dir)
        {
            Elemento elemento = new Elemento(Tipo, obj, Dir);
            GuardarElemento(elemento, GetLegthArchivoCab());
        }

        private void InsertarRegistro(Registro registro)
        {
            long Ultimo = GetUltimoRegistro();
            if (Ultimo == -1)
            {
                CrearGuardarElemento(registro, 'R', registro.Direccion);
                EscribeCabeceraRegistro(registro.Direccion);
                EscribeUltimaRegistroDireccion(registro.Direccion);
            }
            else
            {
                Registro ultimo = getRegistro(GetUltimoRegistro());
                ultimo.Siguiente = registro.Direccion;
                CrearGuardarElemento(registro, 'R', registro.Direccion);
                EscribeUltimaRegistroDireccion(registro.Direccion);
                GuardaRegistro(ultimo);
            }
        }

        #endregion

        #region Operaciones de arbol
        public int InsertarArbol(int Clave, char[] Dato, long DireccionArbol)
        {
            int res = 0;
            NodoArbol nodo = getNodoArbol(DireccionArbol);
            if (nodo.Tipo == 'H')
            {
                if (!nodo.ExisteClave(Clave))
                {
                    Registro nuevoRegistro = new Registro(GetLegthArchivo(), Clave, Dato);
                    InsertarRegistro(nuevoRegistro);
                    nodo.Insertar(Clave, nuevoRegistro.Direccion);
                    if (nodo.IsOverFlow())
                    {
                        Dividir(nodo);
                    }
                    else
                    {
                        GuardaNodo(nodo);
                    }
                    res = 1;
                }
                else
                {
                    res = 2;
                }
            }
            else
            {

                int indice = GetPosicion(nodo.Claves, Clave);
                res = InsertarArbol(Clave, Dato, nodo.Direcciones[indice]);
            }
            return res;

        }


        private void Dividir(NodoArbol nodo)
        {
            if (nodo.Tipo == 'H' && nodo.DirPadre == -1)
            {
                //MessageBox.Show("Entre");
                NodoArbol nuevo = DividirHoja(nodo);
                CrearRaiz(nodo, nuevo);
            }
            else if (nodo.Tipo == 'H' && nodo.DirPadre != -1)
            {
                NodoArbol nuevo = DividirHoja(nodo);
                ElevarIndice(nodo, nuevo);
            }
            else if (nodo.DirPadre == -1)
            {
                int clave = GetValorNuevaRaiz(nodo.Claves);
                NodoArbol nuevo = DividirRaizIntermedio(nodo);
                CrearRaiz(nodo, nuevo, clave);
            }
            else if (nodo.DirPadre != -1)
            {
                int clave = GetValorNuevaRaiz(nodo.Claves);
                NodoArbol nuevo = DividirRaizIntermedio(nodo);
                ElevarIndice(nodo, nuevo, clave);
            }


        }

        private NodoArbol DividirHoja(NodoArbol nodo)
        {
            int iDivisor = ((OrdenArbol - 1) / 2);

            List<int> ClavesMayores = nodo.Claves.GetRange(iDivisor, nodo.Claves.Count - iDivisor);
            List<long> DireccionesMayores = nodo.Direcciones.GetRange(iDivisor, nodo.Direcciones.Count - iDivisor);

            nodo.Claves.RemoveRange(iDivisor, nodo.Claves.Count - iDivisor);
            nodo.Direcciones.RemoveRange(iDivisor, nodo.Direcciones.Count - iDivisor);

            NodoArbol nuevo = new NodoArbol(GetLegthArchivo(), 'H', OrdenArbol);
            nuevo.Claves = ClavesMayores;
            nuevo.Direcciones = DireccionesMayores;

            CrearGuardarElemento(nuevo, 'T', nuevo.DirNodo);
            GuardaNodo(nodo);

            return nuevo;
        }

        //Posicion 0 nuevo
        //Posicion 1 anterior
        public NodoArbol DividirRaizIntermedio(NodoArbol nodo)
        {

            int iDivisor = ((OrdenArbol - 1) / 2);
            int iDivisorDireccion = nodo.Direcciones.Count / 2;

            List<int> ClavesMayores = nodo.Claves.GetRange(iDivisor, nodo.Claves.Count - iDivisor);
            List<long> DireccionesMayores = nodo.Direcciones.GetRange(iDivisorDireccion, nodo.Direcciones.Count - iDivisorDireccion);

            ClavesMayores.RemoveAt(0);

            nodo.Claves.RemoveRange(iDivisor, nodo.Claves.Count - iDivisor);
            nodo.Direcciones.RemoveRange(iDivisorDireccion, nodo.Direcciones.Count - iDivisorDireccion);

            NodoArbol nuevo = new NodoArbol(GetLegthArchivo(), 'I', OrdenArbol);
            nuevo.Claves = ClavesMayores;
            nuevo.Direcciones = DireccionesMayores;
            nodo.Tipo = 'I';

            CrearGuardarElemento(nuevo, 'T', nuevo.DirNodo);
            GuardaNodo(nodo);

            for (int i = 0; i < DireccionesMayores.Count; i++)
            {
                NodoArbol n = getNodoArbol(DireccionesMayores[i]);
                n.DirPadre = nuevo.DirNodo;
                GuardaNodo(n);
            }
            return nuevo;
        }


        private void CrearRaiz(NodoArbol Menor, NodoArbol Mayor)
        {
            NodoArbol nuevo = new NodoArbol(GetLegthArchivo(), 'R', OrdenArbol);
            nuevo.Claves.Add(Mayor.Claves[0]);
            nuevo.Direcciones.Add(Menor.DirNodo);
            nuevo.Direcciones.Add(Mayor.DirNodo);
            Menor.DirPadre = nuevo.DirNodo;
            Mayor.DirPadre = nuevo.DirNodo;
            GuardaNodo(Menor);
            GuardaNodo(Mayor);
            CrearGuardarElemento(nuevo, 'T', GetLegthArchivo());
            EscribeRaizDireccion(nuevo.DirNodo);
        }


        private void CrearRaiz(NodoArbol Menor, NodoArbol Mayor, int Clave)
        {
            NodoArbol nuevo = new NodoArbol(GetLegthArchivo(), 'R', OrdenArbol);
            nuevo.Claves.Add(Clave);
            nuevo.Direcciones.Add(Menor.DirNodo);
            nuevo.Direcciones.Add(Mayor.DirNodo);
            Menor.DirPadre = nuevo.DirNodo;
            Mayor.DirPadre = nuevo.DirNodo;
            GuardaNodo(Menor);
            GuardaNodo(Mayor);
            CrearGuardarElemento(nuevo, 'T', GetLegthArchivo());
            EscribeRaizDireccion(nuevo.DirNodo);
        }



        private void ElevarIndice(NodoArbol Menor, NodoArbol Mayor)
        {
            NodoArbol Padre = getNodoArbol(Menor.DirPadre);
            Mayor.DirPadre = Padre.DirNodo;
            Padre.Insertar(Mayor.Claves[0], Mayor.DirNodo);
            GuardaNodo(Menor);
            GuardaNodo(Mayor);
            GuardaNodo(Padre);
            if (Padre.IsOverFlow())
            {
                Dividir(Padre);
            }

        }

        private void ElevarIndice(NodoArbol Menor, NodoArbol Mayor, int Clave)
        {
            NodoArbol Padre = getNodoArbol(Menor.DirPadre);
            Mayor.DirPadre = Padre.DirNodo;
            Padre.Insertar(Clave, Mayor.DirNodo);
            GuardaNodo(Menor);
            GuardaNodo(Mayor);
            GuardaNodo(Padre);
            if (Padre.IsOverFlow())
            {
                Dividir(Padre);
            }

        }


        private int GetPosicion(List<int> Claves, int Clave)
        {
            int Indice = 0;
            int Final = Claves.Count;
            if (Claves[Final - 1] < Clave)
            {
                return (Final);
            }
            else
            {
                for (int i = 0; i < Claves.Count; i++)
                {
                    if (Clave < Claves[i])
                    {
                        Indice = i;
                        break;
                    }
                }

            }
            return Indice;
        }


        public int GetValorNuevaRaiz(List<int> Claves)
        {
            return (Claves[(Claves.Count - 1) / 2]);
        }
        #endregion




    }
}
