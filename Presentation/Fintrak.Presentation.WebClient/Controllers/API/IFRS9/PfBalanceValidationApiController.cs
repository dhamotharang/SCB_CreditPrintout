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
    [RoutePrefix("api/pfbalancevalidation")]
    [UsesDisposableService]
    public class PfBalanceValidationApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public PfBalanceValidationApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatepfbalancevalidation")]
        public HttpResponseMessage UpdatePfBalanceValidation(HttpRequestMessage request, [FromBody]PfBalanceValidation pfbalancevalidationModel)
        {
            return GetHttpResponse(request, () =>
            {
                var pfbalancevalidation = _IFRS9Service.UpdatePfBalanceValidation(pfbalancevalidationModel);
                return request.CreateResponse<PfBalanceValidation>(HttpStatusCode.OK, pfbalancevalidation);
            });
        }

        [HttpPost]
        [Route("deletepfbalancevalidation")]
        public HttpResponseMessage DeletePfBalanceValidation(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                PfBalanceValidation pfbalancevalidation = _IFRS9Service.GetPfBalanceValidation(ID);
                if (pfbalancevalidation != null)
                {
                    _IFRS9Service.DeletePfBalanceValidation(ID);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No PfBalanceValidation found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getpfbalancevalidation/{ID}")]
        public HttpResponseMessage GetPfBalanceValidation(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>            {
                HttpResponseMessage response = null;
                PfBalanceValidation pfbalancevalidation = _IFRS9Service.GetPfBalanceValidation(ID);
                // notice no need to create a seperate model object since PfBalanceValidation entity will do just fine
                response = request.CreateResponse<PfBalanceValidation>(HttpStatusCode.OK, pfbalancevalidation);
                return response;
            });
        }

        [HttpGet]
        [Route("availablepfbalancevalidations/{defaultCount}")]
        public HttpResponseMessage GetAvailablePfBalanceValidations(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                PfBalanceValidation[] pfbalancevalidations = _IFRS9Service.GetPfBalanceValidations(defaultCount);
                return request.CreateResponse<PfBalanceValidation[]>(HttpStatusCode.OK, pfbalancevalidations);
            });
        }



        [HttpGet]
        [Route("getPfBalanceValidationbysearch/{searchParam}")]
        public HttpResponseMessage GetPfBalanceValidationBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                PfBalanceValidation[] pfbalancevalidations = _IFRS9Service.GetPfBalanceValidationBySearch(searchParam);
                return request.CreateResponse<PfBalanceValidation[]>(HttpStatusCode.OK, pfbalancevalidations.ToArray());
            });
        }

         
        [HttpGet]
        [Route("getDistinctPfBalances")]
        public HttpResponseMessage GetDistinctScbPfBalances(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                string[] scbpfbalances = _IFRS9Service.GetDistinctScbPfBalances();
                return request.CreateResponse<string[]>(HttpStatusCode.OK, scbpfbalances.ToArray());
            });
        }



        [HttpGet]
        [Route("getDistinctGLCodes")]
        public HttpResponseMessage GetDistinctScbGLCodes(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                string[] scbGLCodes = _IFRS9Service.GetDistinctScbGLCodes();
                return request.CreateResponse<string[]>(HttpStatusCode.OK, scbGLCodes.ToArray());
            });
        }


        [HttpPost]
        [Route("GetPfBalanceValidationList")]
        public HttpResponseMessage GetPfBalanceValidationList(HttpRequestMessage request, [FromBody] CaptionModel pfoptions) {
            return GetHttpResponse(request, () => {
                PfBalanceValidation[] pfbalancevalidations = _IFRS9Service.GetPfBalanceValidationList(pfoptions.Code, pfoptions.Name);
                return request.CreateResponse<PfBalanceValidation[]>(HttpStatusCode.OK, pfbalancevalidations.ToArray());
            });
        }

    }
}
