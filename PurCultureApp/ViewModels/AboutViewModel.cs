using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace PurCultureApp.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.youtube.com/channel/UCh6FytXdntRmfA7oBJXZpSA")));
		}

		public ICommand OpenWebCommand { get; }
	}
}