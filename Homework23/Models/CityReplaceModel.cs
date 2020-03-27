using System.ComponentModel.DataAnnotations;
using CitiesData.Core;
using Homework23.Validation;

namespace Homework23.Models
{
	public class CityReplaceModel
	{
		[Required(ErrorMessage = "The name of the city is a required field")]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		[DifferentValue(OtherProperty = "Name")]
		public string Description { get; set; }

		public CityReplaceModel()
		{
		}

		public CityReplaceModel(CityDto city)
		{
			Name = city.Name;
			Description = city.Description;
		}
	}
}
