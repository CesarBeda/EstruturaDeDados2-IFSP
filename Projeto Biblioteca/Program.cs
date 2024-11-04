using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Program
    {
        private static Livros livros = new Livros();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Biblioteca - Menu de Opções");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                }
            } while (opcao != 0);
        }
        private static void AdicionarLivro()
        {
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            livros.Adicionar(new Livro(isbn, titulo, autor, editora));
            Console.WriteLine("Livro adicionado com sucesso!");
            Console.ReadKey();
        }

        private static void PesquisarLivroSintetico()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = livros.Pesquisar(isbn);

            if (livro != null)
            {
                Console.WriteLine($"ISBN do livro: {livro.Isbn}");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Editora: {livro.Editora}");
                Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}");
                Console.WriteLine($"Disponíveis: {livro.QtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade():F2}%");

            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            Console.ReadKey();
        }

        private static void PesquisarLivroAnalitico()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = livros.Pesquisar(isbn);

            if (livro != null)
            {
                Console.WriteLine($"ISBN do livro: {livro.Isbn}");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Editora: {livro.Editora}");
                Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}");
                Console.WriteLine($"Disponíveis: {livro.QtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade():F2}%");


                Console.WriteLine("Detalhes dos Exemplares:");
                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"Tombo: {exemplar.Tombo}");
                    Console.WriteLine($"Disponível: {(exemplar.Disponivel() ? "Sim" : "Não")}");
                    Console.WriteLine($"Total de Empréstimos: {exemplar.QtdeEmprestimos()}");

                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"Data de Empréstimo: {emprestimo.DtEmprestimo}");
                        Console.WriteLine($"Data de Devolução: {(emprestimo.DtDevolucao == DateTime.MinValue ? "Ainda não devolvido" : emprestimo.DtDevolucao.ToString())}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            Console.ReadKey();
        }

        private static void AdicionarExemplar()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = livros.Pesquisar(isbn);

            if (livro != null)
            {
                Console.Write("Número do tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());

                Exemplar exemplar = new Exemplar(tombo);
                livro.AdicionarExemplar(exemplar);
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            Console.ReadKey();
        }

        private static void RegistrarEmprestimo()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = livros.Pesquisar(isbn);

            if (livro != null)
            {
                Console.Write("Número do tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());

                var exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
                if (exemplar != null && exemplar.Disponivel())
                {
                    if (exemplar.Emprestar())
                    {
                        Console.WriteLine("Empréstimo registrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao registrar o empréstimo.");
                    }
                }
                else
                {
                    Console.WriteLine("Exemplar não disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            Console.ReadKey();
        }

        private static void RegistrarDevolucao()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = livros.Pesquisar(isbn);

            if (livro != null)
            {
                Console.Write("Número do tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());

                var exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
                if (exemplar != null && !exemplar.Disponivel())
                {
                    if (exemplar.Devolver())
                    {
                        Console.WriteLine("Devolução registrada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao registrar a devolução.");
                    }
                }
                else
                {
                    Console.WriteLine("Exemplar não encontrado ou já está disponível.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            Console.ReadKey();
        }



    }
}
