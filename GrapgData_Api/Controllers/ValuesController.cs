using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrapgData_Api.Models;
namespace GrapgData_Api.Controllers
{
    public class ValuesController : ApiController
    {
        GraphDataEntities3 entity = new GraphDataEntities3();
        [Route("GetAllData")]
        public IEnumerable<StudentMark> Get()
        {
            List<StudentMark> data1 = new List<StudentMark>();
            data1 = entity.StudentMarks.ToList();
            
           // List<StudentMark> top5 = new List<StudentMark>();

            var top5 = data1.OrderByDescending(student => student.Total).Take(5);

            return data1;
            }


        [Route("UniqueName")]
        [HttpGet]
        public IEnumerable<string> GetUniqueNames()
        {
            return entity.StudentMarks?.Select(i => i.Name).Distinct();
        
        }




        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
