using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    public partial class NovoContatoForm : Form
    {
        // TODO campos públicos são má prática
        public Contato Contato;

        public NovoContatoForm()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (nome == string.Empty)
            {
                // TODO remover duplicação de código
                MessageBox.Show(
                    "Nome deve ser informado.", 
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                txtNome.Select();
                return;
            }

            string telefone = txtTelefone.Text.Trim();

            if (telefone == string.Empty)
            {
                MessageBox.Show(
                    "Telefone deve ser informado.",
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                txtTelefone.Select();
                return;
            }

            string email = txtEmail.Text.Trim();

            if (email != string.Empty && !email.Contains("@"))
            {
                MessageBox.Show(
                    "E-mail precisa ser válido (conter uma @).",
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                txtEmail.Select();
                return;
            }

            Contato = new Contato
            {
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            MessageBox.Show(
                    "Contato salvo com sucesso.",
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            Close();
        }
    }
}
