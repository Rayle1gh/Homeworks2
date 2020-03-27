using System.ComponentModel.DataAnnotations;
using CitiesData.Core;
using Homework23.Validation;

namespace Homework23.Models
{
	public class CityCreateModel
	{
		[Required(ErrorMessage = "The name of the city is a required field")]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		[DifferentValue(OtherProperty = "Name")]
		public string Description { get; set; }

		public CityCreateModel()
		{
		}

		public CityCreateModel(CityDto city)
		{
			Name = city.Name;
			Description = city.Description;
		}

		public CityDto ToDto(int id)
		{
			var dto = new CityDto
			{
				Id = id,
				Name = Name,
				Description = Description
			};

			return dto;
		}
	}
}
