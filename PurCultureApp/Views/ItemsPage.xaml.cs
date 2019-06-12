using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PurCultureApp.Models;
using PurCultureApp.Views;
using PurCultureApp.ViewModels;

namespace PurCultureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item.
			ItemsListView.SelectedItem = null;
		}

		 async void fb_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://facebook/purculture.com"));

		}

		async void tw_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://twitter.com/purculture.com"));

		}

		async void ig_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://instagram.com/purculture.com"));

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}


	}
}