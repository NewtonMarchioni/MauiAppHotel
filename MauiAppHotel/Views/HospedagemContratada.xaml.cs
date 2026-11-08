using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    // Construtor que recebe os dados enviados pela tela anterior
    public HospedagemContratada(Hospedagem dados)
    {
        InitializeComponent();

        // Vincula o objeto recebido diretamente aos componentes do XAML
        BindingContext = dados;
    }

    // Método que responde ao clique do botão "Nova Reserva"
    private async void Button_Voltar_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}