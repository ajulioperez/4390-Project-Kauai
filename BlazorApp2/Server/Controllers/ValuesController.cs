using BlazorApp2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(ApplicationDbContext context, ILogger<ValuesController> logger)
        {
            Context = context;
            _logger = logger;
        }
        [HttpGet("CheckStatus/{url}")]
        public async Task<bool> CheckStatus(string url)
        {
            var ping = new System.Net.NetworkInformation.Ping();

            var result = ping.Send(url);

            if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
              
        }

        [HttpPost("AddLogs")]
        public async Task<string> AddLogs(tbllog log)
        {
            if (log.Name != string.Empty || log.Checked != string.Empty || log.Website != string.Empty)
            {

                var id = Context.Add(log);
                await Context.SaveChangesAsync();
                return "Added Success";
            }
            else
            {
                return "Error while adding";
            }




        }
        [HttpGet("GetList")]
        public async Task<List<tbllog>> GetLogs()
        {
            List<tbllog> Logs = new List<tbllog>();

            Logs = Context.tblLog.ToList();

            return Logs;


        }
    }
}
