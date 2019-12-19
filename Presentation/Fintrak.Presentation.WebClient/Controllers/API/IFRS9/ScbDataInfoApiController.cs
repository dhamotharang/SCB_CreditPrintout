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
    [RoutePrefix("api/scbdatainfo")]
    [UsesDisposableService]
    public class ScbDataInfoApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbDataInfoApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbdatainfo")]
        public HttpResponseMessage UpdateScbDataInfo(HttpRequestMessage request, [FromBody]ScbDataInfo scbdatainfoModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbdatainfo = _IFRS9Service.UpdateScbDataInfo(scbdatainfoModel);

                return request.CreateResponse<ScbDataInfo>(HttpStatusCode.OK, scbdatainfo);
            });
        }

        [HttpPost]
        [Route("deletescbdatainfo")]
        public HttpResponseMessage DeleteScbDataInfo(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbDataInfo scbdatainfo = _IFRS9Service.GetScbDataInfo(ID);

                if (scbdatainfo != null){
                    _IFRS9Service.DeleteScbDataInfo(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbDataInfo found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbdatainfo/{ID}")]
        public HttpResponseMessage GetScbDataInfo(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>            {
                HttpResponseMessage response = null;
                ScbDataInfo scbdatainfo = _IFRS9Service.GetScbDataInfo(ID);
                response = request.CreateResponse<ScbDataInfo>(HttpStatusCode.OK, scbdatainfo);
                return response;
            });
        }

        [HttpGet]
        [Route("availablescbdatainfos/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbDataInfos(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbDataInfo[] scbdatainfos = _IFRS9Service.GetScbDataInfos(defaultCount);
                return request.CreateResponse<ScbDataInfo[]>(HttpStatusCode.OK, scbdatainfos);
            });
        }



        [HttpGet]
        [Route("getScbDataInfobysearch/{searchParam}")]
        public HttpResponseMessage GetScbDataInfoBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbDataInfo[] scbdatainfos = _IFRS9Service.GetScbDataInfoBySearch(searchParam);
                return request.CreateResponse<ScbDataInfo[]>(HttpStatusCode.OK, scbdatainfos.ToArray());
            });
        }


        [HttpGet]
        [Route("getScbDataInfoBalance")]
        public HttpResponseMessage getScbDataInfoBalance(HttpRequestMessage request) {
            return GetHttpResponse(request, () => {
                double scbdatainfoBalance = _IFRS9Service.getScbDataInfoBalance();
                return request.CreateResponse<double>(HttpStatusCode.OK, scbdatainfoBalance);
            });
        }


        [HttpGet]
        [Route("getOptionsFromFilter/{searchParam}")]
        public HttpResponseMessage GetScbOptionsByFilter(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                string[] scbdatainfos = _IFRS9Service.GetScbOptionsByFilter(searchParam);
                return request.CreateResponse<string[]>(HttpStatusCode.OK, scbdatainfos.ToArray());
            });
        }



        [HttpPost]
        [Route("updateFilteredScbDataInfo")]
        public HttpResponseMessage updateFilteredScbDataInfo(HttpRequestMessage request, [FromBody] ScbDataForm param) {
            return GetHttpResponse(request, () => {
                HttpResponseMessage response = null;

                _IFRS9Service.updateFilteredScbDataInfo(param.colName, param.oldValue, param.newValue);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }


        [HttpGet]
        [Route("exportscbdatainfo/{defaultCount}")]
        public HttpResponseMessage ExportScbDataInfo(HttpRequestMessage request, int defaultCount) {
            return GetHttpResponse(request, () => {
                if (defaultCount == 0) {
                    string path = HostingEnvironment.MapPath("~");
                    ScbDataInfo[] scbdatainfos = _IFRS9Service.ExportScbDataInfo(defaultCount, path + "ExportedData\\").ToArray();
                    var response = DownloadFileService.DownloadFile(path, "ScbDataInfo_Summary.zip");
                    return response;
                } else {
                    ScbDataInfo[] scbdatainfos = _IFRS9Service.ExportScbDataInfo(defaultCount, null);
                    return request.CreateResponse<ScbDataInfo[]>(HttpStatusCode.OK, scbdatainfos);
                }
            });
        }



    }
}
