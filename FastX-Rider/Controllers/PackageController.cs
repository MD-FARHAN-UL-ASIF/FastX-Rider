using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FastX_Rider.Controllers
{
    [EnableCors("*", "*", "*")]

    public class PackageController : ApiController
    {
        [HttpPost]
        [Route("api/package")]
        public HttpResponseMessage Create(PackageDTO package)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = PackageServices.Create(package);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/package")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PackageServices.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/package/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PackageServices.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        [Route("api/package/{id}")]
        public HttpResponseMessage Update(int id, PackageDTO package)
        {
            if (package is null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    package.Id = id;
                    var data = PackageServices.Update(package);

                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/package/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = PackageServices.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Package terminated successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
