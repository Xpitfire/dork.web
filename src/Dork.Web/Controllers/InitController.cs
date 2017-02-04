﻿using Dork.Core.Domain;
using Dork.Core.Service;
using Dork.Service.Default.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dork.Web.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class InitController : Controller
    {
        private readonly IEntityService<User> _userService;
        private readonly IEntityService<Profile> _profileService;

        public InitController(IEntityService<User> userService, IEntityService<Profile> profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }


        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetAllUsers()
        {
            var data =await _userService.GetAllAsync();

            return Ok(data);
        }

        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetAllProfiles()
        {
            var data = await _profileService.GetAllAsync();

            return Ok(data);
        }


        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateNewUser([FromBody]User user)
        {
            await _userService.CreateElementAsync(user);
            return Ok("Inserted");
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> CreateNewProfile([FromBody]Profile profile)
        {
            await _profileService.CreateElementAsync(profile);
            return Ok("Inserted");
        }

    }
}
