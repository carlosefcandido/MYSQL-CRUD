using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSQL_CRUD
{
    public partial class FormEstudante : Form
    {
        private readonly FormEstudenteInfo _parent;
        public string id, nome, registro, turma, secao;

        public FormEstudante(FormEstudenteInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        
        public void UpdateInfo()
        {
            lblText.Text = "Update Estudadnte";
            btnSalvar.Text = "Atualizar";
            txtNome.Text = nome;
            txtRegistro.Text = registro;
            txtTurma.Text = turma;
            txtSecao.Text = secao;
        }
        public void Clear()
        {
            txtNome.Text = txtRegistro.Text = txtTurma.Text = txtSecao.Text = string.Empty;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nome é menor que 3!");
                return;
            }
            if (txtRegistro.Text.Trim().Length < 1)
            {
                MessageBox.Show("Registro é menor que 1!");
                return;
            }
            if (txtTurma.Text.Trim().Length ==0)
            {
                MessageBox.Show("Turma é menor que 1!");
                return;
            }
            if (txtSecao.Text.Trim().Length ==0)
            {
                MessageBox.Show("Seção é menor que 1!");
                return;
            }
            if (btnSalvar.Text == "Salvar")
            {
                Estudante estudante = new Estudante(txtNome.Text.Trim(), txtRegistro.Text.Trim(), txtTurma.Text.Trim(), txtSecao.Text.Trim());
                DbEstudante.AdicionarEstudante(estudante);
                if ((MessageBox.Show("Deseja cadastrar mais algum estudante?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                {
                    Clear();
                }
                else
                {
                    this.Close();
                }
                            }
            if (btnSalvar.Text == "Atualizar")
            {
                Estudante estudante = new Estudante(txtNome.Text.Trim(), txtRegistro.Text.Trim(), txtTurma.Text.Trim(), txtSecao.Text.Trim());
                DbEstudante.EditarEstudante(estudante, id);
                this.Close();
            }
            _parent.Display();

        }
    }
}
