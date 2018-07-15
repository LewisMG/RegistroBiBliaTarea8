using RegistroBiblicoConReporte.BLL;
using RegistroBiblicoConReporte.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroBiblicoConReporte.UI.Consultas
{
    public partial class cLibros : Form
    {
        public cLibros()
        {
            InitializeComponent();
        }

        private void cLibros_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Libros, bool>> filtro = p => true;

            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://Libro ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.LibroId == id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 1://Tipo ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.TipoId == id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2://Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3://Siglas
                    filtro = x => x.Siglas.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }
            ConsultadataGridView.DataSource = LibrosBLL.GetList(filtro);
        }
    }
}
