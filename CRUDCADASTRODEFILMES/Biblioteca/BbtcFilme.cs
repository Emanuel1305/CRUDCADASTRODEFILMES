using CRUDCADASTRODEFILMES.Cadastro.BLL;
using CRUDCADASTRODEFILMES.Cadastro.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDCADASTRODEFILMES.Biblioteca
{
    public partial class BbtcFilme : Form
    {
 
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
            txtDiretor.Clear();
            txtProdutora.Clear();
            txtCodigo.Clear();
            mtbDuracao.Clear();
            mtbLancamento.Clear();
            txtGenero.Clear();

            //chama o método que carrega a imagem padrão
            LimparPoster();
        }
        public BbtcFilme()
        {
            InitializeComponent();
        }
        //Método para listar os filmes no grid
        private void Listar()
        {
            //instância um objeto do tipo FilmeBLL
            FilmeBLL filmesBLL = new FilmeBLL();

            try
            {
                //traz os dados do BD para o Data Grid View
                dgvFilme.DataSource = filmesBLL.Listar();

                //renomear coluna
                dgvFilme.Columns[0].HeaderText = "ID";
                dgvFilme.Columns[1].HeaderText = "Título";
                dgvFilme.Columns[2].HeaderText = "Lançamento";
                dgvFilme.Columns[3].HeaderText = "Genero";
                dgvFilme.Columns[4].HeaderText = "Produtora";
                dgvFilme.Columns[5].HeaderText = "Diretor";
                dgvFilme.Columns[6].HeaderText = "Duração";

                //Ocutar Coluna
                dgvFilme.Columns[7].Visible = false;

                //Ajuste largura das colunas
                dgvFilme.Columns[0].Width = 45;
                dgvFilme.Columns[1].Width = 165;
                dgvFilme.Columns[2].Width = 100;
                dgvFilme.Columns[3].Width = 120;
                dgvFilme.Columns[4].Width = 113;
                dgvFilme.Columns[5].Width = 90;
                dgvFilme.Columns[6].Width = 90;

            }
            catch (Exception erro)
            {
                //Imprime uma mensagem de erro
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //retorna o erro
                throw erro;
            }
        }
        //Método para buscar filme
        private void Buscar()
        {
            try
            {
                FilmeBLL filmesBLL = new FilmeBLL();
                dt = filmesBLL.GetFilme(txtPesquisa.Text);
                dgvFilme.DataSource = dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Método para Excluir
        private void Excluir(Filme filme)
        {
            FilmeBLL filmeBLL = new FilmeBLL();

            //Verifica se há realmete um cadastro a excluir
            if (txtCodigo.Text == string.Empty)
            {
                MessageBox.Show("Selecione um CADASTRO para ser excluido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //pede uma confirmação de exclusão ao usuário
            else if (MessageBox.Show("Deseja realmente exluir o cadastro selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //converte o id em int
                filme.Id = Convert.ToInt32(txtCodigo.Text);

                //chama o método excluir
                filmeBLL.Excluir(filme);

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
                FilmeBLL filmesBLL = new FilmeBLL();
                dt = filmesBLL.FiltrarFilme(cbFiltrar.Text);
                dgvFilme.DataSource = dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void BbtcFilme_Load(object sender, EventArgs e)
        {
            Listar();
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
            Cadastro.FrmFilme frmFilme = new Cadastro.FrmFilme();
            frmFilme.Show();
            Listar();
        }
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            Excluir(filme);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            Listar();
        }

        private void dgvFilmes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lbTitulo.Text = dgvFilme.CurrentRow.Cells[1].Value.ToString();
                txtCodigo.Text = dgvFilme.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgvFilme.CurrentRow.Cells[1].Value.ToString();
                mtbLancamento.Text = dgvFilme.CurrentRow.Cells[2].Value.ToString();
                txtGenero.Text = dgvFilme.CurrentRow.Cells[3].Value.ToString();
                txtProdutora.Text = dgvFilme.CurrentRow.Cells[4].Value.ToString();
                txtDiretor.Text = dgvFilme.CurrentRow.Cells[5].Value.ToString();
                mtbDuracao.Text = dgvFilme.CurrentRow.Cells[6].Value.ToString();

                if (dgvFilme.CurrentRow.Cells[7].Value != DBNull.Value)
                {
                    byte[] poster = (byte[])dgvFilme.Rows[e.RowIndex].Cells[7].Value;
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
    }
}
