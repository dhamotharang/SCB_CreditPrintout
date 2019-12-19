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
    [RoutePrefix("api/scbglbalance")]
    [UsesDisposableService]
    public class ScbGLBalanceApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbGLBalanceApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbglbalance")]
        public HttpResponseMessage UpdateScbGLBalance(HttpRequestMessage request, [FromBody]ScbGLBalance scbglbalanceModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbglbalance = _IFRS9Service.UpdateScbGLBalance(scbglbalanceModel);

                return request.CreateResponse<ScbGLBalance>(HttpStatusCode.OK, scbglbalance);
            });
        }

        [HttpPost]
        [Route("deletescbglbalance")]
        public HttpResponseMessage DeleteScbGLBalance(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbGLBalance scbglbalance = _IFRS9Service.GetScbGLBalance(ID);

                if (scbglbalance != null)
                {
                    _IFRS9Service.DeleteScbGLBalance(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbGLBalance found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbglbalance/{ID}")]
        public HttpResponseMessage GetScbGLBalance(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbGLBalance scbglbalance = _IFRS9Service.GetScbGLBalance(ID);

                // notice no need to create a seperate model object since ScbGLBalance entity will do just fine
                response = request.CreateResponse<ScbGLBalance>(HttpStatusCode.OK, scbglbalance);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbglbalances/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbGLBalances(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbGLBalance[] scbglbalances = _IFRS9Service.GetScbGLBalances(defaultCount);
                return request.CreateResponse<ScbGLBalance[]>(HttpStatusCode.OK, scbglbalances);
            });
        }



        [HttpGet]
        [Route("getScbGLBalancebysearch/{searchParam}")]
        public HttpResponseMessage GetScbGLBalanceBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbGLBalance[] scbglbalances = _IFRS9Service.GetScbGLBalanceBySearch(searchParam);
                return request.CreateResponse<ScbGLBalance[]>(HttpStatusCode.OK, scbglbalances.ToArray());
            });
        }





    }
}
