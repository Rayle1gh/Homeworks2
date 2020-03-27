using System.ComponentModel.DataAnnotations;
using Homework23.Validation;
using CitiesData.Core;


namespace Homework23.Models
{
	public class CityGetModel
	{
		[Range(1, 2147483647)]
		public int Id { get; set; }

		[StringLength(100)]
		[Required(ErrorMessage = "The name of the city is a required field")]
		public string Name { get; set; }

		[StringLength(255)]
		[DifferentValue(OtherProperty = "Name")]
		public string Description { get; set; }

		public CityGetModel()
		{
		}

		public CityGetModel(CityDto city)
		{
			Id = city.Id;
			Name = city.Name;
			Description = city.Description;
		}
	}
}
