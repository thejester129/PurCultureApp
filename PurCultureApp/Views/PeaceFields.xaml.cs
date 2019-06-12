using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurCultureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeaceFields : ContentPage
	{
		public PeaceFields()
		{
			InitializeComponent();
			
		}
		override protected void OnDisappearing()
		{
			App.Current.Resources["NavigationPrimary"] = "#cc0000";

		}
		override protected void OnAppearing()
		{
			App.Current.Resources["NavigationPrimary"] = Color.Green;

		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("https://peacefieldsfestival.com/tickets"));

		}
	}
}