using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Factories.CRM;
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
    
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class New_clientequipmemtipdataController : ApiController
    {
        ICRMRepository _crmRepository;
        New_clientequipmemtipdataFactory _Factory = new New_clientequipmemtipdataFactory();

        const int MAXPAGESIZE = 10;
        public New_clientequipmemtipdataController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_clientequipmemtipdataController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientequipmemtipdata", 1, Name = "New_clientequipmemtipdataForNew_clientroom")]
        public IHttpActionResult Get(Guid new_clientRoomId, string fields = null, string sort = "CreatedOn", int statecode = 0,
            int page = 1, int pageSize = MAXPAGESIZE)
        {
            try
            {
                var listOfFields = new List<string>();
                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                var new_clientequipmemtipdatas = _crmRepository
                    .GetNew_clientequipmentipdatas(new_clientRoomId)
                    .ApplySort(sort)
                    .Where(x => x.statecode == statecode);

                if (new_clientequipmemtipdatas == null)
                    return NotFound();

                if (pageSize > MAXPAGESIZE)
                    pageSize = MAXPAGESIZE;

                var totalCount = new_clientequipmemtipdatas.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);

                var previousLink = page > 1 ? urlHelper.Link("New_clientequipmemtipdataForNew_clientroom",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        sort = sort,
                        fields = fields,
                        statecode = statecode
                    }) : "";


                var nextLink = page < totalPages ? urlHelper.Link("New_clientequipmemtipdataForNew_clientroom",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        sort = sort,
                        fields = fields,
                        statecode = statecode
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

                HttpContext.Current.Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                var result = new_clientequipmemtipdatas//.ToList().Select(x => _Factory.CreateDataShapedObject(x, listOfFields));
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _Factory.CreateDataShapedObject(x, listOfFields));
                return Ok(result);
                
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //Use Custom Request Header api-version:2 OR Accept:application/vnd.constantconnectapi.v2+json
        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_clientequipmemtipdata/{New_clientequipmemtipdataId}", 1)]
        [VersionedRoute("New_clientequipmemtipdata/{New_clientequipmemtipdataId}", 1)]
        public IHttpActionResult Get(Guid New_clientequipmemtipdataId, Guid? new_clientRoomId = null, string fields = null)
        {
            try
            {
                var listOfFields = new List<string>();

                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                Repository.Entities.CRM.New_clientequipmemtipdata new_clientequipmemtipdata = null;

                if (new_clientRoomId == null)
                    new_clientequipmemtipdata = _crmRepository.GetNew_clientequipmentipdata(New_clientequipmemtipdataId, new_clientRoomId);
                else
                {
                    var new_clientequipmemtipdataForNew_clientRoom = _crmRepository.GetNew_clientequipmentipdatas(new_clientRoomId);

                    if (new_clientequipmemtipdataForNew_clientRoom != null)
                        new_clientequipmemtipdata = new_clientequipmemtipdataForNew_clientRoom.FirstOrDefault(x => x.New_clientequipmemtipdataId == New_clientequipmemtipdataId);
                }

                if (new_clientequipmemtipdata != null)
                {
                    var returnValue = _Factory.CreateDataShapedObject(new_clientequipmemtipdata, listOfFields);
                    return Ok(returnValue);
                }
                else
                    return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
