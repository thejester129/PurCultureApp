using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PurCultureApp.Models;
using PurCultureApp.Services;
using PurCultureApp.Views;
using Xamarin.Forms;

namespace PurCultureApp.ViewModels
{

	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public string Link { get; set; }

		public Command LoadItemsCommand { get; set; }

		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = AddDescriptionAsync(item).Result;
			

		}

		async Task ExecuteLoadItemsCommand(Item item)
		{
			Item = await AddDescriptionAsync(item);
		}



		async Task<Item> AddDescriptionAsync(Item item)
		{
			
			var website = "https://purculture.com" + item.Link;
			Link = website;
			var web = new HttpClient();
			var html =   web.GetStringAsync(website);
			
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html.Result);
			
			

			var articleList = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='blog-item-content-wrapper']");
			var imageNodes = articleList.SelectNodes("//img");
			var imageLinks = new List<string>();
			foreach (var node in imageNodes){
				imageLinks.Add(node.GetAttributeValue("data-src","nope"));
			}
			var descriptions = articleList.InnerText;
			//descriptions =  Regex.Replace(descriptions, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
			descriptions = TextParser.DeleteEndArticle(descriptions);


			item.Description = descriptions;
			//item.Description = articleList.Descendants("img").FirstOrDefault().GetAttributeValue("alt","")
			//	Link = article.Descendants("a").FirstOrDefault().GetAttributeValue("href", "")


			return await Task.FromResult(item);
		}

		
	}
}
