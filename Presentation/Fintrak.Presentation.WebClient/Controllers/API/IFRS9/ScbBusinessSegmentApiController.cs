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
    [RoutePrefix("api/scbbusinesssegment")]
    [UsesDisposableService]
    public class ScbBusinessSegmentApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbBusinessSegmentApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbbusinesssegment")]
        public HttpResponseMessage UpdateScbBusinessSegment(HttpRequestMessage request, [FromBody]ScbBusinessSegment scbbusinesssegmentModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbbusinesssegment = _IFRS9Service.UpdateScbBusinessSegment(scbbusinesssegmentModel);
                return request.CreateResponse<ScbBusinessSegment>(HttpStatusCode.OK, scbbusinesssegment);
            });
        }

        [HttpPost]
        [Route("deletescbbusinesssegment")]
        public HttpResponseMessage DeleteScbBusinessSegment(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // not that calling the WCF service here will authenticate access to the data
                ScbBusinessSegment scbbusinesssegment = _IFRS9Service.GetScbBusinessSegment(ID);
                if (scbbusinesssegment != null)
                {
                    _IFRS9Service.DeleteScbBusinessSegment(ID);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbBusinessSegment found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbbusinesssegment/{ID}")]
        public HttpResponseMessage GetScbBusinessSegment(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>            {
                HttpResponseMessage response = null;
                ScbBusinessSegment scbbusinesssegment = _IFRS9Service.GetScbBusinessSegment(ID);
                // notice no need to create a seperate model object since ScbBusinessSegment entity will do just fine
                response = request.CreateResponse<ScbBusinessSegment>(HttpStatusCode.OK, scbbusinesssegment);
                return response;
            });
        }

        [HttpGet]
        [Route("availablescbbusinesssegments/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbBusinessSegments(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbBusinessSegment[] scbbusinesssegments = _IFRS9Service.GetScbBusinessSegments(defaultCount);
                return request.CreateResponse<ScbBusinessSegment[]>(HttpStatusCode.OK, scbbusinesssegments);
            });
        }



        [HttpGet]
        [Route("getScbBusinessSegmentbysearch/{searchParam}")]
        public HttpResponseMessage GetScbBusinessSegmentBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbBusinessSegment[] scbbusinesssegments = _IFRS9Service.GetScbBusinessSegmentBySearch(searchParam);
                return request.CreateResponse<ScbBusinessSegment[]>(HttpStatusCode.OK, scbbusinesssegments.ToArray());
            });
        }



    }
}
