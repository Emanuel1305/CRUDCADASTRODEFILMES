using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CRUDCADASTRODEFILMES.Cadastro.DAL;
using MySqlX.XDevAPI.Relational;

namespace CRUDCADASTRODEFILMES.login
{
    public partial class FrmLogin : Form
    {
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        MySqlConnection con = new MySqlConnection("SERVER=localhost; DATABASE=cadastros; UID=root; PWD=bdemanuel");

        public bool logado = false;
        private void Logar()
        {
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE user_login = @usuario AND user_senha = @senha", con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                con.Open();
                int i = Convert.ToInt32(cmd.ExecuteScalar());

                if (i > 0)
                {
                    logado = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou Senha Inválido!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Clear();
                    txtSenha.Clear();

                    logado = false;
                }
            }
            catch (MySqlException erro )
            {
                MessageBox.Show("Erro ao logar!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Informe o Usuário!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                txtUsuario.BackColor = Color.LightCoral;
                txtSenha.BackColor = Color.White;
            }
            else if (txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Informe a Senha!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtUsuario.BackColor = Color.White;
                txtSenha.BackColor = Color.LightCoral;
            }
            else
            {
                txtUsuario.BackColor = Color.White;
                txtSenha.BackColor = Color.White;
                Logar();
            }
            
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }
    }
}
