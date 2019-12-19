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
    [RoutePrefix("api/scbproduct")]
    [UsesDisposableService]
    public class ScbProductApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ScbProductApiController(IIFRS9Service ifrs9Service)
        {
            _IFRS9Service = ifrs9Service;
        }

        IIFRS9Service _IFRS9Service;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_IFRS9Service);
        }

        [HttpPost]
        [Route("updatescbproduct")]
        public HttpResponseMessage UpdateScbProduct(HttpRequestMessage request, [FromBody]ScbProduct scbproductModel)
        {
            return GetHttpResponse(request, () =>
            {
                var scbproduct = _IFRS9Service.UpdateScbProduct(scbproductModel);

                return request.CreateResponse<ScbProduct>(HttpStatusCode.OK, scbproduct);
            });
        }

        [HttpPost]
        [Route("deletescbproduct")]
        public HttpResponseMessage DeleteScbProduct(HttpRequestMessage request, [FromBody]int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ScbProduct scbproduct = _IFRS9Service.GetScbProduct(ID);

                if (scbproduct != null)
                {
                    _IFRS9Service.DeleteScbProduct(ID);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No ScbProduct found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getscbproduct/{ID}")]
        public HttpResponseMessage GetScbProduct(HttpRequestMessage request,int ID)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ScbProduct scbproduct = _IFRS9Service.GetScbProduct(ID);

                // notice no need to create a seperate model object since ScbProduct entity will do just fine
                response = request.CreateResponse<ScbProduct>(HttpStatusCode.OK, scbproduct);

                return response;
            });
        }

        [HttpGet]
        [Route("availablescbproducts/{defaultCount}")]
        public HttpResponseMessage GetAvailableScbProducts(HttpRequestMessage request, int defaultCount){
            return GetHttpResponse(request, () => {
                ScbProduct[] scbproducts = _IFRS9Service.GetScbProducts(defaultCount);
                return request.CreateResponse<ScbProduct[]>(HttpStatusCode.OK, scbproducts);
            });
        }



        [HttpGet]
        [Route("getScbProductbysearch/{searchParam}")]
        public HttpResponseMessage GetScbProductBySearch(HttpRequestMessage request, string searchParam) {
            return GetHttpResponse(request, () => {
                ScbProduct[] scbproducts = _IFRS9Service.GetScbProductBySearch(searchParam);
                return request.CreateResponse<ScbProduct[]>(HttpStatusCode.OK, scbproducts.ToArray());
            });
        }





    }
}
