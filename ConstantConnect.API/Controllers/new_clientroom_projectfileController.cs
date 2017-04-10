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
    public class new_clientroom_projectfileController : ApiController
    {
        ICRMRepository _repository;
        public new_clientroom_projectfileController(ICRMRepository repo)
        {
            _repository = repo;
        }
        public new_clientroom_projectfileController()
        {
            _repository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientroom_projectfile", 1, Name = "new_clientroom_projectfileForNew_clientroom")]
        public IHttpActionResult Get(Guid new_clientRoomId)
        {
            try
            {
                var documents = _repository
                    .Getnew_clientroom_projectfile(new_clientRoomId);


                if (documents == null)
                    return NotFound();

                var totalCount = documents.Count();

                var result = documents.ToList();
                    
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

        //Use Custom Request Header api-version:2 OR Accept:application/vnd.constantconnectapi.v2+json
        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientroom_projectfile/{Id}", 1)]
        [VersionedRoute("new_clientroom_projectfile/{Id}", 1)]
        public IHttpActionResult Get(Guid Id, Guid? new_clientRoomId = null)
        {
            try
            {
                Repository.Entities.CRM.new_clientroom_projectfile entity = null;

                if (new_clientRoomId == null)
                    entity = _repository.Getnew_clientroom_projectfile(Id, new_clientRoomId);
                else
                {
                    var new_clientroom_projectfileForNew_clientRoom = _repository.Getnew_clientroom_projectfile(new_clientRoomId);

                    if (new_clientroom_projectfileForNew_clientRoom != null)
                        entity = new_clientroom_projectfileForNew_clientRoom.FirstOrDefault(x => x.new_clientroom_projectfileId == Id);
                }

                if (entity != null)
                {
                    return Ok(entity);
                }
                else
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
