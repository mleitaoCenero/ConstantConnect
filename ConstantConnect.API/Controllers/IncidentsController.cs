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
    
    [EnableCors("*","*","*")]
    [RoutePrefix("api")]
    public class IncidentsController : ApiController
    {
        ICRMRepository _crmRepository;
        IncidentFactory _incidentFactory = new IncidentFactory();

        const int MAXPAGESIZE = 10;
        public IncidentsController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public IncidentsController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        [VersionedRoute("new_clientrooms/{new_clientRoomId}/incidents", 1, Name = "IncidentsForNew_clientroom")]
        public IHttpActionResult Get(Guid new_clientRoomId, string fields = null, string sort="CreatedOn", int statecode=0,
            int page = 1, int pageSize = MAXPAGESIZE)
        {
            try
            {
                var listOfFields = new List<string>();
                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                var incidents = _crmRepository
                    .GetIncidents(new_clientRoomId)
                    .ApplySort(sort)
                    .Where(x => x.StateCode == statecode);

                if (incidents == null)
                    return NotFound();

                if (pageSize > MAXPAGESIZE)
                    pageSize = MAXPAGESIZE;

                var totalCount = incidents.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);

                var previousLink = page > 1 ? urlHelper.Link("IncidentsForNew_clientroom",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        sort = sort,
                        fields = fields,
                        statecode = statecode
                    }) : "";


                var nextLink = page < totalPages ? urlHelper.Link("IncidentsForNew_clientroom",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        sort = sort,
                        fields = fields,
                        statecode = statecode
                    }): "";


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

                var incidentsResult = incidents
                    .Skip(pageSize * (page -1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _incidentFactory.CreateDataShapedObject(x, listOfFields));
                return Ok(incidentsResult);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //Use Custom Request Header api-version:2 OR Accept:application/vnd.constantconnectapi.v2+json
        [VersionedRoute("new_clientrooms/{new_clientRoomId}/incidents/{incidentId}", 1)]
        [VersionedRoute("incidents/{incidentId}", 1)]
        public IHttpActionResult Get(Guid incidentId, Guid? new_clientRoomId = null, string fields = null)
        {
            try
            {
                var listOfFields = new List<string>();

                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                Repository.Entities.CRM.Incident incident = null;

                if (new_clientRoomId == null)
                    incident = _crmRepository.GetIncident(incidentId, new_clientRoomId);
                else
                {
                    var incidentsForNew_clientRoom = _crmRepository.GetIncidents(new_clientRoomId);

                    if (incidentsForNew_clientRoom != null)
                        incident = incidentsForNew_clientRoom.FirstOrDefault(x => x.IncidentId == incidentId);
                }

                if (incident != null)
                {
                    var returnValue = _incidentFactory.CreateDataShapedObject(incident, listOfFields);
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


        //[VersionedRoute("incidents/tickettrends/", 1)]
        //public IHttpActionResult Get(DateTime startDate, DateTime endDate, string groupBy = null, Guid? new_clientRoomId = null, string incidentSubject =null)
        //{
        //   // string[] ownerId = TokenIdentityHelper.GetIdFromToken();
        //    var userId = Guid.Parse("3EB11A44-B95B-DC11-BE3C-000D9DDCDAF3");

        //    try
        //    {
        //        var entity = _crmRepository.GetCRMTicketTrends(userId, startDate, endDate, groupBy, new_clientRoomId, incidentSubject);
        //        if (entity != null)
        //            return Ok(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return InternalServerError();
        //    }

        //    return NotFound();

        //}
    }
}
