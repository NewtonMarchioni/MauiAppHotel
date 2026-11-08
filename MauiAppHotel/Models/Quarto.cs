using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Quarto
    {
        public string Descricao { get; set; } = string.Empty;
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }

        // Propriedade combinada que formata os valores para exibição no Picker
        public string DescricaoCompleta =>
            $"{Descricao} - Adulto: {ValorDiariaAdulto:C} | Criança: {ValorDiariaCrianca:C}";
    }
}
