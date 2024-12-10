using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; set; } = new Queue<Lote>();

        public Medicamento() { }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
        }

        public int QtdeDisponivel()
        {
            return Lotes.Sum(lote => lote.Qtde);
        }

        public void Comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            int restante = qtde;

            while (restante > 0 && Lotes.Count > 0)
            {
                var loteAtual = Lotes.Peek();
                if (loteAtual.Qtde <= restante)
                {
                    restante -= loteAtual.Qtde;
                    Lotes.Dequeue();
                }
                else
                {
                    loteAtual.Qtde -= restante;
                    restante = 0;
                }
            }

            return restante == 0;
        }

        public override string ToString()
        {
            return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento outro)
            {
                return Id == outro.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
