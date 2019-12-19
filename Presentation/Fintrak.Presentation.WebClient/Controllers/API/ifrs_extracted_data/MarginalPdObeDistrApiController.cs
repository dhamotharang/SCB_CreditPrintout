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
    [RoutePrefix("api/MarginalPdObeDistr")]
    [UsesDisposableService]

    public class MarginalPdObeDistrApiController : ApiControllerBase {

        [ImportingConstructor]
        public MarginalPdObeDistrApiController(IExtractedDataService ifrsDataService) {
            _IFRSDataService = ifrsDataService;
        }
        IExtractedDataService _IFRSDataService;
        protected override void RegisterServices(List<IServiceContract> disposableServices) {
            disposableServices.Add(_IFRSDataService);
        }

        [HttpPost]
        [Route("updateMarginalPdObeDistr")]
        public HttpResponseMessage Updatemarginalpdobedistr(HttpRequestMessage request, [FromBody]MarginalPdObeDistr marginalpdobedistrModel) {
            return GetHttpResponse(request, () => {
                var marginalpdobedistr = _IFRSDataService.UpdateMarginalPdObeDistr(marginalpdobedistrModel);
                return request.CreateResponse<MarginalPdObeDistr>(HttpStatusCode.OK, marginalpdobedistr);
            });
        }


        [HttpPost]
        [Route("deleteMarginalPdObeDistr")]
        public HttpResponseMessage DeleteMarginalPdObeDistr(HttpRequestMessage request, [FromBody]int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                MarginalPdObeDistr marginalpdobedistr = _IFRSDataService.GetMarginalPdObeDistr(Id);
                if (marginalpdobedistr != null) {
                    _IFRSDataService.DeleteMarginalPdObeDistr(Id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                } else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No MarginalPdObeDistr data found under that ID.");
                return response;
            });
        }


        [HttpGet]
        [Route("availableMarginalPdObeDistr")]
        public HttpResponseMessage GetAvailableMarginalPdObeDistrs(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                MarginalPdObeDistr[] marginalpdobedistr = _IFRSDataService.GetAllMarginalPdObeDistr().ToArray();
                return request.CreateResponse<MarginalPdObeDistr[]>(HttpStatusCode.OK, marginalpdobedistr.ToArray());
            });
        }

        [HttpGet]
        [Route("getMarginalPdObeDistr/{Id}")]
        public HttpResponseMessage GetMarginalPdObeDistr(HttpRequestMessage request, int Id) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                MarginalPdObeDistr marginalpdobedistr = _IFRSDataService.GetMarginalPdObeDistr(Id);
                // notice no need to create a seperate model object since Setup entity will do just fine
                response = request.CreateResponse<MarginalPdObeDistr>(HttpStatusCode.OK, marginalpdobedistr);
                return response;
            });
        }


        [HttpGet]
        [Route("getMarginalPdObeDistrbysearch/{searchParam}")]
        public HttpResponseMessage GetMarginalPdObeDistrBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                MarginalPdObeDistr[] marginalpdobedistr = _IFRSDataService.GetMarginalPdObeDistrBySearch(searchParam);
                return request.CreateResponse<MarginalPdObeDistr[]>(HttpStatusCode.OK, marginalpdobedistr.ToArray());
            });
        }


        [HttpGet]
        [Route("availableMarginalPdObeDistr/{defaultCount}")]
        public HttpResponseMessage GetAvailableMarginalPdObeDistr(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                MarginalPdObeDistr[] marginalpdobedistr = _IFRSDataService.GetMarginalPdObeDistrs(defaultCount).ToArray();
                return request.CreateResponse<MarginalPdObeDistr[]>(HttpStatusCode.OK, marginalpdobedistr.ToArray());
            });
        }

    }
}
