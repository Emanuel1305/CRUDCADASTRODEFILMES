using CRUDCADASTRODEFILMES.Cadastro.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCADASTRODEFILMES.Cadastro.DAL
{
    public class SerieDAL : Conexao
    {
        MySqlCommand comando = null;

        //Método para Filtrar
        public DataTable FiltrarSerie(string filtrar = "")
        {
            var dt = new DataTable();

            var sql = "SELECT seri_id, seri_titulo, seri_ano, seri_genero, seri_produtora, seri_episodios, seri_temporadas, seri_poster" +
                " FROM serie";

            if (filtrar != "")
            {
                sql += " WHERE seri_genero LIKE '%" + filtrar + "%'";

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
        public DataTable GetSerie(string proucurar = "")
        {
            var dt = new DataTable();

            var sql = "SELECT seri_id, seri_titulo, seri_ano, seri_genero, seri_produtora, seri_episodios, seri_temporadas, seri_poster" +
                " FROM serie";

            if (proucurar != "")
            {
                sql += " WHERE seri_titulo LIKE '%" + proucurar + "%'";

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
        public void Excluir(Serie serie)
        {
            try
            {
                //Abre uma conexão com o banco de dados
                AbrirConexao();

                //comando em MySql para deletar dados da tabela
                comando = new MySqlCommand("DELETE FROM serie WHERE seri_id = @id", conexao);
                comando.Parameters.AddWithValue("@id", serie.Id);

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
        public void Alterar(Serie serie)
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
                    if (serie.Poster == "")
                    {
                        return null;
                    }

                    //Faz as devidas conversões 
                    FileStream fs = new FileStream(serie.Poster, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    image_byte = br.ReadBytes((int)fs.Length);

                    //retorna a imagem 
                    return image_byte;
                }
                //verifica se o usuario mudou o poster
                if (serie.auterouimagem == "sim")
                {
                    AbrirConexao();

                    //Comando para atualizar dados de uma tabela
                    comando = new MySqlCommand("UPDATE serie SET seri_titulo = @titulo, seri_ano = @ano, " +
                        "seri_genero = @genero, seri_produtora = @produtora, seri_episodios = @episodios, seri_temporadas = @temporadas, " +
                        "seri_poster = @poster WHERE seri_id = @id", conexao);

                    //passa os valores necessários para cada parâmetro
                    comando.Parameters.AddWithValue("@id", serie.Id);
                    comando.Parameters.AddWithValue("@titulo", serie.Titulo);
                    comando.Parameters.AddWithValue("@ano", DateTime.Parse(serie.Lancamento).ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@genero", serie.Genero);
                    comando.Parameters.AddWithValue("@produtora", serie.Produtora);
                    comando.Parameters.AddWithValue("@episodios", serie.Episodios);
                    comando.Parameters.AddWithValue("@temporadas", serie.Temporadas);
                    comando.Parameters.AddWithValue("@poster", img()); //utiliza o método img para armazenar a imagem

                }
                //atualiza os dados sem mudar a imagem
                else if (serie.auterouimagem == "nao")
                {
                    comando = new MySqlCommand("UPDATE serie SET seri_titulo = @titulo, seri_ano = @ano, " +
                        "seri_genero = @genero, seri_produtora = @produtora, seri_episodios = @episodios, seri_temporadas = @temporadas " +
                        "WHERE seri_id = @id", conexao);

                    comando.Parameters.AddWithValue("@id", serie.Id);
                    comando.Parameters.AddWithValue("@titulo", serie.Titulo);
                    comando.Parameters.AddWithValue("@ano", DateTime.Parse(serie.Lancamento).ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@genero", serie.Genero);
                    comando.Parameters.AddWithValue("@produtora", serie.Produtora);
                    comando.Parameters.AddWithValue("@episodios", serie.Episodios);
                    comando.Parameters.AddWithValue("@temporadas", serie.Temporadas);
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
        public void Salvar(Serie serie)
        {
            byte[] img()
            {
                byte[] image_byte = null;
                if (serie.Poster == "")
                {
                    return null;
                }

                FileStream fs = new FileStream(serie.Poster, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                image_byte = br.ReadBytes((int)fs.Length);
                return image_byte;
            }

            try
            {
                AbrirConexao();

                //comando para inserir dados no banco de dados
                comando = new MySqlCommand("INSERT INTO serie (seri_titulo, seri_ano, seri_genero, seri_produtora, seri_episodios, seri_temporadas," +
                    " seri_poster) VALUES (@titulo, @ano, @genero, @produtora, @episodios, " +
                    "@temporadas, @poster)", conexao);

                comando.Parameters.AddWithValue("@titulo", serie.Titulo);
                comando.Parameters.AddWithValue("@ano", DateTime.Parse(serie.Lancamento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@genero", serie.Genero);
                comando.Parameters.AddWithValue("@produtora", serie.Produtora);
                comando.Parameters.AddWithValue("@episodios", serie.Episodios);
                comando.Parameters.AddWithValue("@temporadas", serie.Temporadas);
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
                comando = new MySqlCommand("Select * FROM serie ORDER BY seri_id", conexao);
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
