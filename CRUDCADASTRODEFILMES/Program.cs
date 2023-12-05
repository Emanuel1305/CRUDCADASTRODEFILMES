using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDCADASTRODEFILMES.login;

namespace CRUDCADASTRODEFILMES
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin login = new FrmLogin();
            login.ShowDialog();

            if (login.logado)
            {
                Application.Run(new Form1());
            }
        }
    }
}
