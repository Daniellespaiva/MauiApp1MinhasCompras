using MauiApp1MinhasCompras.Models;

namespace MauiApp1MinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {

        try
        {
            Produto prodto_anexao = BindingContext as Produto;

            Produto p = new Produto
            {
                Id  = prodto_anexao.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)

            };

            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "Ok");
            await Navigation.PopAsync();



        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }

    }
}