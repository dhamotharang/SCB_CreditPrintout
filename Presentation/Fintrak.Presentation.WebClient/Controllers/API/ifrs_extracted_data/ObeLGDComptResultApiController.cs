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
    [RoutePrefix("api/ObeLGDComptResult")]
    [UsesDisposableService]
    public class ObeLGDComptResultApiController : ApiControllerBase {
        [ImportingConstructor]
        public ObeLGDComptResultApiController(IExtractedDataService ifrsDataService) {
            _IFRSDataService = ifrsDataService;
        }
        IExtractedDataService _IFRSDataService;
        protected override void RegisterServices(List<IServiceContract> disposableServices) {
            disposableServices.Add(_IFRSDataService);
        }

        [HttpPost]
        [Route("updateObeLGDComptResult")]
        public HttpResponseMessage Updateobelgdcomptresult(HttpRequestMessage request, [FromBody]ObeLGDComptResult obelgdcomptresultModel) {
            return GetHttpResponse(request, () => {
                var obelgdcomptresult = _IFRSDataService.UpdateObeLGDComptResult(obelgdcomptresultModel);
                return request.CreateResponse<ObeLGDComptResult>(HttpStatusCode.OK, obelgdcomptresult);
            });
        }


        [HttpPost]
        [Route("deleteObeLGDComptResult")]
        public HttpResponseMessage DeleteObeLGDComptResult(HttpRequestMessage request, [FromBody]int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                ObeLGDComptResult obelgdcomptresult = _IFRSDataService.GetObeLGDComptResult(Id);
                if (obelgdcomptresult != null) {
                    _IFRSDataService.DeleteObeLGDComptResult(Id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                } else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ObeLGDComptResult data found under that ID.");
                return response;
            });
        }


        [HttpGet]
        [Route("availableObeLGDComptResult")]
        public HttpResponseMessage GetAvailableObeLGDComptResults(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                ObeLGDComptResult[] obelgdcomptresult = _IFRSDataService.GetAllObeLGDComptResult().ToArray();
                return request.CreateResponse<ObeLGDComptResult[]>(HttpStatusCode.OK, obelgdcomptresult.ToArray());
            });
        }

        [HttpGet]
        [Route("getObeLGDComptResult/{Id}")]
        public HttpResponseMessage GetObeLGDComptResult(HttpRequestMessage request, int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                ObeLGDComptResult obelgdcomptresult = _IFRSDataService.GetObeLGDComptResult(Id);
                // notice no need to create a seperate model object since Setup entity will do just fine
                response = request.CreateResponse<ObeLGDComptResult>(HttpStatusCode.OK, obelgdcomptresult);
                return response;
            });
        }


        [HttpGet]
        [Route("getObeLGDComptResultbysearch/{searchParam}")]
        public HttpResponseMessage GetObeLGDComptResultBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ObeLGDComptResult[] obelgdcomptresult = _IFRSDataService.GetObeLGDComptResultBySearch(searchParam);
                return request.CreateResponse<ObeLGDComptResult[]>(HttpStatusCode.OK, obelgdcomptresult.ToArray());
            });
        }


        [HttpGet]
        [Route("availableObeLGDComptResult/{defaultCount}")]
        public HttpResponseMessage GetAvailableObeLGDComptResult(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                ObeLGDComptResult[] obelgdcomptresult = _IFRSDataService.GetObeLGDComptResults(defaultCount).ToArray();
                return request.CreateResponse<ObeLGDComptResult[]>(HttpStatusCode.OK, obelgdcomptresult.ToArray());
            });
        }

    }
}
