using CRUDCADASTRODEFILMES.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDCADASTRODEFILMES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuFilmes_Click(object sender, EventArgs e)
        {
            Cadastro.FrmFilme frmFilme = new Cadastro.FrmFilme();
            frmFilme.Show();
        }

        private void MenuSeries_Click(object sender, EventArgs e)
        {
            Cadastro.FrmSerie frmSerie = new Cadastro.FrmSerie();
            frmSerie.Show();
        }

        private void MenuFilmesB_Click(object sender, EventArgs e)
        {
            Biblioteca.BbtcFilme bbtcFilme = new Biblioteca.BbtcFilme();
            bbtcFilme.Show();
        }

        private void MenuSeriesB_Click(object sender, EventArgs e)
        {
            Biblioteca.BbtcSerie bbtcSerie = new Biblioteca.BbtcSerie();
            bbtcSerie.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
