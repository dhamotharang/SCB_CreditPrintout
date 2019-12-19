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
using System.Web.Hosting;
using Fintrak.Shared.Common.Services;


namespace Fintrak.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/scbdatatbvalidated")]
    [UsesDisposableService]
    public class ScbDataTBValidatedApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbDataTBValidatedApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbdatatbvalidated")]
        public HttpResponseMessage UpdateScbDataTBValidated(HttpRequestMessage request, [FromBody]ScbDataTBValidated scbdatatbvalidatedModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbdatatbvalidated = _IFRS9Service.UpdateScbDataTBValidated(scbdatatbvalidatedModel);

                return request.CreateResponse<ScbDataTBValidated>(HttpStatusCode.OK, scbdatatbvalidated);
            });
        }

        [HttpPost]
        [Route("deletescbdatatbvalidated")]
        public HttpResponseMessage DeleteScbDataTBValidated(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbDataTBValidated scbdatatbvalidated = _IFRS9Service.GetScbDataTBValidated(ID);

                if (scbdatatbvalidated != null){
                    _IFRS9Service.DeleteScbDataTBValidated(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbDataTBValidated found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbdatatbvalidated/{ID}")]
        public HttpResponseMessage GetScbDataTBValidated(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>            {
                HttpResponseMessage response = null;
                ScbDataTBValidated scbdatatbvalidated = _IFRS9Service.GetScbDataTBValidated(ID);
                response = request.CreateResponse<ScbDataTBValidated>(HttpStatusCode.OK, scbdatatbvalidated);
                return response;
            });
        }

        [HttpGet]
        [Route("availablescbdatatbvalidateds/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbDataTBValidateds(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbDataTBValidated[] scbdatatbvalidateds = _IFRS9Service.GetScbDataTBValidateds(defaultCount);
                return request.CreateResponse<ScbDataTBValidated[]>(HttpStatusCode.OK, scbdatatbvalidateds);
            });
        }



        [HttpGet]
        [Route("getScbDataTBValidatedbysearch/{searchParam}")]
        public HttpResponseMessage GetScbDataTBValidatedBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbDataTBValidated[] scbdatatbvalidateds = _IFRS9Service.GetScbDataTBValidatedBySearch(searchParam);
                return request.CreateResponse<ScbDataTBValidated[]>(HttpStatusCode.OK, scbdatatbvalidateds.ToArray());
            });
        }


        [HttpGet]
        [Route("getOptionsFromFilter/{searchParam}")]
        public HttpResponseMessage GetScbOptionsByFilter(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                string[] scbdatatbvalidateds = _IFRS9Service.GetScbOptionsByFilter(searchParam);
                return request.CreateResponse<string[]>(HttpStatusCode.OK, scbdatatbvalidateds.ToArray());
            });
        }


        [HttpGet]
        [Route("getScbDataTBValidatedBalance")]
        public HttpResponseMessage getScbDataTBValidatedBalance(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                double scbdatatbvalidated = _IFRS9Service.getScbDataTBValidatedBalance();
                return request.CreateResponse<double>(HttpStatusCode.OK, scbdatatbvalidated);
            });
        }

        //[HttpPost]
        //[Route("updateFilteredScbDataTBValidated")]
        //public HttpResponseMessage updateFilteredScbDataTBValidated(HttpRequestMessage request, [FromBody] ScbDataForm param) {
        //    return GetHttpResponse(request, () => {
        //        HttpResponseMessage response = null;
        //        _IFRS9Service.updateFilteredScbDataTBValidated(param.colName, param.oldValue, param.newValue);
        //        response = request.CreateResponse(HttpStatusCode.OK);
        //        return response;
        //    });
        //}


        [HttpGet]
          [Route("getScbDataTBLoanbyrange/{minValue}/{maxValue}")]
        public HttpResponseMessage GetScbDataTBLoanByRange(HttpRequestMessage request, double  minValue, double maxValue) {
            return GetHttpResponse(request, () => {
                //HttpResponseMessage response = null;
                ScbDataTBValidated[] scbdatafiltered = _IFRS9Service.GetScbDataTBValidatedsByRange(minValue , maxValue);
                 return request.CreateResponse<ScbDataTBValidated[]>(HttpStatusCode.OK, scbdatafiltered);
            });
        }




        [HttpGet]
        [Route("exportscbdatatbvalidated/{defaultCount}")]
        public HttpResponseMessage ExportScbDataTBValidated(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                if (defaultCount == 0) {
                    string path = HostingEnvironment.MapPath("~");
                    ScbDataTBValidated[] scbdatatbvalidateds = _IFRS9Service.ExportScbDataTBValidated(defaultCount, path + "ExportedData\\").ToArray();
                    var response = DownloadFileService.DownloadFile(path, "ScbDataTBValidated_Summary.zip");
                    return response;
                } else {
                    ScbDataTBValidated[] scbdatatbvalidateds = _IFRS9Service.ExportScbDataTBValidated(defaultCount, null);
                    return request.CreateResponse<ScbDataTBValidated[]>(HttpStatusCode.OK, scbdatatbvalidateds);
                }
            });
        }


    }
}
