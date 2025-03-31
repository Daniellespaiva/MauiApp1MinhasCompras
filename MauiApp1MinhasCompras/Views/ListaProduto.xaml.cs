using MauiApp1MinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiApp1MinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    public ListaProduto()
	{
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }

	protected async override void OnAppearing()
	{
		try
		{
            lista.Clear();
			List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
		{
           await DisplayAlert("Ops", ex.Message, "Ok");
        }

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try 
		{
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "Ok");
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{

			string q = e.NewTextValue;
            lst_produtos.IsRefreshing = true;

            lista.Clear();

			List<Produto> tmp = await App.Db.Search(q);

			tmp.ForEach(i => lista.Add(i));
		}
		catch (Exception ex) 
		{
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
        finally
        {
            lst_produtos.IsRefreshing = false;
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		try
		{

			double soma = lista.Sum(i => i.Total);

			string msn = $"O total È {soma:C}";

			DisplayAlert("Total dos Produtos", msn, "Ok");
		}
		catch (Exception ex) 
		{
             DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    

    private async void MenuItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {


                

            bool confirm = await DisplayAlert(
            "tem Certeza?", $"Remove {p.Descricao}", "Sim", "N„o");

            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {

        }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try 
        {

            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void lst_produtos_Refreshing(object sender, EventArgs e)
    {
        try
        {
            lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");

        } finally 
        {  
            lst_produtos.IsRefreshing = false;
        }

    }

    // Evento do Picker para capturar a categoria selecionada
    private async void picker_categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        try

            // Validando se a categoria selecionada n√£o √© nula
        {
            // Apenas exibe no console para teste; pode ser integrado conforme necessidade
            Console.WriteLine($"Categoria selecionada: {categoriaSelecionada}");
        }
        else
        {
            Console.WriteLine("Nenhuma categoria selecionada.");
        }
    }
}