﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework23.Models;
using CitiesData.Core;

namespace Homework23.Controllers
{
	[ApiController]
	[Route("api/cities")]
	public class CitiesController : ControllerBase
	{
		private readonly ILogger<CitiesController> _logger;
		private readonly ICitiesDataStore _store;

		public CitiesController(
			ILogger<CitiesController> logger,
			ICitiesDataStore store)
		{
			_logger = logger;
			_store = store;
		}

		[HttpGet]
		public IActionResult GetCities()
		{
			if (_store.Cities == null)
				return NotFound();

			var getModelList = _store
				.Cities
				.Select(c => new CityGetModel(c))
				.ToList();

			return Ok(getModelList);
		}

		[HttpGet("{id}", Name = "GetCityById")]
		public IActionResult GetCity(int id)
		{
			var cityDto = _store.Cities.FirstOrDefault(x => x.Id == id);

			if (cityDto == null)
			{
				// 404 Not Found
				return NotFound("404 Not Found");
			}

			// 200 OK
			return Ok(new CityGetModel(cityDto));
		}

		[HttpPost]
		public IActionResult CreateCity([FromBody] CityCreateModel cityCreateModel)
		{
			if (cityCreateModel == null)
			{
				return BadRequest();
			}

			if (_store.Cities.FirstOrDefault(c => c.Name == cityCreateModel.Name) != null)
			{
				return Conflict();
			}

			int newCityId = _store.Cities.Max(x => x.Id) + 1;
			CityDto cityDto = cityCreateModel.ToDto(newCityId);

			_store.Cities.Add(cityDto);

			var cityGetModel = new CityGetModel(cityDto);

			return CreatedAtRoute(
				"GetCityById",
				new { id = cityDto.Id },
				cityGetModel);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			{
				CityDto cityDto = _store.Cities.FirstOrDefault(x => x.Id == id);

				if (cityDto == null)
				{
					// 404 Not Found
					return NotFound("404 Not Found");
				}

				bool ok = _store.Cities.Remove(cityDto);

				if (!ok)
				{
					throw new Exception("Cannot remove the city: unexpected error occured.");
				}

				// 200 OK
				return NoContent();
			}
		}

		[HttpPut("{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityReplaceModel cityReplaceModel)
		{
			if (cityReplaceModel == null)
			{
				return BadRequest();
			}

			var cityDto = _store.Cities.FirstOrDefault(x => x.Id == id);

			if (cityDto == null)
			{
				// 404 Not Found
				return NotFound("404 Not Found");
			}

			cityDto.Name = cityReplaceModel.Name;
			cityDto.Description = cityReplaceModel.Description;

			// it will be valid but but also we can return 200 OK
			// return NoContent();

			// 200 OK
			return Ok(new CityGetModel(cityDto));
		}
	}
}
