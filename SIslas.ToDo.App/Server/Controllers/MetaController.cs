using Microsoft.AspNetCore.Mvc;
using SIslas.ToDo.App.Domain.IDomains;
using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Model.DataBase;

namespace SIslas.ToDo.App.Server.Controllers
{
    [Route("api/meta")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IMetaDomain metaDomain;
        public MetaController(IMetaDomain metaDomain)
        {
            this.metaDomain = metaDomain;
        }

        [HttpPost("add")]
        public ActionResult<Response<bool>> Add([FromBody] Meta data)
        {
            var response = metaDomain.Add(data);
            return Ok(response);
        }


        [HttpGet("getAll")]
        public async Task<ActionResult<Response<List<Meta>>>> GetAll()
        {
            var response = await metaDomain.GetAll();
            return Ok(response);
        }


        [HttpPut("update")]
        public ActionResult<Response<bool>> Update(Meta data)
        {
            var response = metaDomain.Update(data);
            return Ok(response);
        }


        [HttpDelete("remove")]
        public ActionResult<Response<bool>> Remove(int IdMeta)
        {
            var response = metaDomain.Remove(IdMeta);
            return Ok(response);
        }
    }
}
