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
    public partial class MatrixWeightcs : Form
    {
        private int[,] m;
        private int size;
        private List<string> n;

        public MatrixWeightcs(int[,] matrix, int s, List<string> node)
        {
            InitializeComponent();
            m = matrix;
            size = s;
            n = node;
        }

        private void MatrixWeightcs_Load(object sender, EventArgs e)
        {
            foreach (string cad in n)
            {
                dtMatrix.Columns.Add(cad, cad);

            }

            for (int i = 0; i < size; i++)
            {
                dtMatrix.Rows.Add();
                for (int M = 0; M < size; M++)
                {

                    dtMatrix.Rows[i].Cells[M].Value = m[i, M].ToString();
                    dtMatrix.Rows[i].HeaderCell.Value = n[i] + "     ";
                    dtMatrix.RowHeadersWidth = 50;
                }
            }
        }

        private void btAcept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
