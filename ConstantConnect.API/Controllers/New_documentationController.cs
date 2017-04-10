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
    [RoutePrefix("api")]
    [EnableCors("*", "*", "*")]
    public class New_documentationController : ApiController
    {
        ICRMRepository _crmRepository;
        New_documentationFactory _factory = new New_documentationFactory();
        const int MAXPAGESIZE = 10;

        #region Controllers
        public New_documentationController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public New_documentationController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/New_documentation", 1, Name = "New_documentationForNew_clientroom")]
        public IHttpActionResult Get(Guid new_clientRoomId, string fields = null, string sort = "New_name",
            int page = 1, int pageSize = MAXPAGESIZE)
        {
            try
            {
                var listOfFields = new List<string>();
                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                var documents = _crmRepository
                    .GetNew_documentation(new_clientRoomId)
                    .ApplySort(sort);


                if (documents == null)
                    return NotFound();

                if (pageSize > MAXPAGESIZE)
                    pageSize = MAXPAGESIZE;

                var totalCount = documents.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);

                var previousLink = page > 1 ? urlHelper.Link("New_documentationForNew_clientroom",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        fields = fields
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("New_documentationForNew_clientroom",
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

                HttpContext.Current.Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                var result = documents
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
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
        [VersionedRoute("new_clientrooms/{new_clientRoomId}/new_documentation/{Id}", 1)]
        [VersionedRoute("new_documentation/{Id}", 1)]
        public IHttpActionResult Get(Guid Id, Guid? new_clientRoomId = null, string fields = null)
        {
            try
            {
                var listOfFields = new List<string>();

                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                Repository.Entities.CRM.New_documentation document = null;

                if (new_clientRoomId == null)
                    document = _crmRepository.GetNew_documentation(Id, new_clientRoomId);
                else
                {
                    var new_documentationForNew_clientRoom = _crmRepository.GetNew_documentation(new_clientRoomId);

                    if (new_documentationForNew_clientRoom != null)
                        document = new_documentationForNew_clientRoom.FirstOrDefault(x => x.New_documentationId == Id);
                }

                if (document != null)
                {
                    var returnValue = _factory.CreateDataShapedObject(document, listOfFields);
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
    }
}