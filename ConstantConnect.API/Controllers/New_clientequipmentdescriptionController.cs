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
    public class New_clientequipmentdescriptionController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Controllers
        public New_clientequipmentdescriptionController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_clientequipmentdescriptionController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion

        [VersionedRoute("new_clientequipmentdescription/{Id}", 1)]
        public IHttpActionResult Get(Guid Id)
        {
            try
            {
                var entity = _crmRepository.GetNew_clientequipmentdescription(Id);

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

        [VersionedRoute("new_clientequipmentdescription", 1)]
        public IHttpActionResult Get()
        {
            try
            {
                var entity = _crmRepository.GetNew_clientequipmentdescription();

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
