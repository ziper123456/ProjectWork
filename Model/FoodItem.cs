using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsOrderAPI.Models
{
	[Table("FoodItem")]
	public class FoodItem
	{
		[Key]
		public int Id { get; set; }
		public string ImgSource { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }
	}
}
