using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PurCultureApp.Models;
using PurCultureApp.ViewModels;

namespace PurCultureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;

		public ItemDetailPage(ItemDetailViewModel viewModel)
		{

			InitializeComponent();

			var browser = new WebView();
			var link = viewModel.Link;
			browser.Source = link;
			Content = browser;


			BindingContext = this.viewModel = viewModel;

		}

		public ItemDetailPage()
		{
			InitializeComponent();
			//if error with viewmodel
			var item = new Item
			{
				Text = "Aw naw",
				Description = "Thats a big oof"
			};

			viewModel = new ItemDetailViewModel(item);
			BindingContext = viewModel;
		}
	}
}