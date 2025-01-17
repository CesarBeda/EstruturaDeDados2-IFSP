using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Transporte
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public bool EmJornada { get; set; }

        public Veiculo(int id, int capacidade)
        {
            Id = id;
            Capacidade = capacidade;
            EmJornada = false;
        }
    }

}
