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
    [RoutePrefix("api/crlastcreditdate")]
    [UsesDisposableService]
    public class CRLastCreditDateApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public CRLastCreditDateApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatecrlastcreditdate")]
        public HttpResponseMessage UpdateCRLastCreditDate(HttpRequestMessage request, [FromBody]CRLastCreditDate crlastcreditdateModel)
        {
            return GetHttpResponse(request, () =>
            {
                var crlastcreditdate = _IFRS9Service.UpdateCRLastCreditDate(crlastcreditdateModel);

                return request.CreateResponse<CRLastCreditDate>(HttpStatusCode.OK, crlastcreditdate);
            });
        }

        [HttpPost]
        [Route("deletecrlastcreditdate")]
        public HttpResponseMessage DeleteCRLastCreditDate(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                CRLastCreditDate crlastcreditdate = _IFRS9Service.GetCRLastCreditDate(ID);

                if (crlastcreditdate != null)
                {
                    _IFRS9Service.DeleteCRLastCreditDate(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No CRLastCreditDate found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getcrlastcreditdate/{ID}")]
        public HttpResponseMessage GetCRLastCreditDate(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                CRLastCreditDate crlastcreditdate = _IFRS9Service.GetCRLastCreditDate(ID);

                // notice no need to create a seperate model object since CRLastCreditDate entity will do just fine
                response = request.CreateResponse<CRLastCreditDate>(HttpStatusCode.OK, crlastcreditdate);

                return response;
            });
        }

        [HttpGet]
        [Route("availablecrlastcreditdates/{defaultCount}")]
        public HttpResponseMessage GetAvailableCRLastCreditDates(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                CRLastCreditDate[] crlastcreditdates = _IFRS9Service.GetCRLastCreditDates(defaultCount);
                return request.CreateResponse<CRLastCreditDate[]>(HttpStatusCode.OK, crlastcreditdates);
            });
        }



        [HttpGet]
        [Route("getCRLastCreditDatebysearch/{searchParam}")]
        public HttpResponseMessage GetCRLastCreditDateBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                CRLastCreditDate[] crlastcreditdates = _IFRS9Service.GetCRLastCreditDateBySearch(searchParam);
                return request.CreateResponse<CRLastCreditDate[]>(HttpStatusCode.OK, crlastcreditdates.ToArray());
            });
        }





    }
}
