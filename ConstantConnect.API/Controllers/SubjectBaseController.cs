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
    public class SubjectBaseController : ApiController
    {
        ICRMRepository _crmRepository;

        #region Controllers
        public SubjectBaseController()
        {
            _crmRepository = new CRMRepository(new Repository.Entities.Contexts.CRMContext());
        }

        public SubjectBaseController(ICRMRepository repo)
        {
            _crmRepository = repo;
        }

        #endregion


        [VersionedRoute("subjectbase/{Id}", 1)]
        public IHttpActionResult Get(Guid Id)
        {
            try
            {
                var entity = _crmRepository.GetSubjectBase(Id);

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

        [VersionedRoute("subjectbase", 1)]
        public IHttpActionResult Get()
        {
            try
            {
                var entity = _crmRepository.GetSubjectBase();

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
