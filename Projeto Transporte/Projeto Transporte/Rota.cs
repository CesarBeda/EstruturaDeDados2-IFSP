using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    public class Rota
    {
        public Garagem Origem { get; set; }
        public Garagem Destino { get; set; }
        public int QuantidadeViagens { get; set; }
        public int PassageirosTransportados { get; set; }

        public Rota(Garagem origem, Garagem destino)
        {
            Origem = origem;
            Destino = destino;
            QuantidadeViagens = 0;
            PassageirosTransportados = 0;
        }

        public void RegistrarViagem(int passageiros)
        {
            QuantidadeViagens++;
            PassageirosTransportados += passageiros;
        }

        public void RelatorioViagens()
        {
            Console.WriteLine($"Rota de {Origem.Nome} para {Destino.Nome}:");
            Console.WriteLine($"Quantidade de viagens: {QuantidadeViagens}");
            Console.WriteLine($"Passageiros transportados: {PassageirosTransportados}");
        }
    }
}
