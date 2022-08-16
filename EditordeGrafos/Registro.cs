using System.IO;


namespace EditordeGrafos
{
    public class Registro
    {
        public long Direccion { get; set; }
        public int Clave { get; set; }
        public char[] Dato { get; set; }
        public long Siguiente { get; set; }



        public Registro() { }
        public Registro(long Direccion, int Clave, char[] dato)
        {
            this.Direccion = Direccion;
            this.Clave = Clave;
            this.Dato = dato;
            this.Siguiente = -1;
            
        }
        public string GetDatoString()
        {
            string Cadena = "";
            for (int i = 0; i < 10; i++)
            {
                Cadena += Dato[i];
            }
            return Cadena;
        }
        public void GuardaRegistro(BinaryWriter writer)
        {
            writer.BaseStream.Position = Direccion;
            writer.Write(Direccion);
            writer.Write(Clave);
            writer.Write(Dato);
            writer.Write(Siguiente);
            writer.Flush();
        }
    }
}
