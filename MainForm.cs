using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RegistroBiblia
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RegistroDeLibrosBiblicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.Registro r = new UI.Registros.Registro();
            r.Show();
        }

        private void ConsultaDeLibrosBiblicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Consultas.Consulta c = new UI.Consultas.Consulta();
            c.Show();
        }
    }
}
