﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    public partial class NovoContatoForm : Form
    {
        private IContatoService service;
        private int idParaEdicao;

        public NovoContatoForm(IContatoService service, int idParaEdicao = 0)
        {
            InitializeComponent();
            this.service = service;
            this.idParaEdicao = idParaEdicao;
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
                Id = idParaEdicao,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            OperationResult result = idParaEdicao == 0 ? service.Save(contato) : service.Update(contato);

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

        private void NovoContatoForm_Shown(object sender, EventArgs e)
        {
            if (idParaEdicao == 0)
                return;

            ContatoDto contato = service.Get(idParaEdicao);
            txtNome.Text = contato.Nome;
            txtNome.Enabled = false;
            txtEmail.Text = contato.Email;
            txtTelefone.Text = contato.Telefone;
        }
    }
}
