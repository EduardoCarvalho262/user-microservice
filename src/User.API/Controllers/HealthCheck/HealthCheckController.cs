﻿using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers.HealthCheck
{

    [ApiController]
    [Route("api/v1")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("ping")]
        public string Ping()
        {
            return "Pong";
        }
    }
}
