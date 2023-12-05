using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCADASTRODEFILMES.Cadastro.Model
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Produtora { get; set; }
        public string Episodios { get; set; }
        public string Temporadas { get; set; }
        public string Genero { get; set; }
        public string Lancamento { get; set; }
        public string Poster { get; set; }

        public string auterouimagem;
        public string tituloantigo;
    }
}
