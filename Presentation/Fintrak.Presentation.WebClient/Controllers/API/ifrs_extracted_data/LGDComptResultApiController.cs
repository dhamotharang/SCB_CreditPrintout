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
    [RoutePrefix("api/LGDComptResult")]
    [UsesDisposableService]
    public class LGDComptResultApiController : ApiControllerBase {
        [ImportingConstructor]
        public LGDComptResultApiController(IExtractedDataService ifrsDataService) {
            _IFRSDataService = ifrsDataService;
        }
        IExtractedDataService _IFRSDataService;
        protected override void RegisterServices(List<IServiceContract> disposableServices) {
            disposableServices.Add(_IFRSDataService);
        }

        [HttpPost]
        [Route("updateLGDComptResult")]
        public HttpResponseMessage Updatelgdcomptresult(HttpRequestMessage request, [FromBody]LGDComptResult lgdcomptresultModel) {
            return GetHttpResponse(request, () => {
                var lgdcomptresult = _IFRSDataService.UpdateLGDComptResult(lgdcomptresultModel);
                return request.CreateResponse<LGDComptResult>(HttpStatusCode.OK, lgdcomptresult);
            });
        }


        [HttpPost]
        [Route("deleteLGDComptResult")]
        public HttpResponseMessage DeleteLGDComptResult(HttpRequestMessage request, [FromBody]int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                LGDComptResult lgdcomptresult = _IFRSDataService.GetLGDComptResult(Id);
                if (lgdcomptresult != null) {
                    _IFRSDataService.DeleteLGDComptResult(Id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                } else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No LGDComptResult data found under that ID.");
                return response;
            });
        }


        [HttpGet]
        [Route("availableLGDComptResult")]
        public HttpResponseMessage GetAvailableLGDComptResults(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                LGDComptResult[] lgdcomptresult = _IFRSDataService.GetAllLGDComptResult().ToArray();
                return request.CreateResponse<LGDComptResult[]>(HttpStatusCode.OK, lgdcomptresult.ToArray());
            });
        }

        [HttpGet]
        [Route("getLGDComptResult/{Id}")]
        public HttpResponseMessage GetLGDComptResult(HttpRequestMessage request, int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                LGDComptResult lgdcomptresult = _IFRSDataService.GetLGDComptResult(Id);
                // notice no need to create a seperate model object since Setup entity will do just fine
                response = request.CreateResponse<LGDComptResult>(HttpStatusCode.OK, lgdcomptresult);
                return response;
            });
        }


        [HttpGet]
        [Route("getLGDComptResultbysearch/{searchParam}")]
        public HttpResponseMessage GetLGDComptResultBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                LGDComptResult[] lgdcomptresult = _IFRSDataService.GetLGDComptResultBySearch(searchParam);
                return request.CreateResponse<LGDComptResult[]>(HttpStatusCode.OK, lgdcomptresult.ToArray());
            });
        }


        [HttpGet]
        [Route("availableLGDComptResult/{defaultCount}")]
        public HttpResponseMessage GetAvailableLGDComptResult(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                LGDComptResult[] lgdcomptresult = _IFRSDataService.GetLGDComptResults(defaultCount).ToArray();
                return request.CreateResponse<LGDComptResult[]>(HttpStatusCode.OK, lgdcomptresult.ToArray());
            });
        }

    }
}
