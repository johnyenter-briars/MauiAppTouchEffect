namespace MauiAppTouchEffect.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage(ProductsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}