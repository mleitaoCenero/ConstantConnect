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
    public class new_manufacturerController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Controllers
        public new_manufacturerController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public new_manufacturerController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion


        [VersionedRoute("new_manufacturer/{Id}", 1)]
        public IHttpActionResult Get(Guid Id)
        {
            try
            {
                var manufacturer = _crmRepository.GetNew_manufacturer(Id);

                if (manufacturer != null)
                    return Ok(manufacturer);

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

        [VersionedRoute("new_manufacturer", 1)]
        public IHttpActionResult Get()
        {
            try
            {
                var manufacturer = _crmRepository.GetNew_manufacturer();

                if (manufacturer != null)
                    return Ok(manufacturer);

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
