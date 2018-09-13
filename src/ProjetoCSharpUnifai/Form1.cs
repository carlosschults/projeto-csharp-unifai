using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    public partial class Form1 : Form
    {
        private List<Contato> contatos = new List<Contato>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, System.EventArgs e)
        {
            // TODO substituir isso pelo código que realmente busca os contatos
            contatos = new List<Contato>
            {
                new Contato { Nome = "Bill Gates", Email = "bill@microsoft.com", Telefone = "(55)124-1234"},
                new Contato { Nome = "Mark Zuckerberd", Email = "mark@gmail.com", Telefone = "(55)124-1235"},
                new Contato { Nome = "Sergey Brinn", Email = "sergey@gmail.com", Telefone = "(55)124-6543"}
            };

            foreach (var contato in contatos)
            {
                dataGridView1.Rows.Add(contato.Nome, contato.Telefone, contato.Email);
            }
        }

        private void txtPesquisarContato_TextChanged(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();

            // TODO remover duplicação
            foreach (var contato in contatos.Where(x => x.Nome.StartsWith(txtPesquisarContato.Text, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                dataGridView1.Rows.Add(contato.Nome, contato.Telefone, contato.Email);
            }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            var frm = new NovoContatoForm();
            frm.ShowDialog();
            Contato contatoSalvo = frm.Contato;
            contatos.Add(contatoSalvo);

            dataGridView1.Rows.Clear();

            foreach (var contato in contatos.Where(x => x.Nome.StartsWith(txtPesquisarContato.Text, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                dataGridView1.Rows.Add(contato.Nome, contato.Telefone, contato.Email);
            }
        }
    }

    public class Contato
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
