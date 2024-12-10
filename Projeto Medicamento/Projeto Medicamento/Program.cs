using System;
using System.Collections.Generic;
using System.Globalization;

namespace Projeto_Medicamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== Sistema de Gerenciamento de Medicamentos =====");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos (sintético)");
                Console.WriteLine("====================================================");
                Console.Write("Escolha uma opção: ");

                // Validação da opção escolhida
                if (!int.TryParse(Console.ReadLine(), out int opcao) || opcao < 0 || opcao > 6)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadLine();
                    continue;
                }

                // Sair do programa
                if (opcao == 0)
                {
                    Console.WriteLine("Encerrando o programa...");
                    break;
                }

                // Chamando as funções conforme a opção do usuário
                switch (opcao)
                {
                    case 1:
                        CadastrarMedicamento(medicamentos);
                        break;
                    case 2:
                        ConsultarMedicamentoSintetico(medicamentos);
                        break;
                    case 3:
                        ConsultarMedicamentoAnalitico(medicamentos);
                        break;
                    case 4:
                        ComprarMedicamento(medicamentos);
                        break;
                    case 5:
                        VenderMedicamento(medicamentos);
                        break;
                    case 6:
                        ListarMedicamentos(medicamentos);
                        break;
                }
            }
        }

        static void CadastrarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do medicamento: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente.");
            }

            Console.Write("Informe o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o laboratório do medicamento: ");
            string laboratorio = Console.ReadLine();

            Medicamento medicamento = new Medicamento(id, nome, laboratorio);
            medicamentos.Adicionar(medicamento);
            Console.WriteLine("Medicamento cadastrado com sucesso!");
            Console.ReadLine();
        }

        static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do medicamento: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente.");
            }

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento.Id != 0)
            {
                Console.WriteLine($"Medicamento encontrado: {medicamento}");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            Console.ReadLine();
        }

        static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do medicamento: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente.");
            }

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento.Id != 0)
            {
                Console.WriteLine($"Medicamento encontrado: {medicamento}");
                foreach (var lote in medicamento.Lotes)
                {
                    Console.WriteLine($"  Lote: {lote}");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            Console.ReadLine();
        }

        static void ComprarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do medicamento: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente.");
            }

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento.Id != 0)
            {
                // Entrada para o ID do lote
                Console.Write("Informe o ID do lote: ");
                int loteId;
                while (!int.TryParse(Console.ReadLine(), out loteId))
                {
                    Console.WriteLine("ID do lote inválido. Digite novamente.");
                }

                // Entrada para a quantidade
                Console.Write("Informe a quantidade do lote: ");
                int qtde;
                while (!int.TryParse(Console.ReadLine(), out qtde) || qtde <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Digite novamente.");
                }

                // Entrada para a data de vencimento
                Console.Write("Informe a data de vencimento (dd/MM/yyyy): ");
                DateTime venc;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out venc))
                {
                    Console.WriteLine("Data inválida. Digite novamente no formato dd/MM/yyyy.");
                }

                // Criando o lote e adicionando ao medicamento
                Lote lote = new Lote(loteId, qtde, venc);
                medicamento.Comprar(lote);
                Console.WriteLine("Lote adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            Console.ReadLine();
        }

        static void VenderMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do medicamento: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite novamente.");
            }

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento.Id != 0)
            {
                Console.Write("Informe a quantidade a ser vendida: ");
                int qtde;
                while (!int.TryParse(Console.ReadLine(), out qtde) || qtde <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Digite novamente.");
                }

                if (medicamento.Vender(qtde))
                {
                    Console.WriteLine("Venda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há quantidade suficiente para realizar a venda.");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            Console.ReadLine();
        }

        static void ListarMedicamentos(Medicamentos medicamentos)
        {
            Console.WriteLine("Lista de Medicamentos:");
            var lista = medicamentos.ListarSintetico();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado.");
            }
            else
            {
                foreach (var medicamento in lista)
                {
                    Console.WriteLine(medicamento);
                }
            }
            Console.ReadLine();
        }
    }
}
