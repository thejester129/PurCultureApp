using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PurCultureApp.Models;
using PurCultureApp.Views;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using PurCultureApp.Services;

namespace PurCultureApp.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				var newItem = item as Item;
				Items.Add(newItem);
				await DataStore.AddItemAsync(newItem);
			});
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items =  await GetDataFromSiteAsync();
				foreach (var item in items)
				{
					Items.Add(item);
				}
				/*var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items)
				{
					Items.Add(item);
				}*/
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
		 async Task<ObservableCollection<Item>> GetDataFromSiteAsync()
		{
			var newItems = new ObservableCollection<Item>();
				

			var web = new HttpClient();
			var html = await web.GetStringAsync("https://purculture.com/");
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html);

			var articleList = htmlDocument.DocumentNode.SelectNodes("//div[@class='excerpt-thumb']");
		
			var listOfNames = new List<string>();
			foreach(var article in articleList)
			{
				var item = new Item()
				{
					Text = TextParser.ReplaceSpecialChars(article.Descendants("img").FirstOrDefault().GetAttributeValue("alt","")),
					Link = article.Descendants("a").FirstOrDefault().GetAttributeValue("href", ""),
					CoverImage = article.Descendants("img").FirstOrDefault().GetAttributeValue("data-image", "")
				};
				listOfNames.Add(item.Link);
				newItems.Add(item);
			}

			return await Task.FromResult(newItems);
		}
	}
}