using CRUDCADASTRODEFILMES.Cadastro.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCADASTRODEFILMES.Cadastro.Model
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Produtora { get; set; }
        public string Diretor { get; set; }
        public string Duracao { get; set; }
        public string Genero { get; set; }
        public string Lancamento { get; set; }
        public string Poster { get; set; }

        public string auterouimagem;
        public string tituloantigo; 
    }
}
