using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fintrak.Presentation.WebClient.Core;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Client.IFRS.Contracts;
using Fintrak.Client.IFRS.Entities;

namespace Fintrak.Presentation.WebClient.API {

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/OdLgdComputationResult")]
    [UsesDisposableService]
    public class OdLgdComputationResultApiController : ApiControllerBase {

        [ImportingConstructor]
        public OdLgdComputationResultApiController(IExtractedDataService ifrsDataService) {
            _IFRSDataService = ifrsDataService;
        }

        IExtractedDataService _IFRSDataService;
        protected override void RegisterServices(List<IServiceContract> disposableServices) {
            disposableServices.Add(_IFRSDataService);
        }

        [HttpPost]
        [Route("updateOdLgdComputationResult")]
        public HttpResponseMessage Updateodlgdcomputationresult(HttpRequestMessage request, [FromBody]OdLgdComputationResult odlgdcomputationresultModel) {
            return GetHttpResponse(request, () => {
                var odlgdcomputationresult = _IFRSDataService.UpdateOdLgdComputationResult(odlgdcomputationresultModel);
                return request.CreateResponse<OdLgdComputationResult>(HttpStatusCode.OK, odlgdcomputationresult);
            });
        }


        [HttpPost]
        [Route("deleteOdLgdComputationResult")]
        public HttpResponseMessage DeleteOdLgdComputationResult(HttpRequestMessage request, [FromBody]int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                OdLgdComputationResult odlgdcomputationresult = _IFRSDataService.GetOdLgdComputationResult(Id);
                if (odlgdcomputationresult != null) {
                    _IFRSDataService.DeleteOdLgdComputationResult(Id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                } else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No OdLgdComputationResult data found under that ID.");
                return response;
            });
        }


        [HttpGet]
        [Route("availableOdLgdComputationResult")]
        public HttpResponseMessage GetAvailableOdLgdComputationResults(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                OdLgdComputationResult[] odlgdcomputationresult = _IFRSDataService.GetAllOdLgdComputationResult().ToArray();
                return request.CreateResponse<OdLgdComputationResult[]>(HttpStatusCode.OK, odlgdcomputationresult.ToArray());
            });
        }


        [HttpGet]
        [Route("getOdLgdComputationResult/{Id}")]
        public HttpResponseMessage GetOdLgdComputationResult(HttpRequestMessage request, int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                OdLgdComputationResult odlgdcomputationresult = _IFRSDataService.GetOdLgdComputationResult(Id);
                // notice no need to create a seperate model object since Setup entity will do just fine
                response = request.CreateResponse<OdLgdComputationResult>(HttpStatusCode.OK, odlgdcomputationresult);
                return response;
            });
        }


        [HttpGet]
        [Route("getOdLgdComputationResultbysearch/{searchParam}")]
        public HttpResponseMessage GetOdLgdComputationResultBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                OdLgdComputationResult[] odlgdcomputationresult = _IFRSDataService.GetOdLgdComputationResultBySearch(searchParam);
                return request.CreateResponse<OdLgdComputationResult[]>(HttpStatusCode.OK, odlgdcomputationresult.ToArray());
            });
        }


        [HttpGet]
        [Route("availableOdLgdComputationResult/{defaultCount}")]
        public HttpResponseMessage GetAvailableOdLgdComputationResult(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                OdLgdComputationResult[] odlgdcomputationresult = _IFRSDataService.GetOdLgdComputationResults(defaultCount).ToArray();
                return request.CreateResponse<OdLgdComputationResult[]>(HttpStatusCode.OK, odlgdcomputationresult.ToArray());
            });
        }

    }
}
