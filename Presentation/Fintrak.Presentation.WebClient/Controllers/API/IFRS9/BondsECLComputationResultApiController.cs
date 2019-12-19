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
    [RoutePrefix("api/bondseclcomputationresult")]
    [UsesDisposableService]
    public class BondsECLComputationResultApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public BondsECLComputationResultApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatebondseclcomputationresult")]
        public HttpResponseMessage UpdateBondsECLComputationResult(HttpRequestMessage request, [FromBody]BondsECLComputationResult bondseclcomputationresultModel)
        {
            return GetHttpResponse(request, () =>
            {
                var bondseclcomputationresult = _IFRS9Service.UpdateBondsECLComputationResult(bondseclcomputationresultModel);

                return request.CreateResponse<BondsECLComputationResult>(HttpStatusCode.OK, bondseclcomputationresult);
            });
        }

        [HttpPost]
        [Route("deletebondseclcomputationresult")]
        public HttpResponseMessage DeleteBondsECLComputationResult(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                BondsECLComputationResult bondseclcomputationresult = _IFRS9Service.GetBondsECLComputationResult(ID);

                if (bondseclcomputationresult != null)
                {
                    _IFRS9Service.DeleteBondsECLComputationResult(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No BondsECLComputationResult found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getbondseclcomputationresult/{ID}")]
        public HttpResponseMessage GetBondsECLComputationResult(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                BondsECLComputationResult bondseclcomputationresult = _IFRS9Service.GetBondsECLComputationResult(ID);

                // notice no need to create a seperate model object since BondsECLComputationResult entity will do just fine
                response = request.CreateResponse<BondsECLComputationResult>(HttpStatusCode.OK, bondseclcomputationresult);

                return response;
            });
        }

        [HttpGet]
        [Route("availablebondseclcomputationresults/{defaultCount}")]
        public HttpResponseMessage GetAvailableBondsECLComputationResults(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                BondsECLComputationResult[] bondseclcomputationresults = _IFRS9Service.GetBondsECLComputationResults(defaultCount);
                return request.CreateResponse<BondsECLComputationResult[]>(HttpStatusCode.OK, bondseclcomputationresults);
            });
        }



        [HttpGet]
        [Route("getBondsECLComputationResultbysearch/{searchParam}")]
        public HttpResponseMessage GetBondsECLComputationResultBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                BondsECLComputationResult[] bondseclcomputationresults = _IFRS9Service.GetBondsECLComputationResultBySearch(searchParam);
                return request.CreateResponse<BondsECLComputationResult[]>(HttpStatusCode.OK, bondseclcomputationresults.ToArray());
            });
        }





    }
}
