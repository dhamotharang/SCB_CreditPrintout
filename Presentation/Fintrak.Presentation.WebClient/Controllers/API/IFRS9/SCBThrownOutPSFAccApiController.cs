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
using Fintrak.Presentation.WebClient.Models;

namespace Fintrak.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/scbthrownoutpsfacc")]
    [UsesDisposableService]
    public class SCBThrownOutPSFAccApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public SCBThrownOutPSFAccApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbthrownoutpsfacc")]
        public HttpResponseMessage UpdateSCBThrownOutPSFAcc(HttpRequestMessage request, [FromBody]SCBThrownOutPSFAcc scbthrownoutpsfaccModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbthrownoutpsfacc = _IFRS9Service.UpdateSCBThrownOutPSFAcc(scbthrownoutpsfaccModel);
                return request.CreateResponse<SCBThrownOutPSFAcc>(HttpStatusCode.OK, scbthrownoutpsfacc);
            });
        }

        [HttpPost]
        [Route("deletescbthrownoutpsfacc")]
        public HttpResponseMessage DeleteSCBThrownOutPSFAcc(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                SCBThrownOutPSFAcc scbthrownoutpsfacc = _IFRS9Service.GetSCBThrownOutPSFAcc(ID);
                if (scbthrownoutpsfacc != null)
                {
                    _IFRS9Service.DeleteSCBThrownOutPSFAcc(ID);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No SCBThrownOutPSFAcc found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbthrownoutpsfacc/{ID}")]
        public HttpResponseMessage GetSCBThrownOutPSFAcc(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>            {
                HttpResponseMessage response = null;
                SCBThrownOutPSFAcc scbthrownoutpsfacc = _IFRS9Service.GetSCBThrownOutPSFAcc(ID);
                // notice no need to create a seperate model object since SCBThrownOutPSFAcc entity will do just fine
                response = request.CreateResponse<SCBThrownOutPSFAcc>(HttpStatusCode.OK, scbthrownoutpsfacc);
                return response;
            });
        }

        [HttpGet]
        [Route("availablescbthrownoutpsfaccs/{defaultCount}")]
        public HttpResponseMessage GetAvailableSCBThrownOutPSFAccs(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                SCBThrownOutPSFAcc[] scbthrownoutpsfaccs = _IFRS9Service.GetSCBThrownOutPSFAccs(defaultCount);
                return request.CreateResponse<SCBThrownOutPSFAcc[]>(HttpStatusCode.OK, scbthrownoutpsfaccs);
            });
        }



        [HttpGet]
        [Route("getSCBThrownOutPSFAccbysearch/{searchParam}")]
        public HttpResponseMessage GetSCBThrownOutPSFAccBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                SCBThrownOutPSFAcc[] scbthrownoutpsfaccs = _IFRS9Service.GetSCBThrownOutPSFAccBySearch(searchParam);
                return request.CreateResponse<SCBThrownOutPSFAcc[]>(HttpStatusCode.OK, scbthrownoutpsfaccs.ToArray());
            });
        }



    }
}
