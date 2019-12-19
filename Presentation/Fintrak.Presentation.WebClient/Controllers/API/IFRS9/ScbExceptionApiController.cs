using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fintrak.Presentation.WebClient.Core;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Client.IFRS.Entities;
using Fintrak.Client.IFRS.Contracts;

namespace Fintrak.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/scbexception")]
    [UsesDisposableService]
    public class ScbExceptionApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbExceptionApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbexception")]
        public HttpResponseMessage UpdateScbException(HttpRequestMessage request, [FromBody]ScbException scbexceptionModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbexception = _IFRS9Service.UpdateScbException(scbexceptionModel);

                return request.CreateResponse<ScbException>(HttpStatusCode.OK, scbexception);
            });
        }

        [HttpPost]
        [Route("deletescbexception")]
        public HttpResponseMessage DeleteScbException(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbException scbexception = _IFRS9Service.GetScbException(ID);

                if (scbexception != null)
                {
                    _IFRS9Service.DeleteScbException(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbException found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbexception/{ID}")]
        public HttpResponseMessage GetScbException(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbException scbexception = _IFRS9Service.GetScbException(ID);

                // notice no need to create a seperate model object since ScbException entity will do just fine
                response = request.CreateResponse<ScbException>(HttpStatusCode.OK, scbexception);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbexceptions/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbExceptions(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbException[] scbexceptions = _IFRS9Service.GetScbExceptions(defaultCount);
                return request.CreateResponse<ScbException[]>(HttpStatusCode.OK, scbexceptions);
            });
        }



        [HttpGet]
        [Route("getScbExceptionbysearch/{searchParam}")]
        public HttpResponseMessage GetScbExceptionBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbException[] scbexceptions = _IFRS9Service.GetScbExceptionBySearch(searchParam);
                return request.CreateResponse<ScbException[]>(HttpStatusCode.OK, scbexceptions.ToArray());
            });
        }


        [HttpGet]
        [Route("getDistinctExpMessages")]
        public HttpResponseMessage GetDistinctScbExpMessages(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                string[] scbexceptions = _IFRS9Service.GetDistinctScbExpMessages();
                return request.CreateResponse<string[]>(HttpStatusCode.OK, scbexceptions.ToArray());
            });
        }


        [HttpGet]
        [Route("getExceptionMessageByFilter/{searchParam}")]
        public HttpResponseMessage getExceptionMessageByFilter(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbException[] scbexceptions = _IFRS9Service.getExceptionMessageByFilter(searchParam);
                return request.CreateResponse<ScbException[]>(HttpStatusCode.OK, scbexceptions.ToArray());
            });
        }

        [HttpGet]
        [Route("RevertExceptionById/{ID}")]
        public HttpResponseMessage RevertExceptionById(HttpRequestMessage request, string ID){
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                ScbException[] scbexception = _IFRS9Service.RevertExceptionById(ID);
                response = request.CreateResponse<ScbException[]>(HttpStatusCode.OK, scbexception);
                return response;
            });
        }

        [HttpGet]
        [Route("DelAllExceptionsObj")]
        public HttpResponseMessage DelAllExceptionsObj(HttpRequestMessage request){
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                ScbException[] scbexception = _IFRS9Service.RevertAllExceptionObjs();
                response = request.CreateResponse<ScbException[]>(HttpStatusCode.OK, scbexception);
                return response;
            });
        }




    }
}                                                                                                                                                                                                                                                       
