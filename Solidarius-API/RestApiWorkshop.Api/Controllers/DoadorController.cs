using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("posts")]
    public class DoadorController : ControllerBase
    {
        // Note Old Posts
        private readonly IMyDatabase myDatabase;
        public DoadorController(IMyDatabase myDatabase)
        {
            this.myDatabase = myDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = myDatabase.Doador
                .ToList();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            var post = myDatabase.Doador
                .SingleOrDefault(s => s.Id == id);

            return Ok(post);
        }
    }
}
