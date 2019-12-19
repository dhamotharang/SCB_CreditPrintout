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
    [RoutePrefix("api/scbcustomerinfo")]
    [UsesDisposableService]
    public class ScbCustomerInfoApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbCustomerInfoApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbcustomerinfo")]
        public HttpResponseMessage UpdateScbCustomerInfo(HttpRequestMessage request, [FromBody]ScbCustomerInfo scbcustomerinfoModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbcustomerinfo = _IFRS9Service.UpdateScbCustomerInfo(scbcustomerinfoModel);

                return request.CreateResponse<ScbCustomerInfo>(HttpStatusCode.OK, scbcustomerinfo);
            });
        }

        [HttpPost]
        [Route("deletescbcustomerinfo")]
        public HttpResponseMessage DeleteScbCustomerInfo(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbCustomerInfo scbcustomerinfo = _IFRS9Service.GetScbCustomerInfo(ID);

                if (scbcustomerinfo != null)
                {
                    _IFRS9Service.DeleteScbCustomerInfo(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbCustomerInfo found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbcustomerinfo/{ID}")]
        public HttpResponseMessage GetScbCustomerInfo(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbCustomerInfo scbcustomerinfo = _IFRS9Service.GetScbCustomerInfo(ID);

                // notice no need to create a seperate model object since ScbCustomerInfo entity will do just fine
                response = request.CreateResponse<ScbCustomerInfo>(HttpStatusCode.OK, scbcustomerinfo);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbcustomerinfos/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbCustomerInfos(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbCustomerInfo[] scbcustomerinfos = _IFRS9Service.GetScbCustomerInfos(defaultCount);
                return request.CreateResponse<ScbCustomerInfo[]>(HttpStatusCode.OK, scbcustomerinfos);
            });
        }



        [HttpGet]
        [Route("getScbCustomerInfobysearch/{searchParam}")]
        public HttpResponseMessage GetScbCustomerInfoBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbCustomerInfo[] scbcustomerinfos = _IFRS9Service.GetScbCustomerInfoBySearch(searchParam);
                return request.CreateResponse<ScbCustomerInfo[]>(HttpStatusCode.OK, scbcustomerinfos.ToArray());
            });
        }





    }
}
