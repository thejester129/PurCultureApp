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
			browser.Source = "https://purculture.com/whatsnew//review-stoned-immaculate-the-bungalow-18519";
			Content = browser;
			BindingContext = this.viewModel = viewModel;

		}

		public ItemDetailPage()
		{
			InitializeComponent();

			var item = new Item
			{
				Text = "I