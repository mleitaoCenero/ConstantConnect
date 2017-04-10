using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ConstantConnect.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class DocumentsController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Constructor
        public DocumentsController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        public DocumentsController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }
        #endregion

        [VersionedRoute("documents/projectfiles/{roomid}/", 1)]
        public IHttpActionResult GetProjectFiles(Guid roomid)
        {
            try
            {
                var projectFiles = _crmRepository.GetProjectFiles(roomid);
                if (projectFiles != null)
                    return Ok(projectFiles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

            return NotFound();
        }

        [VersionedRoute("documents/documents/{roomid}/", 1)]
        public IHttpActionResult GetDocuments(Guid roomid)
        {
            try
            {
                var documents = _crmRepository.GetRoomDocuments(roomid);
                if (documents != null)
                    return Ok(documents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

            return NotFound();
        }

        [HttpPatch]
        [VersionedRoute("documents/patchdocument/{documentid}", 1)]
        public IHttpActionResult UpdateDocument(Guid documentId, [FromBody]JsonPatchDocument<DTO.Shared.Document> entityPatchDocument)
        {
            try
            {
                if (entityPatchDocument == null)
                    return BadRequest();

                var entity = _crmRepository.GetNew_documentation(documentId);
                if (entity == null)
                    return NotFound();


                //var map = .CreateNew_clientequipment(entity);
                //entityPatchDocument.ApplyTo(map);
                //var result = _crmRepository.UpdateNew_clientequipment(_factory.CreateNew_clientequipment(map));


                //if (result.Status == RepositoryActionStatus.Updated)
                //{
                //    var patched = _factory.CreateNew_clientequipment(result.Entity);
                //    return Ok(patched);
                //}

                //if (result.Status == RepositoryActionStatus.NothingModified)
                //{
                //    return StatusCode(HttpStatusCode.NoContent);
                //}

                //return BadRequest();


                string name = null;
                Guid? organizationID = null;
                Guid? projectID = null;
                Guid? projectRoomID = null;
                Guid? clientRoomID = null;
                string notes = null;
                int? type = null;
                bool? share = null;
                int? status = null;

                var document = _crmRepository.Document_Write(documentId, name, organizationID, projectID, projectRoomID, clientRoomID, notes, type, status, share);

                if (document != null)
                    return Ok(document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
            return NotFound();
        }

        [HttpPost]
        [VersionedRoute("documents/newdocument/", 1)]
        public IHttpActionResult Post([FromBody]DTO.Shared.Document documentForCreation)
        {
            if (documentForCreation == null)
                return BadRequest();
            try
            {
                Guid? documentId = null;
                string name = documentForCreation.Name;
                Guid? organizationID = documentForCreation.OrganizationId;
                Guid? projectID = null;
                Guid? projectRoomID = null;
                Guid? clientRoomID = documentForCreation.RoomId;
                string notes = null;
                int? type = null;
                bool? share = null;
                int? status = null;

                var document = _crmRepository.Document_Write(documentId, name, organizationID, projectID, projectRoomID, clientRoomID, notes, type, status, share);

                if (document != null)
                    return Ok(document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
            return NotFound();
        }

    }
}
