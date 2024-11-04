using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    public class Livros
    {
        private List<Livro> Acervo { get; set; }

        public Livros()
        {
            Acervo = new List<Livro>();
        }

        public void Adicionar(Livro livro) => Acervo.Add(livro);

        public Livro Pesquisar(int isbn) => Acervo.FirstOrDefault(l => l.Isbn == isbn);
    }
}
