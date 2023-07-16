using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using ResumeAPI.Models;

namespace ResumeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorCountController : ControllerBase
    {
        private readonly IDynamoDBContext _context;
        private readonly ILogger<VisitorCountController> _logger;

        private readonly string siteUuid = "philipamwata.net";

        public VisitorCountController(IDynamoDBContext context, ILogger<VisitorCountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetVisitorCount")]
        public async Task<IActionResult> Get()
        {
            var visitorCount = await _context.LoadAsync<VisitorCount>(siteUuid);
            if (visitorCount == null) return NotFound();
            return Ok(visitorCount);
        }

        [HttpPost(Name = "IncrementVisitorCount")]
        public async Task<IActionResult> Post()
        {
            var item = await _context.LoadAsync<VisitorCount>(siteUuid) ?? new VisitorCount { SiteUuid = siteUuid };
            item.Count++;
            await _context.SaveAsync(item);
            return Ok(item.Count);
        }
    }
}