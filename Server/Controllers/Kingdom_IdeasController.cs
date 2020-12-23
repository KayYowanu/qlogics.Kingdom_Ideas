using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using qlogics.Kingdom_Ideas.Models;
using qlogics.Kingdom_Ideas.Repository;

namespace qlogics.Kingdom_Ideas.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class Kingdom_IdeasController : Controller
    {
        private readonly IKingdom_IdeasRepository _Kingdom_IdeasRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public Kingdom_IdeasController(IKingdom_IdeasRepository Kingdom_IdeasRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _Kingdom_IdeasRepository = Kingdom_IdeasRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Kingdom_Ideas> Get(string moduleid)
        {
            return _Kingdom_IdeasRepository.GetKingdom_Ideass(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Kingdom_Ideas Get(int id)
        {
            Models.Kingdom_Ideas Kingdom_Ideas = _Kingdom_IdeasRepository.GetKingdom_Ideas(id);
            if (Kingdom_Ideas != null && Kingdom_Ideas.ModuleId != _entityId)
            {
                Kingdom_Ideas = null;
            }
            return Kingdom_Ideas;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Kingdom_Ideas Post([FromBody] Models.Kingdom_Ideas Kingdom_Ideas)
        {
            if (ModelState.IsValid && Kingdom_Ideas.ModuleId == _entityId)
            {
                Kingdom_Ideas = _Kingdom_IdeasRepository.AddKingdom_Ideas(Kingdom_Ideas);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Kingdom_Ideas Added {Kingdom_Ideas}", Kingdom_Ideas);
            }
            return Kingdom_Ideas;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Kingdom_Ideas Put(int id, [FromBody] Models.Kingdom_Ideas Kingdom_Ideas)
        {
            if (ModelState.IsValid && Kingdom_Ideas.ModuleId == _entityId)
            {
                Kingdom_Ideas = _Kingdom_IdeasRepository.UpdateKingdom_Ideas(Kingdom_Ideas);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Kingdom_Ideas Updated {Kingdom_Ideas}", Kingdom_Ideas);
            }
            return Kingdom_Ideas;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Kingdom_Ideas Kingdom_Ideas = _Kingdom_IdeasRepository.GetKingdom_Ideas(id);
            if (Kingdom_Ideas != null && Kingdom_Ideas.ModuleId == _entityId)
            {
                _Kingdom_IdeasRepository.DeleteKingdom_Ideas(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Kingdom_Ideas Deleted {Kingdom_IdeasId}", id);
            }
        }
    }
}
