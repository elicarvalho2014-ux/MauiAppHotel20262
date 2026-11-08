using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel20262.Models
{
    public class Hospedagem
    {
        public Quarto SuiteEscolhida { get; set; }

        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }

        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public double Estadia()
        {
            int quantidadeEstadia = (DataCheckOut - DataCheckIn).Days;
            double valorTotal = ((SuiteEscolhida.ValorAdulto * QuantidadeAdultos) + (SuiteEscolhida.ValorCrianca * QuantidadeCriancas)) * quantidadeEstadia;
            return valorTotal;
        }
        public int quantidadeEstadia ()
        {
            int quantidadeEstadia = (DataCheckOut - DataCheckIn).Days;
            return quantidadeEstadia;
        }
        public double valorTotal()
        {
            int quantidadeEstadia = (DataCheckOut - DataCheckIn).Days;
            double valorTotal = ((SuiteEscolhida.ValorAdulto * QuantidadeAdultos) + (SuiteEscolhida.ValorCrianca * QuantidadeCriancas)) * quantidadeEstadia;
            return valorTotal;
        }


    }
}
