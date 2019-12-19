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
    [RoutePrefix("api/scbcollateralmgt")]
    [UsesDisposableService]
    public class ScbCollateralMgtApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbCollateralMgtApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbcollateralmgt")]
        public HttpResponseMessage UpdateScbCollateralMgt(HttpRequestMessage request, [FromBody]ScbCollateralMgt scbcollateralmgtModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbcollateralmgt = _IFRS9Service.UpdateScbCollateralMgt(scbcollateralmgtModel);

                return request.CreateResponse<ScbCollateralMgt>(HttpStatusCode.OK, scbcollateralmgt);
            });
        }

        [HttpPost]
        [Route("deletescbcollateralmgt")]
        public HttpResponseMessage DeleteScbCollateralMgt(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbCollateralMgt scbcollateralmgt = _IFRS9Service.GetScbCollateralMgt(ID);

                if (scbcollateralmgt != null)
                {
                    _IFRS9Service.DeleteScbCollateralMgt(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbCollateralMgt found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbcollateralmgt/{ID}")]
        public HttpResponseMessage GetScbCollateralMgt(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbCollateralMgt scbcollateralmgt = _IFRS9Service.GetScbCollateralMgt(ID);

                // notice no need to create a seperate model object since ScbCollateralMgt entity will do just fine
                response = request.CreateResponse<ScbCollateralMgt>(HttpStatusCode.OK, scbcollateralmgt);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbcollateralmgts/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbCollateralMgts(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbCollateralMgt[] scbcollateralmgts = _IFRS9Service.GetScbCollateralMgts(defaultCount);
                return request.CreateResponse<ScbCollateralMgt[]>(HttpStatusCode.OK, scbcollateralmgts);
            });
        }



        [HttpGet]
        [Route("getScbCollateralMgtbysearch/{searchParam}")]
        public HttpResponseMessage GetScbCollateralMgtBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbCollateralMgt[] scbcollateralmgts = _IFRS9Service.GetScbCollateralMgtBySearch(searchParam);
                return request.CreateResponse<ScbCollateralMgt[]>(HttpStatusCode.OK, scbcollateralmgts.ToArray());
            });
        }





    }
}
