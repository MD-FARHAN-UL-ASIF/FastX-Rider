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

    public class DeliveryStatusController : ApiController
    {
        [HttpPost]
        [Route("api/delivery-status")]
        public HttpResponseMessage Create(DeliveryStatusDTO deliveryStatusDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = DeliveryStatusServices.Create(deliveryStatusDTO);
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
        [Route("api/delivery-status")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DeliveryStatusServices.Get();
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
        [Route("api/delivery-status/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = DeliveryStatusServices.Get(id);
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
        [Route("api/delivery-status/{id}")]
        public HttpResponseMessage Update(int id, DeliveryStatusDTO deliveryStatusDTO)
        {
            if (deliveryStatusDTO is null)
            {
                throw new ArgumentNullException(nameof(deliveryStatusDTO));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    deliveryStatusDTO.Id = id;
                    var data = DeliveryStatusServices.Update(deliveryStatusDTO);

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
        [Route("api/delivery-status/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = DeliveryStatusServices.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Delivery Status deleted successfully.");
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
