using Microsoft.AspNetCore.Mvc;
using SIslas.ToDo.App.Domain.IDomains;
using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Model.DataBase;

namespace SIslas.ToDo.App.Server.Controllers
{
    [Route("api/tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaDomain tareaDomain;
        public TareaController(ITareaDomain tareaDomain)
        {
            this.tareaDomain = tareaDomain;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Response<bool>>> Add([FromBody] Tarea data)
        {
            var response = await tareaDomain.Add(data);
            return Ok(response);
        }


        [HttpGet("getAllByIdMeta")]
        public async Task<ActionResult<Response<List<Tarea>>>> GetAll(int IdMeta)
        {
            var response = await tareaDomain.GetAllByIdMeta(IdMeta);
            return Ok(response);
        }


        [HttpPut("update")]
        public ActionResult<Response<bool>> Update(Tarea data)
        {
            var response = tareaDomain.Update(data);
            return Ok(response);
        }


        [HttpDelete("remove")]
        public async Task<ActionResult<Response<bool>>> Remove(int IdTarea)
        {
            var response = await tareaDomain.Remove(IdTarea);
            return Ok(response);
        }

        [HttpPut("set-importante")]
        public ActionResult<Response<bool>> SetImportante(Tarea data)
        {
            var response = tareaDomain.SetImportante(data);
            return Ok(response);
        }

        [HttpGet("completar-tarea")]
        public async Task<ActionResult<Response<bool>>>  CompletarTarea(int IdTarea)
        {
            var response = await tareaDomain.CompletarTarea(IdTarea);
            return Ok(response);
        }

        [HttpGet("getById")]
        public ActionResult<Response<Tarea>> GetBydId(int IdTarea)
        {
            var response = tareaDomain.GetById(IdTarea);
            return Ok(response);
        }
    }
}
