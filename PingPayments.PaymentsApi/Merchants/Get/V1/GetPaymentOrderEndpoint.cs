﻿using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.Get.V1
{
    public class GetMerchantEndpoint : EndpointBase<Guid, MerchantResponse>
    {
        public GetMerchantEndpoint(HttpClient httpClient) : base(httpClient) { }

        public override async Task<MerchantResponse> ExecuteRequest(Guid merchantId) => 
            await BaseExecute(GET, $"api/v1/merchants/{merchantId}", merchantId);

        protected override async Task<MerchantResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => MerchantResponse.Succesful(hrm.StatusCode, await Deserialize<Merchant>(responseBody), responseBody),
                _ => MerchantResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}