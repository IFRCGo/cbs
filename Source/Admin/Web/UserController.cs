/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.Users;

namespace Web
{
    [Route("api/user")]
    public class UserController : Controller
    {
        readonly IUsers _users;
        readonly ILogger<ProjectController> _logger;

        public UserController(
            IUsers users,
            ILogger<ProjectController> logger)
        {
            _users = users;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get(Guid nationalSocietyId)
        {
            return _users.GetByNationalSocietyId(nationalSocietyId);
        }
    }
}
*/
