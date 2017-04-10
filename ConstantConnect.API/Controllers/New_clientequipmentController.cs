using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Factories.CRM;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace ConstantConnect.API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class New_clientequipmentController : ApiController
    {
        ICRMRepository _crmRepository;
        New_clientequipmentFactory _factory = new New_clientequipmentFactory();
        const int MAXPAGESIZE = 10;

        #region Controllers
        public New_clientequipmentController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_clientequipmentController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/New_clientequipment", 1, Name = "New_clientequipmentForNew_clientroom")]
        public IHttpActionResult Get(Guid new_clientRoomId, string fields = null,string sort = "New_Model",
            int page = 1, int pageSize = MAXPAGESIZE)
        {
            try
            {
                var listOfFields = new List<string>();
                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                var equipment = _crmRepository
                    .GetNew_clientequipmentForRoom(new_clientRoomId)
                    .ApplySort(sort);
                    

                if (equipment == null)
                    return NotFound();

                var totalCount = equipment.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                
                if (pageSize > MAXPAGESIZE)
                    pageSize = MAXPAGESIZE;

                var urlHelper = new UrlHelper(Request);

                var previousLink = page > 1 ? urlHelper.Link("New_clientequipmentForNew_clientroom",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        fields = fields
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("New_clientequipmentForNew_clientroom",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        fields = fields
                    }) : "";


                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = previousLink,
                    nextPageLink = nextLink
                };

                //HttpContext.Current.Response.Headers.Add("X-Pagination",
                //    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
                    //.Skip(pageSize * (page - 1))
                    //.Take(pageSize)
                var result = equipment
                    .ToList()
                    .Select(x => _factory.CreateDataShapedObject(x, listOfFields));
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

        //Use Custom Request Header api-version:2 OR Accept:application/vnd.constantconnectapi.v2+json
        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientequipment/{Id}", 1)]
        [VersionedRoute("new_clientequipment/{Id}", 1)]
        public IHttpActionResult Get(Guid Id, Guid? new_clientRoomId = null, string fields = null)
        {
            try
            {
                var listOfFields = new List<string>();

                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                Repository.Entities.CRM.New_clientequipment equipment = null;

                if (new_clientRoomId == null)
                    equipment = _crmRepository.GetNew_clientequipment(Id, new_clientRoomId);
                else
                {
                    var new_clientEquipmentForNew_clientRoom = _crmRepository.GetNew_clientequipmentForRoom(new_clientRoomId);

                    if (new_clientEquipmentForNew_clientRoom != null)
                        equipment = new_clientEquipmentForNew_clientRoom.FirstOrDefault(x => x.New_clientequipmentId == Id);
                }

                if (equipment != null)
                {
                    var returnValue = _factory.CreateDataShapedObject(equipment, listOfFields);
                    return Ok(returnValue);
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

        
        public IHttpActionResult Put(Guid Id, [FromBody]DTO.CRM.New_clientequipment entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                var map = _factory.CreateNew_clientequipment(entity);
                var result = _crmRepository.UpdateNew_clientequipment(map);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var updated = _factory.CreateNew_clientequipment(result.Entity);
                    return Ok(updated);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                    return NotFound();

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

        [HttpPatch]
        [VersionedRoute("patch_new_clientequipment/{Id}", 1)]
        public IHttpActionResult Patch(Guid Id, [FromBody]JsonPatchDocument<DTO.CRM.New_clientequipment> entityPatchDocument)
        {
            try
            {
                if (entityPatchDocument == null)
                    return BadRequest();

                var entity = _crmRepository.GetNew_clientequipment(Id, null);
                if (entity == null)
                    return NotFound();

                var map = _factory.CreateNew_clientequipment(entity);
                entityPatchDocument.ApplyTo(map);
                var result = _crmRepository.UpdateNew_clientequipment(_factory.CreateNew_clientequipment(map));
                if(result.Status == RepositoryActionStatus.Updated)
                {
                    var patched = _factory.CreateNew_clientequipment(result.Entity);
                    return Ok(patched);
                }

                if (result.Status == RepositoryActionStatus.NothingModified)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }

    }
}
