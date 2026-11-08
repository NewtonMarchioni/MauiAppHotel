using MauiAppHotel.Models;

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

    // Disparado automaticamente sempre que esta página reaparece na tela
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LimparCampos();
    }

    // Reseta todos os controles aos valores iniciais
    private void LimparCampos()
    {
        stp_adultos.Value = 0;
        stp_criancas.Value = 0;
        pck_quarto.SelectedItem = null;

        dtpck_checkin.Date = DateTime.Now;
        dtpck_checkout.Date = DateTime.Now.AddDays(1);

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
    }

    // Ajusta o check-out mínimo ao mudar o check-in
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = (DatePicker)sender;

        if (elemento.Date.HasValue)
        {
            dtpck_checkout.MinimumDate = elemento.Date.Value.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.Value.AddMonths(6);
        }
    }

    // Ação do link Sobre
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

    // Ação do botão Avançar
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Atenção", "Por favor, selecione uma acomodação.", "OK");
                return;
            }

            int adultos = Convert.ToInt32(stp_adultos.Value);
            int criancas = Convert.ToInt32(stp_criancas.Value);

            if (adultos == 0 && criancas == 0)
            {
                await DisplayAlert("Atenção", "Selecione ao menos um hóspede.", "OK");
                return;
            }

            Hospedagem dadosHospedagem = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = adultos,
                QntCriancas = criancas,
                DataCheckIn = dtpck_checkin.Date.Value,
                DataCheckOut = dtpck_checkout.Date.Value
            };

            await Navigation.PushAsync(new HospedagemContratada(dadosHospedagem));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}