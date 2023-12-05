using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUDCADASTRODEFILMES.Cadastro.DAL
{
    public class Conexao
    {
        //Propriedades para conectar com banco de dados
        static public string conecta = "SERVER=localhost; DATABASE=cadastros; UID=root; PWD=bdemanuel";

        protected MySqlConnection conexao = null;

        //Método  para conectar ao banco de dados
        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Método para fechar a conexão
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
