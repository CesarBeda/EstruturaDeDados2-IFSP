using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    public class GerenciadorFrota
    {
        public List<Veiculo> Veiculos { get; set; }
        public List<Garagem> Garagens { get; set; }
        public List<Rota> Rotas { get; set; }
        public List<Viagem> Viagens { get; set; }

        public GerenciadorFrota()
        {
            Veiculos = new List<Veiculo>();
            Garagens = new List<Garagem>();
            Rotas = new List<Rota>();
            Viagens = new List<Viagem>();
        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void CadastrarGaragem(Garagem garagem)
        {
            Garagens.Add(garagem);
        }

        public void IniciarJornada(Veiculo veiculo, Garagem garagemSaida, Garagem garagemChegada)
        {
            if (veiculo.EmJornada)
            {
                throw new InvalidOperationException("Veículo já está em jornada.");
            }

            veiculo.EmJornada = true;
            var rota = Rotas.FirstOrDefault(r => r.Origem == garagemSaida && r.Destino == garagemChegada);

            if (rota == null)
            {
                rota = new Rota(garagemSaida, garagemChegada);
                Rotas.Add(rota);
            }

            var viagem = new Viagem(veiculo, garagemSaida, garagemChegada, veiculo.Capacidade);
            Viagens.Add(viagem);
            rota.RegistrarViagem(veiculo.Capacidade);
        }

        public void EncerrarJornada(Veiculo veiculo, Garagem garagemSaida, Garagem garagemChegada)
        {
            if (!veiculo.EmJornada)
            {
                throw new InvalidOperationException("Veículo não está em jornada.");
            }

            veiculo.EmJornada = false;
        }

        public void LiberarViagem(Garagem origem, Garagem destino)
        {
            var rota = Rotas.FirstOrDefault(r => r.Origem == origem && r.Destino == destino);
            if (rota == null)
            {
                rota = new Rota(origem, destino);
                Rotas.Add(rota);
            }
        }

        public void ListarVeiculosNaGaragem(int idGaragem)
        {
            var garagem = Garagens.FirstOrDefault(g => g.Id == idGaragem);
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
        }
    }
}

