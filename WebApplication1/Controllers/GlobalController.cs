using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class GlobalController : ApiController
    {
        SankoRepository repo = new SankoRepository();
        [Route("api/Global/ins")]
        [HttpPost]
        public IHttpActionResult Insert([FromBody] SankoModel model)
        {
            var data = repo.InsertData(model);
            return Ok(data);

            
        }

        [Route("api/Global/all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repo.GetAll();
            return Ok(data);
        }

        [Route("api/Global/Del")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody] SankoModel model)
        {
            var res = repo.DeleteData(model);
            return Ok(res);
        }

        [Route("api/Global/ById/{id}")]
        [HttpGet]
        public IHttpActionResult GetbyId(string id)
        {
            var res = repo.GetById(id);
            return Ok(res);
        }


        [Route("api/Global/Update/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateData([FromBody] SankoModel model,string id)
        {
            var res = repo.UpdateData(model,id);
            return Ok(res);
        }
    }
}
