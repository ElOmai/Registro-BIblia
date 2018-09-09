using RegistroBiblia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroBiblia.UI.Registros
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private Biblia LLenaClase()
        {
            Biblia Libro = new Biblia
            {
                LibroId = Convert.ToInt32(IdnumericUpDown.Value),
                Fecha = FechadateTimePicker.Value,
                Descripcion = DescripciontextBox.Text,
                Siglas = SiglastextBox.Text,
                TipoID = Convert.ToInt32(TipoIDNumericUpDown.Value)
            };
            ;

            return Libro;
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "llenar el campo de descripcion");
                return false;
            }
            if (string.IsNullOrEmpty(SiglastextBox.Text))
            {
                errorProvider.SetError(SiglastextBox, "llenar el campo de siglas");
                return false;
            }
           
            return true;
        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Biblia Libro = RegistroBiblia.BLL.BibliaBLL.Buscar(id);

            if (Libro != null)
            {
                FechadateTimePicker.Value = Libro.Fecha;
                DescripciontextBox.Text = Libro.Descripcion;
                SiglastextBox.Text = Libro.Siglas;
                TipoIDNumericUpDown.Value = Libro.TipoID;
            }
            else
            {
                MessageBox.Show("no se encontro", "buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {
                MessageBox.Show("llenar el campo vacio", "trate de guardar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Biblia Libro = LLenaClase();
                bool paso = false;

                if (IdnumericUpDown.Value == 0)
                {
                    paso = RegistroBiblia.BLL.BibliaBLL.Guardar(Libro);
                }
                else
                {
                    paso = BLL.BibliaBLL.Modificar(Libro);
                }

                if (paso)
                {
                    MessageBox.Show("Se ha guardado", "aceptado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            DescripciontextBox.Clear();
            SiglastextBox.Clear();
            TipoIDNumericUpDown.Value =0;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (BLL.BibliaBLL.Eliminar(id))

            {
                MessageBox.Show("eliminado", "exitosamente",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdnumericUpDown.Value = 0;
                FechadateTimePicker.Value = DateTime.Now;
                DescripciontextBox.Clear();
                SiglastextBox.Clear();
                TipoIDNumericUpDown.Value = 0;
            }
            else
            {
                MessageBox.Show("no fue eliminado", "trate de nuevo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            errorProvider.Clear();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
