using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class App : Application
{
    public List<Quarto> lista_quartos { get; set; } = new List<Quarto>
    {
        new Quarto()
        {
            Descricao = "Suíte Superior Luxo",
            ValorDiariaAdulto = 110.00,
            ValorDiariaCrianca = 50.00
        },
        new Quarto()
        {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 80.00,
            ValorDiariaCrianca = 40.00
        },
        new Quarto()
        {
            Descricao = "Suíte Single",
            ValorDiariaAdulto = 50.00,
            ValorDiariaCrianca = 25.00
        },
        new Quarto()
        {
            Descricao = "Suíte Crise",
            ValorDiariaAdulto = 25.00,
            ValorDiariaCrianca = 12.50
        }
    };

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new NavigationPage(new Views.ContratacaoHospedagem()))
        {
            Width = 400,
            Height = 600
        };

        return window;
    }
}