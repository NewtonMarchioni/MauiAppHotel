namespace MauiAppHotel.Models;

public class Quarto
{
    public string Descricao { get; set; } = string.Empty;
    public double ValorDiariaAdulto { get; set; }
    public double ValorDiariaCrianca { get; set; }

    // Resumo dos valores para exibição sob o Picker
    public string ResumoValores =>
        $"Adulto: {ValorDiariaAdulto:C} | Criança: {ValorDiariaCrianca:C}";

    // Descrição completa caso deseje exibir em linha única
    public string DescricaoCompleta =>
        $"{Descricao} (Adulto: {ValorDiariaAdulto:C0} | Criança: {ValorDiariaCrianca:C0})";
}
