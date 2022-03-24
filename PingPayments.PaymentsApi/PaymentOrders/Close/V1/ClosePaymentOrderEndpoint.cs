﻿using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Close.V1
{
    public class ClosePaymentOrderEndpoint : TenantEndpointBase<Guid, EmptyResponse>
    {
        public ClosePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid orderId) => 
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{orderId}/close",
                ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm) => hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Succesful(hrm.StatusCode),
            _ => EmptyResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsync()))
        };
    }
}