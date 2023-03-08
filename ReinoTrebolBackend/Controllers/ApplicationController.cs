using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ReinoTrebolBackend.Resources;
using ReinoTrebolBackend.Models;
using Newtonsoft.Json;
using ReinoTrebolBackend.Models.Enum;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace ReinoTrebolBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        [Route("ConsultarSolicitudes")]
        public dynamic GetApplications()
        {
            DataTable dtApplications = DBDatos.Listar("GetApplications");
            string jsonApplications = JsonConvert.SerializeObject(dtApplications);
            return JsonConvert.DeserializeObject<List<Request>>(jsonApplications);
        }

        [HttpPost]
        [Route("EnviarSolicitud")]
        public dynamic SaveApplication(Request application)
        {
            Random rng = new Random();
            Validator validator = new Validator();
            dynamic success = validator.VerifyValues(application.name, application.lastName, application.identification, application.age, (int)application.magicalAff);
            string message;
            if (success.exito == true)
            {
                List<Parametro> parametros = new List<Parametro>()
                {
                    new Parametro("@sName", application.name),
                    new Parametro("@sLastName", application.lastName),
                    new Parametro("@sIdentification", application.identification),
                    new Parametro("@iAge", application.age.ToString()),
                    new Parametro("@sMagicalAff", application.magicalAff.ToString()),
                    new Parametro("@bStatus", "1"),
                    new Parametro("@iGrimoireLevel" , ((GrimoireLevel)rng.Next(1, 6)).ToString())
                };

                dynamic sucess = DBDatos.Ejecutar("AddApplications", parametros);
                message = sucess.message;
                return message;
            }
            else
            {
                message = success.message;
            }


            return message;

        }        

        [HttpPut]
        [Route("ActualizarSolicitud")]
        public dynamic UpdateApplication(Request application)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                    new Parametro("@iId", application.id.ToString()),
                    new Parametro("@sName", application.name),
                    new Parametro("@sLastName", application.lastName),
                    new Parametro("@sIdentification", application.identification),
                    new Parametro("@iAge", application.age.ToString()),
                    new Parametro("@sMagicalAff", application.magicalAff.ToString())
            };

            dynamic sucess = DBDatos.Ejecutar("UpdateApplications", parametros);
            string message = sucess.message;
            return message;
        }

        




    }
}
