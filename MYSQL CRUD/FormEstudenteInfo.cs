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
    public partial class FormEstudenteInfo : Form
    {
        FormEstudante form;
        Timer _timer = new Timer();
        public FormEstudenteInfo()
        {
            InitializeComponent();
            form = new FormEstudante(this);
        }

        
        public void Display()
        {
            DbEstudante.MostrarEPesquisar("Select id, nome, registro, turma, secao from tbl_estudante ", dataGridView);
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
        }

        private void FormEstudenteInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAtualizaTabela_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            DbEstudante.MostrarEPesquisar("Select id, nome, registro, turma, secao from tbl_estudante where nome like'%"+txtProcurar.Text+"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==0)
            {
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.nome = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.registro = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.turma = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.secao = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;

            }
            if(e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbEstudante.DeleteEstudante(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                    
                }
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
