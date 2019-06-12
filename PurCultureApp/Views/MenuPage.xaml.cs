using PurCultureApp.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurCultureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		MainPage RootPage { get => Application.Current.MainPage as MainPage; }
		List<HomeMenuItem> menuItems;
		public MenuPage()
		{
			InitializeComponent();

			menuItems = new List<HomeMenuItem>
			{
				new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
				new HomeMenuItem {Id = MenuItemType.Deepcuts, Title="Deepcuts" },
				new HomeMenuItem {Id = MenuItemType.Podcast, Title="Podcast" },
				new HomeMenuItem {Id = MenuItemType.Join, Title="Join" },
				new HomeMenuItem {Id = MenuItemType.Submissions, Title="Submissions" },
				new HomeMenuItem {Id = MenuItemType.PeaceFields, Title="PeaceFields" }

			};

			ListViewMenu.ItemsSource = menuItems;

			ListViewMenu.SelectedItem = menuItems[0];
			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;
				if (((HomeMenuItem)e.SelectedItem).Title == "Podcast")
				{
					Device.OpenUri(new Uri("https://www.youtube.com/channel/UCO2hM1f978WtWasDUQukhfA"));
					return;
				}
				
				if (((HomeMenuItem)e.SelectedItem).Title == "Submissions")
				{
					Device.OpenUri(new Uri("https://purculture.com/submissions"));
					return;
				}



				var id = (int)((HomeMenuItem)e.SelectedItem).Id;
				await RootPage.NavigateFromMenu(id);
			};
		}

		async void fb_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("fb://page/1874286949308332"));

			//Device.OpenUri(new Uri("http://facebook/purculture.com"));

		}

		async void tw_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("twitter://user?user_id=925755479321653248"));
			//Device.OpenUri(new Uri("http://twitter.com/purculture.com"));

		}

		async void ig_click(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("instagram://user?username=purculture"));

//			Device.OpenUri(new Uri("http://instagram.com/purculture.com"));

		}


	}
}