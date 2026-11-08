using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; } = new Quarto();
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Calcula a quantidade de diárias pela diferença de datas
        public int Estadia => (DataCheckOut - DataCheckIn).Days;

        // Calcula o valor total multiplicando hóspedes, valores e dias
        public double ValorTotal
        {
            get
            {
                double valorAdultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valorCriancas = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;
                return (valorAdultos + valorCriancas) * Estadia;
            }
        }
    }
}