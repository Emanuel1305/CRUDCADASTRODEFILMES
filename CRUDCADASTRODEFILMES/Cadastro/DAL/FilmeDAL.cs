using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUDCADASTRODEFILMES;
using System.Windows.Forms;
using CRUDCADASTRODEFILMES.Cadastro.Model;
using System.IO;
using System.Reflection;

namespace CRUDCADASTRODEFILMES.Cadastro.DAL
{
    public class FilmeDAL : Conexao
    {
        MySqlCommand comando = null;

        //Método para Filtrar
        public DataTable FiltrarFilme(string filtrar = "")
        {
            var dt = new DataTable();

            var sql = "SELECT film_id, film_titulo, film_ano, film_genero, film_produtora, film_diretor, film_duracao, film_poster" +
                " FROM filme";

            if (filtrar != "")
            {
                sql += " WHERE film_genero LIKE '%" + filtrar + "%'";

                try
                {
                    using (var cn = new MySqlConnection(Conexao.conecta))
                    {
                        cn.Open();
                        using (var da = new MySqlDataAdapter(sql, cn))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    FecharConexao();
                }
            }
            return dt;
        }

        //Método para Pesquisar
        public DataTable GetFilme(string proucurar = "")
        {
            var dt = new DataTable();

            var sql = "SELECT film_id, film_titulo, film_ano, film_genero, film_produtora, film_diretor, film_duracao, film_poster" +
                " FROM filme";

            if (proucurar != "")
            {
                sql += " WHERE film_titulo LIKE '%" + proucurar + "%'";

                try
                {
                    using (var cn = new MySqlConnection(Conexao.conecta))
                    {
                        cn.Open();
                        using (var da = new MySqlDataAdapter(sql, cn))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    FecharConexao();
                }
            }
            return dt;
        }

        //Método para Excluir
        public void Excluir(Filme filme)
        {
            try
            {
                //Abre uma conexão com o banco de dados
                AbrirConexao();

                //comando em MySql para deletar dados da tabela
                comando = new MySqlCommand("DELETE FROM filme WHERE film_id = @id", conexao);
                comando.Parameters.AddWithValue("@id", filme.Id);

                //Execulta o comando
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //Fecha a conexão com o banco de dados
                FecharConexao();
            }
        }

        //Método para alterar
        public void Alterar(Filme filme)
        {
            try
            {
                AbrirConexao();

                //Método para ler imagem
                byte[] img()
                {
                    //cria uma variavel do tipo byte para armazenar a imagem
                    byte[] image_byte = null;

                    //verifica se a imagem é nula (Nuca acontece pois foi adicionada uma img padrão)
                    if (filme.Poster == "")
                    {
                        return null;
                    }

                    //Faz as devidas conversões 
                    FileStream fs = new FileStream(filme.Poster, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    image_byte = br.ReadBytes((int)fs.Length);

                    //retorna a imagem 
                    return image_byte;
                }
                //verifica se o usuario mudou o poster
                if (filme.auterouimagem == "sim")
                {
                    AbrirConexao();

                    //Comando para atualizar dados de uma tabela
                    comando = new MySqlCommand("UPDATE filme SET film_titulo = @titulo, film_ano = @ano, " +
                        "film_genero = @genero, film_produtora = @produtora, film_diretor = @diretor, film_duracao = @duracao, " +
                        "film_poster = @poster WHERE film_id = @id", conexao);

                    //passa os valores necessários para cada parâmetro
                    comando.Parameters.AddWithValue("@id", filme.Id);
                    comando.Parameters.AddWithValue("@titulo", filme.Titulo);
                    comando.Parameters.AddWithValue("@ano", DateTime.Parse(filme.Lancamento).ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@genero", filme.Genero);
                    comando.Parameters.AddWithValue("@produtora", filme.Produtora);
                    comando.Parameters.AddWithValue("@diretor", filme.Diretor);
                    comando.Parameters.AddWithValue("@duracao", filme.Duracao);
                    comando.Parameters.AddWithValue("@poster", img()); //utiliza o método img para armazenar a imagem

                }
                //atualiza os dados sem mudar a imagem
                else if (filme.auterouimagem == "nao")
                {
                    comando = new MySqlCommand("UPDATE filme SET film_titulo = @titulo, film_ano = @ano, " +
                        "film_genero = @genero, film_produtora = @produtora, film_diretor = @diretor, film_duracao = @duracao " +
                        "WHERE film_id = @id", conexao);

                    comando.Parameters.AddWithValue("@id", filme.Id);
                    comando.Parameters.AddWithValue("@titulo", filme.Titulo);
                    comando.Parameters.AddWithValue("@ano", DateTime.Parse(filme.Lancamento).ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@genero", filme.Genero);
                    comando.Parameters.AddWithValue("@produtora", filme.Produtora);
                    comando.Parameters.AddWithValue("@diretor", filme.Diretor);
                    comando.Parameters.AddWithValue("@duracao", filme.Duracao);
                }

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }
            
        }

        //método para salvar
        public void Salvar(Filme filme)
        {
            byte[] img()
            {
                byte[] image_byte = null;
                if (filme.Poster == "")
                {
                    return null;
                }

                FileStream fs = new FileStream(filme.Poster, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                image_byte = br.ReadBytes((int)fs.Length);
                return image_byte;
            }
            
            try
            {
                AbrirConexao();

                //comando para inserir dados no banco de dados
                comando = new MySqlCommand("INSERT INTO filme (film_titulo, film_ano, film_produtora, film_diretor, film_duracao ," +
                    "film_genero, film_poster) VALUES (@titulo,  @ano, @produtora, @diretor, " +
                    "@duracao, @genero, @poster)", conexao);

                comando.Parameters.AddWithValue("@titulo", filme.Titulo);
                comando.Parameters.AddWithValue("@ano", DateTime.Parse(filme.Lancamento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@produtora", filme.Produtora);
                comando.Parameters.AddWithValue("@diretor", filme.Diretor);
                comando.Parameters.AddWithValue("@duracao", filme.Duracao);
                comando.Parameters.AddWithValue("@genero", filme.Genero);
                comando.Parameters.AddWithValue("@poster", img());

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Métdo para Listar
        public DataTable Listar()
        {
            try
            {
                AbrirConexao();

                //instância um objeto do tipo Data Table
                DataTable dt = new DataTable();

                //instância um objeto do tipo MySQLData
                MySqlDataAdapter da = new MySqlDataAdapter();

                //Comando para imprimir todos os dados da tabela Bd
                comando = new MySqlCommand("Select * FROM filme ORDER BY film_id", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);

                //retorna os valores
                return dt;

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
