using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace ConstantConnect.API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class new_clientrooms_warrantylinesController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Constructors
        public new_clientrooms_warrantylinesController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public new_clientrooms_warrantylinesController(ICRMRepository crmRepository)
        {
            _crmRepository = crmRepository;
        }

        #endregion

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientrooms_warrantylines", 1)]
        public IHttpActionResult Get(Guid new_clientRoomId)
        {
            try
            {
                var data = _crmRepository
                    .Getnew_clientrooms_warrantylines(new_clientRoomId);


                if (data == null)
                    return NotFound();

                var totalCount = data.Count();
                
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
    }
}
