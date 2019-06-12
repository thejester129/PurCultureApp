using System;
using System.Collections.Generic;
using System.Text;

namespace PurCultureApp.Models
{
	public enum MenuItemType
	{
		Home,
		Deepcuts,
		Podcast,
		Join,
		Submissions,
		PeaceFields
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
