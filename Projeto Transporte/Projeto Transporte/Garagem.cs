using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    public class Garagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; }

        public Garagem(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Veiculos = new List<Veiculo>();
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            Veiculos.Remove(veiculo);
        }
    }
}
