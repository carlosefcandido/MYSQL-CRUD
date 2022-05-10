using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSQL_CRUD
{
    internal class DbEstudante
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=ns984.hostgator.com.br;port=3306;username=grup6412_medifile;password=Sublime@2022;database=grup6412_medifile";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deu erro! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AdicionarEstudante(Estudante estudante)
        {
            string sql = "insert into tbl_estudante values (null, @EstudanteNome, @EstudanteRegistro, @EstudanteTurma, @EstudanteSecao, null)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@EstudanteNome", MySqlDbType.VarChar).Value = estudante.Nome;
            cmd.Parameters.Add("@EstudanteRegistro", MySqlDbType.VarChar).Value = estudante.Registro;
            cmd.Parameters.Add("@EstudanteTurma", MySqlDbType.VarChar).Value = estudante.Turma;
            cmd.Parameters.Add("@EstudanteSecao", MySqlDbType.VarChar).Value = estudante.Secao;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adicionado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deu erro! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();


        }

        public static void EditarEstudante(Estudante estudante, string id)
        {
            string sql = "update tbl_estudante set nome = @EstudanteNome, registro = @EstudanteRegistro, turma = @EstudanteTurma, secao = @EstudanteSecao where id = @EstudanteId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@EstudanteId", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@EstudanteNome", MySqlDbType.VarChar).Value = estudante.Nome;
            cmd.Parameters.Add("@EstudanteRegistro", MySqlDbType.VarChar).Value = estudante.Registro;
            cmd.Parameters.Add("@EstudanteTurma", MySqlDbType.VarChar).Value = estudante.Turma;
            cmd.Parameters.Add("@EstudanteSecao", MySqlDbType.VarChar).Value = estudante.Secao;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Editado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deu erro! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();


        }

        public static void DeleteEstudante(string id)
        {
            string sql = "Delete from tbl_estudante where id = @EstudanteId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@EstudanteId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deletado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deu erro! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void MostrarEPesquisar(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
