namespace MauiAppHotel20262.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada(Models.Hospedagem hospedagem, double valorTotalEstadia)
	{
		InitializeComponent();

        BindingContext = hospedagem;
    }
}