using MauiAppHotel20262.Models;

namespace MauiAppHotel20262.Views;


public partial class ContratacaoHospedagem : ContentPage
{
    List<Models.Quarto> quartos = new List<Models.Quarto>
    {
        new Models.Quarto { Nome = "Suite Master", ValorAdulto = 225.50, ValorCrianca = 200.30 },
        new Models.Quarto { Nome = "Suite Premium", ValorAdulto = 180.30, ValorCrianca = 110.30 },
        new Models.Quarto { Nome = "Suíte Viajante", ValorAdulto = 140.00, ValorCrianca = 75.00 },
        new Models.Quarto { Nome = "Suíte Crise", ValorAdulto = 100.00, ValorCrianca = 50.00 },
    };


    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pickerquarto.ItemsSource = quartos;
        pickerquarto.ItemDisplayBinding = new Binding("Nome");

        datePickerCheckIn.MinimumDate = DateTime.Today;
        datePickerCheckIn.MaximumDate = DateTime.Today.AddMonths(3);
        datePickerCheckOut.MinimumDate = DateTime.Today.AddDays(1);
        datePickerCheckOut.MaximumDate = DateTime.Today.AddMonths(4);

    }

    private void datePickerCheckIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        datePickerCheckOut.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void datePickerCheckOut_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (datePickerCheckIn.Date.HasValue && datePickerCheckIn.Date.Value >= e.NewDate)
        {
            datePickerCheckOut.Date = datePickerCheckIn.Date.Value.AddDays(1);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {       
        try
        {
            var quartoSelecionado = (Quarto)pickerquarto.SelectedItem;
            var quantidadeAdultos = int.Parse(stepperAdultos.Value.ToString());
            var quantidadeCriancas = int.Parse(stepperCrianças.Value.ToString());

            var hospedagem = new Hospedagem
            {
                SuiteEscolhida = quartoSelecionado,
                QuantidadeAdultos = quantidadeAdultos,
                QuantidadeCriancas = quantidadeCriancas,
                DataCheckIn = datePickerCheckIn.Date ?? DateTime.Today,
                DataCheckOut = datePickerCheckOut.Date ?? DateTime.Today.AddDays(1)
            };

            double valorTotalEstadia = hospedagem.Estadia();
            Navigation.PushAsync(new HospedagemContratada(hospedagem, valorTotalEstadia));
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops", "Por favor, refaça o cálculo da estadia.", "OK");
        }

    }

    private async void SobreButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}