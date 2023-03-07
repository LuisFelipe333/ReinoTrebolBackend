using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ReinoTrebolBackend.Resources;
using ReinoTrebolBackend.Models;
using Newtonsoft.Json;

namespace ReinoTrebolBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        [Route("getApplications")]
        public dynamic GetApplications()
        {
            DataTable dtApplications = DBDatos.Listar("GetApplications");
            string jsonApplications = JsonConvert.SerializeObject(dtApplications);
            return JsonConvert.DeserializeObject<List<Application>>(jsonApplications);
        }


    }
}
