namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();
	}

    private async void Sobre_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Sobre());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível abrir a tela Sobre: {ex.Message}", "OK");
        }
    }
}