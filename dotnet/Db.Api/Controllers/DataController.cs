﻿using System.Linq;
using Db.Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Db.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataStore _store;

        public DataController(DataStore store)
        {
            _store = store;
        }

        [HttpGet]
        public JsonResult Get()
        {
            using (var reader = _store.BeginRead())
            {
                var values = reader.Data().ToList();

                return new JsonResult(values);
            }
            
        }

        [HttpPost]
        [Route("{key}")]
        public ActionResult Set(string key, [FromBody] object value)
        {
            using (var writer = _store.BeginWrite())
            {
                writer.Set(key, value);

                return Ok();
            }
        }
    }
}