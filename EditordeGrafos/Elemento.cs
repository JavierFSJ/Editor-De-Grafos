using System.IO;

namespace EditordeGrafos
{
    public class Elemento
    {
        public long DireccionElemento { get; set; }
        public char Tipo { get; set; }
        public object Dato { get; set; }


        public Elemento(char Tipo, object Dato, long DireccionElemento)
        {
            this.Tipo = Tipo;
            this.Dato = Dato;
            this.DireccionElemento = DireccionElemento;
        }

        public Elemento() { }

        public void GuardaTipo(BinaryWriter writer, long direccion)
        {
            writer.BaseStream.Position = direccion;
            writer.Write(DireccionElemento);
            writer.Write(Tipo);
            writer.Flush();
            writer.Close();
        }
    }
}
