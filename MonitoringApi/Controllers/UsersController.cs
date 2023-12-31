﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonitoringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;

        public UsersController(ILogger<UsersController> logger)
        {
            this.logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("some random exception");
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Logging
            //if (id < 0 || id > 100) {
            //    logger.LogWarning("the id of {Id} was invallid", id);
            //    return BadRequest("Index was out of range");
            //}

            //return Ok(id);
            try
            {
                if (id < 0 || id > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                    return Ok(id);
            } 
            catch (Exception ex)
            {
                logger.LogWarning( ex, "the id of {Id} was invallid", id);
                return BadRequest("Index was out of range");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
