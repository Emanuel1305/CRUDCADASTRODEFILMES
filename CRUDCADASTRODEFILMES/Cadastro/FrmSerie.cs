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

namespace CRUDCADASTRODEFILMES.Cadastro
{
    public partial class FrmSerie : Form
    {
        //Variaveis
        string poster;
        string auterouimagem = "nao";

        public FrmSerie()
        {
            InitializeComponent();
        }

        //Sempre que carregar o formulario
        private void FrmSerie_Load_1(object sender, EventArgs e)
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
            txtProdutora.Clear();
            txtCodigo.Clear();
            txtEpisodios.Clear();
            txtTemporadas.Clear();

            //reseta a data para seu número padrão
            dtLancamento.ResetText();

            cbGenero.SelectedIndex = -1;

            //altera a cor dos campos
            txtTitulo.BackColor = Color.White;
            cbGenero.BackColor = Color.White;
            txtEpisodios.BackColor = Color.White;
            txtTemporadas.BackColor = Color.White;

            //chama o método que carrega a imagem padrão
            LimparPoster();
        }

        //Método para listar os filmes no grid
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

        //Método para editar/alterar
        public void Alterar(Serie serie)
        {
            SerieBLL serieBLL = new SerieBLL();

            try
            {
                //Verifica se o titulo possui pelo menos 1 caracter ou se está vazio
                if (txtTitulo.Text.Trim() == string.Empty || txtTitulo.Text.Trim().Length < 2)
                {
                    MessageBox.Show("O campo TITULO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //destaca o campo a ser alterado
                    txtTitulo.BackColor = Color.LightCoral;
                    cbGenero.BackColor = Color.White;
                    txtEpisodios.BackColor = Color.White;
                    txtTemporadas.BackColor = Color.White;
                }
                //verifica se o campo gênero está prenchido
                else if (cbGenero.Text == String.Empty)
                {
                    MessageBox.Show("O campo GÊNERO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTitulo.BackColor = Color.White;
                    cbGenero.BackColor = Color.LightCoral;
                    txtEpisodios.BackColor = Color.White;
                    txtTemporadas.BackColor = Color.White;
                }
                else if (txtEpisodios.Text.Trim() == string.Empty || txtEpisodios.Text.Trim().Length < 1)
                {
                    MessageBox.Show("O campo EPISÓDIOS não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTitulo.BackColor = Color.White;
                    cbGenero.BackColor = Color.White;
                    txtEpisodios.BackColor = Color.LightCoral;
                    txtTemporadas.BackColor = Color.White;
                }
                else if (txtTemporadas.Text.Trim() == string.Empty || txtTemporadas.Text.Trim().Length < 1)
                {
                    MessageBox.Show("O campo TEMPORADAS não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTitulo.BackColor = Color.White;
                    cbGenero.BackColor = Color.White;
                    txtEpisodios.BackColor = Color.White;
                    txtTemporadas.BackColor = Color.LightCoral;
                }
                //realiza as conversões necessárias e armazena no objeto "filme"
                else
                {
                    serie.Id = Convert.ToInt32(txtCodigo.Text);
                    serie.Titulo = txtTitulo.Text;
                    serie.Lancamento = dtLancamento.Text;
                    serie.Produtora = txtProdutora.Text;
                    serie.Genero = cbGenero.Text;
                    serie.Episodios = txtEpisodios.Text;
                    serie.Temporadas = txtTemporadas.Text;
                    serie.Poster = poster;
                    serie.auterouimagem = auterouimagem;

                    //chama o método alterar
                    serieBLL.Alterar(serie);

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

        //Método para salvar série
        private void Salvar(Serie serie)
        {
            SerieBLL serieBLL = new SerieBLL();

            if (txtTitulo.Text.Trim() == string.Empty || txtTitulo.Text.Trim().Length < 2)
            {
                MessageBox.Show("O campo TITULO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.LightCoral;
                cbGenero.BackColor = Color.White;
                txtEpisodios.BackColor = Color.White;
                txtTemporadas.BackColor = Color.White;
            }
            else if (cbGenero.Text == String.Empty)
            {
                MessageBox.Show("O campo GÊNERO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.White;
                cbGenero.BackColor = Color.LightCoral;
                txtEpisodios.BackColor = Color.White;
                txtTemporadas.BackColor = Color.White;
            }
            else if (txtEpisodios.Text.Trim() == string.Empty || txtEpisodios.Text.Trim().Length < 1)
            {
                MessageBox.Show("O campo EPISÓDIOS não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.White;
                cbGenero.BackColor = Color.White;
                txtEpisodios.BackColor = Color.LightCoral;
                txtTemporadas.BackColor = Color.White;
            }
            else if (txtTemporadas.Text.Trim() == string.Empty || txtTemporadas.Text.Trim().Length < 1)
            {
                MessageBox.Show("O campo TEMPORADAS não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.BackColor = Color.White;
                cbGenero.BackColor = Color.White;
                txtEpisodios.BackColor = Color.White;
                txtTemporadas.BackColor = Color.LightCoral;
            }
            else
            {
                serie.Titulo = txtTitulo.Text;
                serie.Lancamento = dtLancamento.Text;
                serie.Produtora = txtProdutora.Text;
                serie.Genero = cbGenero.Text;
                serie.Episodios = txtEpisodios.Text;
                serie.Temporadas = txtTemporadas.Text;
                serie.Poster = poster;

                serieBLL.Salvar(serie);
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
            Serie serie = new Serie();
            Salvar(serie);
        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            Alterar(serie);
        }

        //Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            Excluir(serie);
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
        private void dgvSerie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnExibir.Enabled = false;
            btnCancelar.Enabled = true;

            if (e.RowIndex > -1)
            {
                txtCodigo.Text = dgvSerie.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgvSerie.CurrentRow.Cells[1].Value.ToString();
                dtLancamento.Text = dgvSerie.CurrentRow.Cells[2].Value.ToString();
                cbGenero.Text = dgvSerie.CurrentRow.Cells[3].Value.ToString();
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
    }
}
