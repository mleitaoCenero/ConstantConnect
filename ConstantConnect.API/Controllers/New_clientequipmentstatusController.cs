using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ConstantConnect.API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class New_clientequipmentstatusController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Controllers
        public New_clientequipmentstatusController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_clientequipmentstatusController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion


        [VersionedRoute("new_clientequipmentstatus/{Id}", 1)]
        public IHttpActionResult Get(Guid Id)
        {
            try
            {
                var entity = _crmRepository.GetNew_clientequipmentstatus(Id);

                if (entity != null)
                    return Ok(entity);

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

        [VersionedRoute("new_clientequipmentstatus", 1)]
        public IHttpActionResult Get()
        {
            try
            {
                var entity = _crmRepository.GetNew_clientequipmentstatus();

                if (entity != null)
                    return Ok(entity);

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
    }
}
