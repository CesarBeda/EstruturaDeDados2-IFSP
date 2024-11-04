using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; private set; }
        public DateTime DtDevolucao { get; private set; }

        public Emprestimo(DateTime dtEmprestimo)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = DateTime.MinValue; // Indica que ainda não foi devolvido
        }

        public void RegistrarDevolucao(DateTime dtDevolucao)
        {
            DtDevolucao = dtDevolucao; // Define a data de devolução
        }
    }

}
