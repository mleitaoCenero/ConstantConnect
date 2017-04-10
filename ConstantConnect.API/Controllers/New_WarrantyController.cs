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
    public class New_WarrantyController : ApiController
    {
        ICRMRepository _repo;

        #region Constructors
        public New_WarrantyController()
        {
            _repo = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_WarrantyController(ICRMRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_warranty", 1)]
        public IHttpActionResult Get(Guid new_clientRoomId)
        {
            try
            {
                var data = _repo
                    .GetNew_Warranty(new_clientRoomId);

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
