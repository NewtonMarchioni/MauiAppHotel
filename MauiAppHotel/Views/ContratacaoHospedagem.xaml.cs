namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = (DatePicker)sender;

        if (elemento.Date.HasValue)
        {
            dtpck_checkout.MinimumDate = elemento.Date.Value.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.Value.AddMonths(6);
        }
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}