using RegistroBiblicoConReporte.BLL;
using RegistroBiblicoConReporte.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroBiblicoConReporte.UI.Registros
{
    public partial class rLibros : Form
    {
        public rLibros()
        {
            InitializeComponent();
        }

        private Libros LlenaClase()
        {
            Libros libro = new Libros();

            libro.LibroId = Convert.ToInt32(LibroId_numericUpDown.Value);
            libro.TipoId = Convert.ToInt32(TipoId_numericUpDown.Value);
            libro.Fecha = FechadateTimePicker.Value;
            libro.Siglas = Siglas_textBox.Text;
            libro.Descripcion = Descripcion_textBox.Text;

            return libro;
        }

        private bool Validar(int valida)
        {
            bool paso = false;
            if (valida == 1 && TipoId_numericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(TipoId_numericUpDown, "Digite un ID");
                paso = true;
            }
            if (valida == 2 && LibroId_numericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(LibroId_numericUpDown, "Digite un ID");
                paso = true;
            }
            if (valida == 2 && Siglas_textBox.Text == string.Empty)
            {
                GeneralerrorProvider.SetError(Siglas_textBox, "Digite una sigla");
                paso = true;
            }
            if (valida == 2 && Descripcion_textBox.Text == string.Empty)
            {
                GeneralerrorProvider.SetError(Descripcion_textBox, "Digite una Descripcion");
                paso = true;
            }
            return paso;
        }

        private void LimpiarCampos()
        {
            LibroId_numericUpDown.Value = 0;
            TipoId_numericUpDown.Value = 0;
            Descripcion_textBox.Clear();
            Siglas_textBox.Clear();
            GeneralerrorProvider.Clear();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }
            int id = Convert.ToInt32(TipoId_numericUpDown.Value);
            Libros libro = LibrosBLL.Buscar(id);

            if (libro != null)
            {
                LibroId_numericUpDown.Value = libro.LibroId;
                Descripcion_textBox.Text = libro.Descripcion;
                Siglas_textBox.Text = libro.Siglas;
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("LLenar los campos marcados");
                return;
            }
            bool paso = false;

            if (TipoId_numericUpDown.Value == 0)
                paso = LibrosBLL.Guardar(LlenaClase());
            else
                paso = LibrosBLL.Modificar(LlenaClase());

            if (paso)
            {
                LimpiarCampos();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingresar un ID");
                return;
            }
            int id = Convert.ToInt32(TipoId_numericUpDown.Value);

            if (LibrosBLL.Eliminar(id))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado!!", "Exito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
