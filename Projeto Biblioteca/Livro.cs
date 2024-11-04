using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
       // private List<Exemplar> Exemplares { get; set; }
        public List<Exemplar> Exemplares { get; private set; } = new List<Exemplar>();

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            // Verifica se já existe um exemplar com o mesmo tombo
            if (Exemplares.Any(e => e.Tombo == exemplar.Tombo))
            {
                Console.WriteLine("Exemplar com este tombo já existe e não pode ser adicionado novamente.");
                return;
            }
            Exemplares.Add(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");

        }

        public int QtdeExemplares() => Exemplares.Count;

        public int QtdeDisponiveis() => Exemplares.Count(e => e.Disponivel());

        public int QtdeEmprestimos() => Exemplares.Sum(e => e.QtdeEmprestimos());

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0) return 0;
            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }

    }
}
