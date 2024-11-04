using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    public class Exemplar
    {
        public int Tombo { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; } = new List<Emprestimo>();

        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var emprestimo = Emprestimos.Find(e => e.DtDevolucao == DateTime.MinValue);
            if (emprestimo != null)
            {
                emprestimo.RegistrarDevolucao(DateTime.Now); // Chama o método para registrar a devolução
                return true;
            }
            return false;
        }


        public bool Disponivel() => Emprestimos.All(e => e.DtDevolucao != DateTime.MinValue);

        public int QtdeEmprestimos() => Emprestimos.Count;
    }
}
