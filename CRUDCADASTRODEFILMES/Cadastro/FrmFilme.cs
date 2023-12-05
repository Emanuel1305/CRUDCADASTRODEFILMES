using CRUDCADASTRODEFILMES.Cadastro.BLL;
using CRUDCADASTRODEFILMES.Cadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDCADASTRODEFILMES.Cadastro.DAL;
using MySql.Data.MySqlClient;
using System.Drawing.Configuration;

namespace CRUDCADASTRODEFILMES.Cadastro
{
    public partial class FrmFilme : Form
    {
        //Variaveis
        string poster;
        string auterouimagem = "nao";

        public FrmFilme()
        {
            InitializeComponent();
        }

        //Sempre que carregar o formulario
        private void FrmFilme_Load(object sender, EventArgs e)
        {
            LimparPoster();

            //Desativa ou ativa botôes
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnExibir.Enabled = true;
            btnCancelar.Enabled = false;
        }

        //-------------------------MÉTODOS-------------------------------

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

            //reseta a data para seu número padrão
            dtLancamento.ResetText();

            cbGenero.SelectedIndex = -1;

            //altera a cor dos campos
            txtTitulo.BackColor = Color.White;
            cbGenero.BackColor = Color.White;

            //chama o método que carrega a imagem padrão
            LimparPoster();
        }

        //Método para listar os filmes no grid
        private void Listar()
        {
            //instância um objeto do tipo FilmeBLL
            FilmeBLL filmesBLL = new FilmeBLL();

            try
            {
                //traz os dados do BD para o Data Grid View
                dgvFilmes.DataSource = filmesBLL.Listar();

                //renomear coluna
                dgvFilmes.Columns[0].HeaderText = "ID";
                dgvFilmes.Columns[1].HeaderText = "Título";
                dgvFilmes.Columns[2].HeaderText = "Lançamento";
                dgvFilmes.Columns[3].HeaderText = "Genero";
                dgvFilmes.Columns[4].HeaderText = "Produtora";
                dgvFilmes.Columns[5].HeaderText = "Diretor";
                dgvFilmes.Columns[6].HeaderText = "Duração";

                //Ocutar Coluna
                dgvFilmes.Columns[7].Visible = false;

                //Ajuste largura das colunas
                dgvFilmes.Columns[0].Width = 45;
                dgvFilmes.Columns[1].Width = 165;
                dgvFilmes.Columns[2].Width = 100;
                dgvFilmes.Columns[3].Width = 120;
                dgvFilmes.Columns[4].Width = 113;
                dgvFilmes.Columns[5].Width = 90;
                dgvFilmes.Columns[6].Width = 90;

            }
            catch (Exception erro)
            {
                //Imprime uma mensagem de erro
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //retorna o erro
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

        //Método para editar/alterar
        public void Alterar(Filme filme)
        {
            FilmeBLL filmeBLL = new FilmeBLL();

            try
            {
                //Verifica se o titulo possui pelo menos 1 caracter ou se está vazio
                if (txtTitulo.Text.Trim() == string.Empty || txtTitulo.Text.Trim().Length < 2)
                {
                    MessageBox.Show("O campo TITULO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //destaca o campo a ser alterado
                    txtTitulo.BackColor = Color.LightCoral;
                    cbGenero.BackColor = Color.White;
                }
                //verifica se o campo gênero está prenchido
                else if (cbGenero.Text == String.Empty)
                {
                    MessageBox.Show("O campo GÊNERO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTitulo.BackColor = Color.White;
                    cbGenero.BackColor = Color.LightCoral;
                }
                //realiza as conversões necessárias e armazena no objeto "filme"
                else
                {
                    filme.Id = Convert.ToInt32(txtCodigo.Text);
                    filme.Titulo = txtTitulo.Text;
                    filme.Lancamento = dtLancamento.Text;
                    mtbDuracao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                    filme.Duracao = mtbDuracao.Text;
                    filme.Produtora = txtProdutora.Text;
                    filme.Diretor = txtDiretor.Text;
                    filme.Genero = cbGenero.Text;
                    filme.Poster = poster;
                    filme.auterouimagem = auterouimagem;

                    //chama o método alterar
                    filmeBLL.Alterar(filme);

                    MessageBox.Show("Cadastro alterado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    Listar();
                }
            }
            catch (Exception erro)
            {
                //Imprime uma mensagem de erro
                MessageBox.Show("Erro ao alterar os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para salvar filme
        private void Salvar(Filme filme)
        {
            FilmeBLL filmeBLL = new FilmeBLL();

            if (txtTitulo.Text.Trim() == string.Empty || txtTitulo.Text.Trim().Length < 2)
            {
                MessageBox.Show("O campo TITULO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.LightCoral;
                cbGenero.BackColor = Color.White;
            }
            else if (cbGenero.Text == String.Empty)
            {
                MessageBox.Show("O campo GÊNERO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.White;
                cbGenero.BackColor = Color.LightCoral;
            }
            else
            {
                filme.Titulo = txtTitulo.Text;
                filme.Lancamento = dtLancamento.Text;
                mtbDuracao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                filme.Duracao = mtbDuracao.Text;
                filme.Produtora = txtProdutora.Text;
                filme.Diretor = txtDiretor.Text;
                filme.Genero = cbGenero.Text;
                filme.Poster = poster;

                filmeBLL.Salvar(filme);
                MessageBox.Show("Cadastro Reaizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar();
                Listar();
            }
        }

        //-------------------------AÇÕES AO CLICAR-------------------------------

        //Exibir
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        //Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            Salvar(filme);
        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            Alterar(filme);

        }

        //Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            Excluir(filme);
        }

        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnExibir.Enabled = true;
            btnCancelar.Enabled = false;
            Limpar();
        }

        //Carregar Imagem
        private void btnPoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All (*.jpg; *.png) | *.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                poster = dialog.FileName.ToString();
                pbPoster.ImageLocation = poster;
            }
            auterouimagem = "sim";
        }

        //Puxar Dados Do Grid View Para Editar
        private void dgvFilmes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnExibir.Enabled = false;
            btnCancelar.Enabled = true;

            if (e.RowIndex > -1)
            {
                txtCodigo.Text = dgvFilmes.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgvFilmes.CurrentRow.Cells[1].Value.ToString();
                dtLancamento.Text = dgvFilmes.CurrentRow.Cells[2].Value.ToString();
                cbGenero.Text = dgvFilmes.CurrentRow.Cells[3].Value.ToString();
                txtProdutora.Text = dgvFilmes.CurrentRow.Cells[4].Value.ToString();
                txtDiretor.Text = dgvFilmes.CurrentRow.Cells[5].Value.ToString();
                mtbDuracao.Text = dgvFilmes.CurrentRow.Cells[6].Value.ToString();

                if (dgvFilmes.CurrentRow.Cells[7].Value != DBNull.Value)
                {
                    byte[] poster = (byte[])dgvFilmes.Rows[e.RowIndex].Cells[7].Value;
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
