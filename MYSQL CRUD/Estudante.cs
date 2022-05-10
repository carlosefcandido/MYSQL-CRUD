using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSQL_CRUD
{
    internal class Estudante
    {
        public string Nome { get; set; }
        
        public string Registro { get; set; }

        public string Turma { get; set; }

        public string Secao { get; set; }

        public Estudante(string nome, string registro, string turma, string secao)
        {
            Nome = nome;
            Registro = registro;
            Turma = turma;
            Secao = secao;
        }
    }
}
