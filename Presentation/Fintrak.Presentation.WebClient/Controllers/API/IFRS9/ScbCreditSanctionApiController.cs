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
    [RoutePrefix("api/scbcreditsanction")]
    [UsesDisposableService]
    public class ScbCreditSanctionApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbCreditSanctionApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbcreditsanction")]
        public HttpResponseMessage UpdateScbCreditSanction(HttpRequestMessage request, [FromBody]ScbCreditSanction scbcreditsanctionModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbcreditsanction = _IFRS9Service.UpdateScbCreditSanction(scbcreditsanctionModel);

                return request.CreateResponse<ScbCreditSanction>(HttpStatusCode.OK, scbcreditsanction);
            });
        }

        [HttpPost]
        [Route("deletescbcreditsanction")]
        public HttpResponseMessage DeleteScbCreditSanction(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbCreditSanction scbcreditsanction = _IFRS9Service.GetScbCreditSanction(ID);

                if (scbcreditsanction != null)
                {
                    _IFRS9Service.DeleteScbCreditSanction(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbCreditSanction found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbcreditsanction/{ID}")]
        public HttpResponseMessage GetScbCreditSanction(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbCreditSanction scbcreditsanction = _IFRS9Service.GetScbCreditSanction(ID);

                // notice no need to create a seperate model object since ScbCreditSanction entity will do just fine
                response = request.CreateResponse<ScbCreditSanction>(HttpStatusCode.OK, scbcreditsanction);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbcreditsanctions/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbCreditSanctions(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbCreditSanction[] scbcreditsanctions = _IFRS9Service.GetScbCreditSanctions(defaultCount);
                return request.CreateResponse<ScbCreditSanction[]>(HttpStatusCode.OK, scbcreditsanctions);
            });
        }



        [HttpGet]
        [Route("getScbCreditSanctionbysearch/{searchParam}")]
        public HttpResponseMessage GetScbCreditSanctionBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbCreditSanction[] scbcreditsanctions = _IFRS9Service.GetScbCreditSanctionBySearch(searchParam);
                return request.CreateResponse<ScbCreditSanction[]>(HttpStatusCode.OK, scbcreditsanctions.ToArray());
            });
        }





    }
}
