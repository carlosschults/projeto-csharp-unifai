using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    public partial class Form1 : Form
    {
        private IEnumerable<ContatoDto> contatos = new List<ContatoDto>();
        private IContatoService contatosService;

        public Form1(IContatoService contatosService)
        {
            InitializeComponent();
            this.contatosService = contatosService;
        }

        private void Form1_Shown(object sender, System.EventArgs e)
        {
            CarregarContatos();
        }

        private void txtPesquisarContato_TextChanged(object sender, System.EventArgs e)
        {
            CarregarContatos();
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            var frm = new NovoContatoForm(contatosService);
            frm.ShowDialog();
            CarregarContatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != this.Excluir.Index)
                return;

            var resposta = MessageBox.Show(
                "Tem certeza que deseja excluir esse registro?",
                "ProjetoCSharp",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resposta == DialogResult.No)
                return;
            
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells[this.id.Index].Value;
            OperationResult result = contatosService.Delete(id);

            if (result.Success)
            {
                MessageBox.Show(
                "Contato excluído com sucesso.",
                "ProjetoCSharp",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                CarregarContatos();

                return;
            }
        }

        private void CarregarContatos()
        {
            contatos = contatosService.GetAll();
            dataGridView1.Rows.Clear();

            foreach (var contato in contatos.Where(x => x.Nome.StartsWith(txtPesquisarContato.Text, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                dataGridView1.Rows.Add(contato.Id, contato.Nome, contato.Telefone, contato.Email);
            }
        }
    }
}
