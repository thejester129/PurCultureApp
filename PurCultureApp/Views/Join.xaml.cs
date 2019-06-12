using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurCultureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Join : ContentPage
	{
		public Join()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			SmtpClient cv = new SmtpClient("smtp.gmail.com", 587);
			cv.EnableSsl = true;
			cv.Credentials = new NetworkCredential("purculturemailbot@gmail.com", "tomisfat6969");
			string email = $@"Name :{fullName.Text} 
Email: {emailEntry.Text}
Location: {location.Text}
Subject Area: {subject.Text}
What can you bring to the team: {bring.Text}";
			try
			{
				cv.Send("purculturemailbot@gmail.com", "thejester129@gmail.com", "Purculture Join Request", email);
				Navigation.PushAsync(new ThankYouPage());

			}
			catch (Exception ex)
			{
				fullName.Text = "fail";
			}
		}

		protected override void OnDisappearing()
		{
			fullName.Text = "";
			emailEntry.Text = "";
			location.Text = "";
			subject.Text = "";
			bring.Text = "";
		}
}
}