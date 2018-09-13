using System;
using System.Windows.Forms;
using carlosschults.ProjetoCsharpUnifai.Aplicacao;
using carlosschults.ProjetoCSharpUnifai.Exterior.Dados;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var conn = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new DefaultContatoService(new SqlContatoRepository(conn))));
        }
    }
}
