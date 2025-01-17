using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    public class Viagem
    {
        public Veiculo Veiculo { get; set; }
        public Garagem GaragemSaida { get; set; }
        public Garagem GaragemChegada { get; set; }
        public int Passageiros { get; set; }
        public DateTime DataHora { get; set; }

        public Viagem(Veiculo veiculo, Garagem garagemSaida, Garagem garagemChegada, int passageiros)
        {
            Veiculo = veiculo;
            GaragemSaida = garagemSaida;
            GaragemChegada = garagemChegada;
            Passageiros = passageiros;
            DataHora = DateTime.Now;
        }
    }
}
