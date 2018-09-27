/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.NationalSocieties;

namespace Web
{
    /// <summary>
    /// API for NationalSociety
    /// </summary>
    [Route("api/nationalsociety")]
    public class NationalSocietyController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly INationalSocieties _nationalSociety;

        
        public NationalSocietyController(
            INationalSocieties nationalSociety,
            ILogger<ProjectController> logger
        )
        {
            _logger = logger;
            _nationalSociety = nationalSociety;
        }

        [HttpGet]
        public IEnumerable<NationalSociety> GetAllNationalSocieties()
        {
            return _nationalSociety.GetAll();
        }

        [HttpPost]
        public void AddNationalSociety()
        {
            //TODO: Integerate to new DoLittle
            //var id = Guid.NewGuid();
            //Apply(id, new NationalSocietyCreated
            //{
            //    Name = Guid.NewGuid().ToString(),
            //    Id = Guid.NewGuid(),
            //    TimezoneOffsetFromUtcInMinutes = (int) TimeZoneInfo.Local.BaseUtcOffset.TotalMinutes
            //});
        }
    }
}