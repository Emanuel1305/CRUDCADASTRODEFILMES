using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCADASTRODEFILMES.Cadastro.DAL;
using CRUDCADASTRODEFILMES.Cadastro.Model;

namespace CRUDCADASTRODEFILMES.Cadastro.BLL
{
    public class FilmeBLL
    {
        FilmeDAL filmeDAL = new FilmeDAL();

        //Método Filtrar
        public DataTable FiltrarFilme(string filtrar)
        {
            try
            {
                return filmeDAL.FiltrarFilme(filtrar);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método Pesquisar
        public DataTable GetFilme(string proucurar)
        {
            try
            {                
                return filmeDAL.GetFilme(proucurar);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Método Excluir
        public void Excluir(Filme filme)
        {
            try
            {
                filmeDAL.Excluir(filme);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método para alterar
        public void Alterar(Filme filme)
        {
            try
            {
                filmeDAL.Alterar(filme);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método Salvar
        public void Salvar(Filme filme)
        {
            try
            {
                filmeDAL.Salvar(filme);
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
                dt = filmeDAL.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
