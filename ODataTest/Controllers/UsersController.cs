﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataTest.Controllers
{
	public class UsersController : ODataController
	{
		private readonly TestContext _db;

		public UsersController(TestContext db)
		{
			_db = db;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_db.Users);
		}
	}
}
