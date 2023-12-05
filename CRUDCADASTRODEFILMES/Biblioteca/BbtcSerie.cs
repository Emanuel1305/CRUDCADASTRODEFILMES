using CRUDCADASTRODEFILMES.Cadastro.BLL;
using CRUDCADASTRODEFILMES.Cadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDCADASTRODEFILMES.Biblioteca
{
    public partial class BbtcSerie : Form
    {
        public BbtcSerie()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        string poster;

        //Método Limpar Poster
        void LimparPoster()
        {
            pbPoster.Image = Properties.Resources.poster;
            poster = "img/poster.PNG"; //busca o local da imagem padrão
        }

        //Método Limpar
        public void Limpar()
        {
            txtTitulo.Clear();
            txtEpisodios.Clear();
            txtProdutora.Clear();
            txtCodigo.Clear();
            txtTemporadas.Clear();
            mtbLancamento.Clear();
            txtGenero.Clear();

            //chama o método que carrega a imagem padrão
            LimparPoster();
        }
        //Método para listar os series no grid
        private void Listar()
        {
            //instância um objeto do tipo FilmeBLL
            SerieBLL serieBLL = new SerieBLL();

            try
            {
                //traz os dados do BD para o Data Grid View
                dgvSerie.DataSource = serieBLL.Listar();

                //renomear coluna
                dgvSerie.Columns[0].HeaderText = "ID";
                dgvSerie.Columns[1].HeaderText = "Título";
                dgvSerie.Columns[2].HeaderText = "Lançamento";
                dgvSerie.Columns[3].HeaderText = "Genero";
                dgvSerie.Columns[4].HeaderText = "Produtora";
                dgvSerie.Columns[5].HeaderText = "Episódios";
                dgvSerie.Columns[6].HeaderText = "Temporadas";

                //Ocutar Coluna
                dgvSerie.Columns[7].Visible = false;

                //Ajuste largura das colunas
                dgvSerie.Columns[0].Width = 45;
                dgvSerie.Columns[1].Width = 165;
                dgvSerie.Columns[2].Width = 100;
                dgvSerie.Columns[3].Width = 120;
                dgvSerie.Columns[4].Width = 113;
                dgvSerie.Columns[5].Width = 90;
                dgvSerie.Columns[6].Width = 90;

            }
            catch (Exception erro)
            {
                //Imprime uma mensagem de erro
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //retorna o erro
                throw erro;
            }
        }
        //Método para buscar serie
        private void Buscar()
        {
            try
            {
                SerieBLL serieBLL = new SerieBLL();
                dt = serieBLL.GetSerie(txtPesquisa.Text);
                dgvSerie.DataSource = dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Método para Excluir
        private void Excluir(Serie serie)
        {
            SerieBLL serieBLL = new SerieBLL();

            //Verifica se há realmete um cadastro a excluir
            if (txtCodigo.Text == string.Empty)
            {
                MessageBox.Show("Selecione um CADASTRO para ser excluido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //pede uma confirmação de exclusão ao usuário
            else if (MessageBox.Show("Deseja realmente exluir o cadastro selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //converte o id em int
                serie.Id = Convert.ToInt32(txtCodigo.Text);

                //chama o método excluir
                serieBLL.Excluir(serie);

                //retorna uma mensagem ao usuário
                MessageBox.Show("Excluido com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpa os campos e reseta o Grid View
                Limpar();
                Listar();
            }
        }

        //Método para filtrar
        private void Filtrar()
        {
            try
            {
                SerieBLL serieBLL = new SerieBLL();
                dt = serieBLL.FiltrarSerie(cbFiltrar.Text);
                dgvSerie.DataSource = dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Buscar();
            txtPesquisa.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
            cbFiltrar.SelectedIndex = -1;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Cadastro.FrmSerie frmSerie = new Cadastro.FrmSerie();
            frmSerie.Show();
            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            Excluir(serie);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            Listar();
        }

        private void dgvSerie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lbTitulo.Text = dgvSerie.CurrentRow.Cells[1].Value.ToString();
                txtCodigo.Text = dgvSerie.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgvSerie.CurrentRow.Cells[1].Value.ToString();
                mtbLancamento.Text = dgvSerie.CurrentRow.Cells[2].Value.ToString();
                txtGenero.Text = dgvSerie.CurrentRow.Cells[3].Value.ToString();
                txtProdutora.Text = dgvSerie.CurrentRow.Cells[4].Value.ToString();
                txtEpisodios.Text = dgvSerie.CurrentRow.Cells[5].Value.ToString();
                txtTemporadas.Text = dgvSerie.CurrentRow.Cells[6].Value.ToString();

                if (dgvSerie.CurrentRow.Cells[7].Value != DBNull.Value)
                {
                    byte[] poster = (byte[])dgvSerie.Rows[e.RowIndex].Cells[7].Value;
                    MemoryStream ms = new MemoryStream(poster);

                    pbPoster.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    pbPoster.Image = Properties.Resources.poster;
                }
            }
            else
            {
                return;
            }
        }

        private void BbtcSerie_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
