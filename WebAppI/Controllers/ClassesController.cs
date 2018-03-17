using CST356_lab3.Data;
using CST356_lab3.Data.Entities;
using CST356_lab3.repository;
using CST356_lab3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppI.Controllers
{
    public class ClassesController : ApiController
    {
        private readonly Iservice _Iservice;

       
        public ClassesController()
        {

            _Iservice = new Service(new ClassRepo(new AppDb()));
           
        }

        [Route("WebAppI/Classes")]
        public IEnumerable<Classes> GetAllClasses()
        {
            return _Iservice.GetAllClasses();

        }

        public IHttpActionResult GetClass(int id)
        {
            try
            {
                var Class = _Iservice.GetClass(id);
                if (Class == null)
                {
                    return NotFound();
                }
                return Ok(Class);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }

}

