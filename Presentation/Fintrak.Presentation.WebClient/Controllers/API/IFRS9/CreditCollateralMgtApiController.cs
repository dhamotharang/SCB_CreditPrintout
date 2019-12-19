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
    [RoutePrefix("api/creditcollateralmgt")]
    [UsesDisposableService]
    public class CreditCollateralMgtApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public CreditCollateralMgtApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatecreditcollateralmgt")]
        public HttpResponseMessage UpdateCreditCollateralMgt(HttpRequestMessage request, [FromBody]CreditCollateralMgt creditcollateralmgtModel)
        {
            return GetHttpResponse(request, () =>
            {
                var creditcollateralmgt = _IFRS9Service.UpdateCreditCollateralMgt(creditcollateralmgtModel);

                return request.CreateResponse<CreditCollateralMgt>(HttpStatusCode.OK, creditcollateralmgt);
            });
        }

        [HttpPost]
        [Route("deletecreditcollateralmgt")]
        public HttpResponseMessage DeleteCreditCollateralMgt(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                CreditCollateralMgt creditcollateralmgt = _IFRS9Service.GetCreditCollateralMgt(ID);

                if (creditcollateralmgt != null)
                {
                    _IFRS9Service.DeleteCreditCollateralMgt(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No CreditCollateralMgt found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getcreditcollateralmgt/{ID}")]
        public HttpResponseMessage GetCreditCollateralMgt(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                CreditCollateralMgt creditcollateralmgt = _IFRS9Service.GetCreditCollateralMgt(ID);

                // notice no need to create a seperate model object since CreditCollateralMgt entity will do just fine
                response = request.CreateResponse<CreditCollateralMgt>(HttpStatusCode.OK, creditcollateralmgt);

                return response;
            });
        }

        [HttpGet]
        [Route("availablecreditcollateralmgts/{defaultCount}")]
        public HttpResponseMessage GetAvailableCreditCollateralMgts(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                CreditCollateralMgt[] creditcollateralmgts = _IFRS9Service.GetCreditCollateralMgts(defaultCount);
                return request.CreateResponse<CreditCollateralMgt[]>(HttpStatusCode.OK, creditcollateralmgts);
            });
        }



        [HttpGet]
        [Route("getCreditCollateralMgtbysearch/{searchParam}")]
        public HttpResponseMessage GetCreditCollateralMgtBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                CreditCollateralMgt[] creditcollateralmgts = _IFRS9Service.GetCreditCollateralMgtBySearch(searchParam);
                return request.CreateResponse<CreditCollateralMgt[]>(HttpStatusCode.OK, creditcollateralmgts.ToArray());
            });
        }





    }
}
