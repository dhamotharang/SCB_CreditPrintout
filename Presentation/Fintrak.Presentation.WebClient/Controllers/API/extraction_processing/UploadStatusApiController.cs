using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fintrak.Client.Core.Entities;
using Fintrak.Client.Core.Contracts;
using Fintrak.Client.Core.Entities;
using Fintrak.Presentation.WebClient.Core;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Presentation.WebClient.Models;
using Fintrak.Client.Core.Contracts;

namespace Fintrak.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/uploadstatus")]
    [UsesDisposableService]
    public class UploadStatusApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public UploadStatusApiController(IExtractionProcessService coreService)        {
            _ExtractionProcessService = coreService;
        }

        IExtractionProcessService _ExtractionProcessService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)        {
            disposableServices.Add(_ExtractionProcessService);
        }

        [HttpPost]
        [Route("updateuploadstatus")]
        public HttpResponseMessage UpdateUploadStatus(HttpRequestMessage request, [FromBody] UploadStatus uploadstatusModel){
            return GetHttpResponse(request, () => {
                var uploadstatus = _ExtractionProcessService.UpdateUploadStatus(uploadstatusModel);
                return request.CreateResponse<UploadStatus>(HttpStatusCode.OK, uploadstatus);
            });
        }

        [HttpPost]
        [Route("deleteuploadstatus")]
        public HttpResponseMessage DeleteUploadStatus(HttpRequestMessage request, [FromBody]int uploadstatusId){
            return GetHttpResponse(request, () =>       {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                UploadStatus uploadstatus = _ExtractionProcessService.GetUploadStatus(uploadstatusId);
                if (uploadstatus != null)      {
                    _ExtractionProcessService.DeleteUploadStatus(uploadstatusId);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No uploadstatus found under that ID.");

                return response;
            });
        }


        [HttpGet]
        [Route("getuploadstatus/{uploadstatusId}")]
        public HttpResponseMessage GetUploadStatus(HttpRequestMessage request,int uploadstatusId) {
            return GetHttpResponse(request, () =>   {
                HttpResponseMessage response = null;
                UploadStatus uploadstatus = _ExtractionProcessService.GetUploadStatus(uploadstatusId);
                response = request.CreateResponse<UploadStatus>(HttpStatusCode.OK, uploadstatus);
                return response;
            });
        }


        [HttpGet]
        [Route("getalluploadstatus")]
        public HttpResponseMessage GetAllUploadStatus(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;
                UploadStatus[] uploadstatus = _ExtractionProcessService.GetAllUploadStatuss();
                response = request.CreateResponse<UploadStatus[]>(HttpStatusCode.OK, uploadstatus);
                return response;
            });
        }


    }
}
