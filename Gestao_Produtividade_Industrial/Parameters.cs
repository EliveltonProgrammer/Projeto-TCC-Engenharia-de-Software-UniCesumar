using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Produtividade_Industrial
{
    public partial class Parameters : Form
    {
        public Parameters()
        {
            InitializeComponent();
        }

        private void btnUpdateParameters_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
