using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class DijkstraShow : Form
    {
        private int[,] mc;
        private int[,] md;
        private int size;
        private List<string> n;

        public DijkstraShow(int[,] matrix, int[,] matrix2, int s, List<string> node)
        {
            InitializeComponent();
            mc = matrix;
            md = matrix2;
            size = s;
            n = node;
        }

        private void DijkstraShow_Load(object sender, EventArgs e)
        {
            foreach (string cad in n)
            {
                dataMc.Columns.Add(cad, cad);
                datamd.Columns.Add(cad, cad);
            }

            for (int i = 0; i < size; i++)
            {
                dataMc.Rows.Add();
                for (int M = 0; M < size; M++)
                {

                    if (mc[i, M] == 100000)
                    {
                        dataMc.Rows[i].Cells[M].Value = "∞";

                    }
                    else
                    {
                        dataMc.Rows[i].Cells[M].Value = mc[i, M].ToString();
                    }
                    dataMc.Rows[i].HeaderCell.Value = n[i] + "     ";
                    dataMc.RowHeadersWidth = 50;
                }
            }

            for (int i = 0; i < size; i++)
            {
                datamd.Rows.Add();
                for (int M = 0; M < size; M++)
                {

                    datamd.Rows[i].Cells[M].Value = md[i, M].ToString();
                    datamd.Rows[i].HeaderCell.Value = n[i] + "     ";
                    datamd.RowHeadersWidth = 50;
                }
            }
        }
    }
}
