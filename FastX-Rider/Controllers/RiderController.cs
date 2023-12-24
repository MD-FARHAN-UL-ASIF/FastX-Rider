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

    public class RiderController : ApiController
    {
        [HttpPost]
        [Route("api/rider/create")]
        public HttpResponseMessage Create(RiderDTO rider)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = RiderServices.Create(rider);
                    if(data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Riders Added Successfully");
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
        [Route("api/rider/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RiderServices.Get();
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
        [Route("api/rider/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = RiderServices.Get(id);
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
        [Route("api/rider/update/{id}")]
        public HttpResponseMessage Update(int id, RiderDTO rider)
        {
            if (rider is null)
            {
                throw new ArgumentNullException(nameof(rider));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    rider.Id = id;
                    var isSuccess = RiderServices.Update(rider);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Rider Details updated successfully");
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
        [Route("api/rider/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = RiderServices.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Rider terminated successfully.");
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