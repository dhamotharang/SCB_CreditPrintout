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
    [RoutePrefix("api/scbbankclassification")]
    [UsesDisposableService]
    public class ScbBankClassificationApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbBankClassificationApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbbankclassification")]
        public HttpResponseMessage UpdateScbBankClassification(HttpRequestMessage request, [FromBody]ScbBankClassification scbbankclassificationModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbbankclassification = _IFRS9Service.UpdateScbBankClassification(scbbankclassificationModel);

                return request.CreateResponse<ScbBankClassification>(HttpStatusCode.OK, scbbankclassification);
            });
        }

        [HttpPost]
        [Route("deletescbbankclassification")]
        public HttpResponseMessage DeleteScbBankClassification(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbBankClassification scbbankclassification = _IFRS9Service.GetScbBankClassification(ID);

                if (scbbankclassification != null)
                {
                    _IFRS9Service.DeleteScbBankClassification(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbBankClassification found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbbankclassification/{ID}")]
        public HttpResponseMessage GetScbBankClassification(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbBankClassification scbbankclassification = _IFRS9Service.GetScbBankClassification(ID);

                // notice no need to create a seperate model object since ScbBankClassification entity will do just fine
                response = request.CreateResponse<ScbBankClassification>(HttpStatusCode.OK, scbbankclassification);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbbankclassifications/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbBankClassifications(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbBankClassification[] scbbankclassifications = _IFRS9Service.GetScbBankClassifications(defaultCount);
                return request.CreateResponse<ScbBankClassification[]>(HttpStatusCode.OK, scbbankclassifications);
            });
        }



        [HttpGet]
        [Route("getScbBankClassificationbysearch/{searchParam}")]
        public HttpResponseMessage GetScbBankClassificationBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbBankClassification[] scbbankclassifications = _IFRS9Service.GetScbBankClassificationBySearch(searchParam);
                return request.CreateResponse<ScbBankClassification[]>(HttpStatusCode.OK, scbbankclassifications.ToArray());
            });
        }





    }
}
