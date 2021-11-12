using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PowerplantChallenge.Application.Dtos;
using PowerplantChallenge.Application.Interfaces;
using PowerplantChallenge.Application.Mappers;
using PowerplantChallenge.Application.Services;

namespace PowerplantChallenge.Api.Controllers
{
    [Route("api/ProductionPlan")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanService _service;

        public ProductionPlanController(IProductionPlanService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<IEnumerable<object>> Post([FromBody] PlanDto planDto)
        {
            var plan = planDto.Map();
            return Ok(_service.GetProductionPlan(plan));
        }
    }
}