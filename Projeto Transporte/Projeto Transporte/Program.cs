using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    internal class Program
    {
        static GerenciadorFrota gerenciadorFrota = new GerenciadorFrota();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                ExibirMenu();
                opcao = ObterOpcaoUsuario();

                switch (opcao)
                {
                    case 0:
                        Finalizar();
                        break;
                    case 1:
                        CadastrarVeiculo();
                        break;
                    case 2:
                        CadastrarGaragem();
                        break;
                    case 3:
                        IniciarJornada();
                        break;
                    case 4:
                        EncerrarJornada();
                        break;
                    case 5:
                        LiberarViagem();
                        break;
                    case 6:
                        ListarVeiculosGaragem();
                        break;
                    case 7:
                        InformarQuantidadeViagens();
                        break;
                    case 8:
                        ListarViagens();
                        break;
                    case 9:
                        InformarPassageirosTransportados();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

            } while (opcao != 0);
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("0. Finalizar");
            Console.WriteLine("1. Cadastrar veículo");
            Console.WriteLine("2. Cadastrar garagem");
            Console.WriteLine("3. Iniciar jornada");
            Console.WriteLine("4. Encerrar jornada");
            Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino");
            Console.WriteLine("6. Listar veículos em determinada garagem");
            Console.WriteLine("7. Informar quantidade de viagens efetuadas");
            Console.WriteLine("8. Listar viagens efetuadas");
            Console.WriteLine("9. Informar quantidade de passageiros transportados");
            Console.WriteLine("==================");
        }

        static int ObterOpcaoUsuario()
        {
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        static void Finalizar()
        {
            Console.WriteLine("Sistema encerrado.");
            Environment.Exit(0);
        }

        static void CadastrarVeiculo()
        {
            Console.Write("Informe o ID da van: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Informe a capacidade máxima da van: ");
            int capacidade = int.Parse(Console.ReadLine());

            if (gerenciadorFrota.Garagens.Count == 0)
            {
                Console.WriteLine("Nenhuma garagem cadastrada. Cadastre uma garagem antes de cadastrar um veículo.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Escolha ID da garagem para o veículo:");
            for (int i = 0; i < gerenciadorFrota.Garagens.Count; i++)
            {
                Console.WriteLine($"ID: {gerenciadorFrota.Garagens[i].Id}. Nome: {gerenciadorFrota.Garagens[i].Nome}");
            }
            int garagemEscolhida = int.Parse(Console.ReadLine());

            var garagem = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemEscolhida);
            if (garagem == null)
            {
                Console.WriteLine("Garagem inválida.");
                Console.ReadKey();
                return;
            }

            var van = new Veiculo(id, capacidade);
            gerenciadorFrota.CadastrarVeiculo(van);
            garagem.AdicionarVeiculo(van);
            Console.WriteLine("Veículo cadastrado e associado à garagem com sucesso!");
            Console.ReadKey();
        }

        static void CadastrarGaragem()
        {
            Console.Write("Informe o ID da garagem: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome da garagem: ");
            string nome = Console.ReadLine();

            var garagem = new Garagem(id, nome);
            gerenciadorFrota.CadastrarGaragem(garagem);
            Console.WriteLine("Garagem cadastrada com sucesso!");
            Console.ReadKey();
        }

        // Alteração para corrigir iniciar jornada
        static void IniciarJornada()
        {
            Console.Write("Informe o ID do veículo: ");
            int veiculoId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de saída: ");
            int garagemSaidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var veiculo = gerenciadorFrota.Veiculos.FirstOrDefault(v => v.Id == veiculoId);
            var garagemSaida = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemSaidaId);
            var garagemChegada = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemChegadaId);

            if (veiculo != null && garagemSaida != null && garagemChegada != null)
            {
                try
                {
                    gerenciadorFrota.IniciarJornada(veiculo, garagemSaida, garagemChegada);
                    Console.WriteLine("Jornada iniciada com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Informações inválidas.");
            }

            Console.ReadKey();
        }

        // Alteração para corrigir encerrar jornada
        static void EncerrarJornada()
        {
            Console.Write("Informe o ID do veículo: ");
            int veiculoId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de saída: ");
            int garagemSaidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var veiculo = gerenciadorFrota.Veiculos.FirstOrDefault(v => v.Id == veiculoId);
            var garagemSaida = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemSaidaId);
            var garagemChegada = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemChegadaId);

            if (veiculo != null && garagemSaida != null && garagemChegada != null)
            {
                try
                {
                    gerenciadorFrota.EncerrarJornada(veiculo, garagemSaida, garagemChegada);
                    Console.WriteLine("Jornada encerrada.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Informações inválidas.");
            }

            Console.ReadKey();
        }

        // Alteração para corrigir liberar viagem
        static void LiberarViagem()
        {
            Console.Write("Informe o ID da garagem de partida: ");
            int garagemPartidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var garagemPartida = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemPartidaId);
            var garagemChegada = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemChegadaId);

            if (garagemPartida != null && garagemChegada != null)
            {
                gerenciadorFrota.LiberarViagem(garagemPartida, garagemChegada);
                Console.WriteLine("Viagem liberada com sucesso!");
            }
            else
            {
                Console.WriteLine("Garagens inválidas.");
            }

            Console.ReadKey();
        }



        // Alteração para corrigir quantidade de viagens
        static void InformarQuantidadeViagens()
        {
            Console.Write("Informe o ID da garagem de partida: ");
            int garagemPartidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var rota = gerenciadorFrota.Rotas.FirstOrDefault(r => r.Origem.Id == garagemPartidaId && r.Destino.Id == garagemChegadaId);
            if (rota != null)
            {
                Console.WriteLine($"Quantidade de viagens efetuadas: {rota.QuantidadeViagens}");
            }
            else
            {
                Console.WriteLine("Rota não encontrada.");
            }

            Console.ReadKey();
        }

        // Alteração para corrigir listar viagens
        static void ListarViagens()
        {
            Console.Write("Informe o ID da garagem de partida: ");
            int garagemPartidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var rota = gerenciadorFrota.Rotas.FirstOrDefault(r => r.Origem.Id == garagemPartidaId && r.Destino.Id == garagemChegadaId);
            if (rota != null)
            {
                rota.RelatorioViagens();
            }
            else
            {
                Console.WriteLine("Rota não encontrada.");
            }

            Console.ReadKey();
        }
        static void ListarVeiculosGaragem()
        {
            Console.Write("Informe o ID da garagem: ");
            int garagemId = int.Parse(Console.ReadLine());

            var garagem = gerenciadorFrota.Garagens.FirstOrDefault(g => g.Id == garagemId);
            if (garagem != null)
            {
                Console.WriteLine($"Veículos na garagem {garagem.Nome}:");
                foreach (var veiculo in garagem.Veiculos)
                {
                    Console.WriteLine($"ID: {veiculo.Id}, Capacidade: {veiculo.Capacidade}");
                }
            }
            else
            {
                Console.WriteLine("Garagem não encontrada.");
            }

            Console.ReadKey();
        }

        // Alteração para corrigir quantidade de passageiros transportados
        static void InformarPassageirosTransportados()
        {
            Console.Write("Informe o ID da garagem de partida: ");
            int garagemPartidaId = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID da garagem de chegada: ");
            int garagemChegadaId = int.Parse(Console.ReadLine());

            var rota = gerenciadorFrota.Rotas.FirstOrDefault(r => r.Origem.Id == garagemPartidaId && r.Destino.Id == garagemChegadaId);
            if (rota != null)
            {
                Console.WriteLine($"Passageiros transportados: {rota.PassageirosTransportados}");
            }
            else
            {
                Console.WriteLine("Rota não encontrada.");
            }

            Console.ReadKey();
        }
    }
}

