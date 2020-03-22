using System;
using System.Linq;
using System.Threading.Tasks;
using Homework22.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework22.Controllers
{
	[ApiController]
	[Route("cities")]
	public class CitiesController : ControllerBase
	{
		private CitiesDataStore _store;

		public CitiesController()
		{
			_store = CitiesDataStore.GetInstance();
		}

		[HttpGet()]
		public IActionResult GetCities()
		{
			if (_store.Cities == null)
				return NotFound();
			return new JsonResult(_store.Cities);
		}

		[HttpGet("{id}", Name = "GetCityById")]
		public IActionResult GetCity(int id)
		{
			var city = _store.Cities.FirstOrDefault(x => x.Id == id);

			if (city == null)
			{
				// 200 OK
				return NotFound("404 Not Found");
			}

			// 404 Not Found
			return Ok(city);
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] City city)
		{
			if (_store.Cities.FirstOrDefault(
					x => x.Id == city.Id
						 || x.Name == city.Name) != null)
			{
				return Conflict();
			}

			_store.Cities.Add(city);

			return CreatedAtRoute("GetCityById", new { id = city.Id }, city);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			{
				City city = _store.Cities.FirstOrDefault(x => x.Id == id);

				if (city == null)
				{
					// 404 Not Found
					return NotFound("404 Not Found");
				}

				bool ok = _store.Cities.Remove(city);

				if (!ok)
				{
					throw new Exception("Cannot remove the city: unexpected error occured.");
				}

				// 200 OK
				return NoContent();
			}
		}

		[HttpPut("{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] City city)
		{
			if (city == null)
			{
				return BadRequest();
			}

			var newCity = _store.Cities.FirstOrDefault(x => x.Id == id);

			if (newCity == null)
			{
				// 404 Not Found
				return NotFound("404 Not Found");
			}

			newCity.Name = city.Name;

			// it will be valid but but also we can return 200 OK
			// return NoContent();

			// 200 OK
			return Ok(new City());
		}
	}
}
