using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    public partial class NovoContatoForm : Form
    {
        private IContatoService service;

        public NovoContatoForm(IContatoService service)
        {
            InitializeComponent();
            this.service = service;
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

            var contato = new ContatoDto
            {
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            OperationResult result = service.Save(contato);

            if (result.Success)
                MessageBox.Show(
                    "Contato salvo com sucesso.",
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else

                MessageBox.Show(
                    result.ErrorMessage,
                    "ProjetoCSharp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            Close();
        }
    }
}
