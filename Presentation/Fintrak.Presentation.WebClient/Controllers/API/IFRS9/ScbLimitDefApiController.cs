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
    [RoutePrefix("api/scblimitdef")]
    [UsesDisposableService]
    public class ScbLimitDefApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbLimitDefApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescblimitdef")]
        public HttpResponseMessage UpdateScbLimitDef(HttpRequestMessage request, [FromBody]ScbLimitDef scblimitdefModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scblimitdef = _IFRS9Service.UpdateScbLimitDef(scblimitdefModel);

                return request.CreateResponse<ScbLimitDef>(HttpStatusCode.OK, scblimitdef);
            });
        }

        [HttpPost]
        [Route("deletescblimitdef")]
        public HttpResponseMessage DeleteScbLimitDef(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbLimitDef scblimitdef = _IFRS9Service.GetScbLimitDef(ID);

                if (scblimitdef != null)
                {
                    _IFRS9Service.DeleteScbLimitDef(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbLimitDef found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscblimitdef/{ID}")]
        public HttpResponseMessage GetScbLimitDef(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbLimitDef scblimitdef = _IFRS9Service.GetScbLimitDef(ID);

                // notice no need to create a seperate model object since ScbLimitDef entity will do just fine
                response = request.CreateResponse<ScbLimitDef>(HttpStatusCode.OK, scblimitdef);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescblimitdefs/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbLimitDefs(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbLimitDef[] scblimitdefs = _IFRS9Service.GetScbLimitDefs(defaultCount);
                return request.CreateResponse<ScbLimitDef[]>(HttpStatusCode.OK, scblimitdefs);
            });
        }



        [HttpGet]
        [Route("getScbLimitDefbysearch/{searchParam}")]
        public HttpResponseMessage GetScbLimitDefBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbLimitDef[] scblimitdefs = _IFRS9Service.GetScbLimitDefBySearch(searchParam);
                return request.CreateResponse<ScbLimitDef[]>(HttpStatusCode.OK, scblimitdefs.ToArray());
            });
        }





    }
}
