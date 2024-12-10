using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            if (medicamento.QtdeDisponivel() == 0)
            {
                return listaMedicamentos.Remove(medicamento);
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Equals(medicamento)) ?? new Medicamento();
        }

        public List<Medicamento> ListarSintetico()
        {
            return listaMedicamentos;
        }
    }
}
