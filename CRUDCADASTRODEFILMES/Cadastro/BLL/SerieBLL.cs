using CRUDCADASTRODEFILMES.Cadastro.DAL;
using CRUDCADASTRODEFILMES.Cadastro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCADASTRODEFILMES.Cadastro.BLL
{
    public class SerieBLL
    {
        SerieDAL serieDAL = new SerieDAL();

        //Método Filtrar
        public DataTable FiltrarSerie(string filtrar)
        {
            try
            {
                return serieDAL.FiltrarSerie(filtrar);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método Pesquisar
        public DataTable GetSerie(string proucurar)
        {
            try
            {
                return serieDAL.GetSerie(proucurar);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método Excluir
        public void Excluir(Serie serie)
        {
            try
            {
                serieDAL.Excluir(serie);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método para alterar
        public void Alterar(Serie serie)
        {
            try
            {
                serieDAL.Alterar(serie);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método Salvar
        public void Salvar(Serie serie)
        {
            try
            {
                serieDAL.Salvar(serie);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método para listar
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = serieDAL.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
