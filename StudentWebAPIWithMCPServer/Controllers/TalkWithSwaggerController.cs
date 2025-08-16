using ASPController.Dto;
using ASPController.Model;
using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ASPController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TalkWithSwaggerController : ControllerBase
    {
        private readonly ILogger<TalkWithSwaggerController> _logger;

        public TalkWithSwaggerController(ILogger<TalkWithSwaggerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("FetchContentFromUrl")]
        public async Task<string> FetchContentFromUrl(string url)
        {
            var service = new StudentWebAPIWithMCPServer.Service.TalkWithService();
            return await service.FetchContentFromUrl(url);
        }
    }
}

