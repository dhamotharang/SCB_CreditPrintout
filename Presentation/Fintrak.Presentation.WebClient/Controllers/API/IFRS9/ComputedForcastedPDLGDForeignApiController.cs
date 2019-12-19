﻿using System;
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
    [RoutePrefix("api/computedforcastedpdlgdforeign")]
    [UsesDisposableService]
    public class ComputedForcastedPDLGDForeignApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ComputedForcastedPDLGDForeignApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        //[HttpPost]
        //[Route("updatecomputedForcastedPDLGD")]
        //public HttpResponseMessage UpdateComputedForcastedPDLGDForeign(HttpRequestMessage request, [FromBody]ComputedForcastedPDLGDForeign computedForcastedPDLGDModel)
        //{
        //    return GetHttpResponse(request, () =>
        //    {
        //        var computedForcastedPDLGD = _IFRS9Service.UpdateComputedForcastedPDLGDForeign(computedForcastedPDLGDModel);

        //        return request.CreateResponse<ComputedForcastedPDLGDForeign>(HttpStatusCode.OK, computedForcastedPDLGD);
        //    });
        //}

        //[HttpPost]
        //[Route("deletecomputedForcastedPDLGD")]
        //public HttpResponseMessage DeleteComputedForcastedPDLGDForeign(HttpRequestMessage request, [FromBody]int computedForcastedPDLGDId)
        //{
        //    return GetHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;

        //        // not that calling the WCF service here will authenticate access to the data
        //        ComputedForcastedPDLGDForeign computedForcastedPDLGD = _IFRS9Service.GetComputedForcastedPDLGDForeign(computedForcastedPDLGDId);

        //        if (computedForcastedPDLGD != null)
        //        {
        //            _IFRS9Service.DeleteComputedForcastedPDLGDForeign(computedForcastedPDLGDId);

        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        else
        //            response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No computedForcastedPDLGD found under that ID.");

        //        return response;
        //    });
        //}

        //[HttpGet]
        //[Route("getcomputedForcastedPDLGD/{computedForcastedPDLGDId}")]
        //public HttpResponseMessage GetComputedForcastedPDLGDForeign(HttpRequestMessage request,int computedForcastedPDLGDId)
        //{
        //    return GetHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;

        //        ComputedForcastedPDLGDForeign computedForcastedPDLGD = _IFRS9Service.GetComputedForcastedPDLGDForeign(computedForcastedPDLGDId);

        //        // notice no need to create a seperate model object since ComputedForcastedPDLGDForeign entity will do just fine
        //        response = request.CreateResponse<ComputedForcastedPDLGDForeign>(HttpStatusCode.OK, computedForcastedPDLGD);

        //        return response;
        //    });
        //}

        [HttpGet]
        [Route("availablecomputedForcastedPDLGDForeigns")]
        public HttpResponseMessage GetAvailableComputedForcastedPDLGDForeigns(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                ComputedForcastedPDLGDForeign[] computedForcastedPDLGDForeigns = _IFRS9Service.GetListComputedForcastedPDLGDForeigns();

                return request.CreateResponse<ComputedForcastedPDLGDForeign[]>(HttpStatusCode.OK, computedForcastedPDLGDForeigns);
            });
        }
    }
}
