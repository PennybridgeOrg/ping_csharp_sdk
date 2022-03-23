﻿using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.Close
{
    public class ClosePaymentOrderEndpoint : TenantEndpointBase<Guid, EmptyResponse>
    {
        public ClosePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<EmptyResponse> Action(Guid orderId) => 
            await Execute
            (
                $"api/v1/payment_orders/{orderId}/close", 
                RequestTypeEnum.PUT,
                ToJson(new { })
            );

        protected override async Task<EmptyResponse> HttpResponseToResponse(HttpResponseMessage hrm) => hrm.StatusCode switch
        {
            HttpStatusCode.NoContent =>
                EmptyResponse.Empty
                (
                    (int)hrm.StatusCode,
                    true
                ),
            _ =>
                new EmptyResponse
                (
                    (int)hrm.StatusCode,
                    false,
                    Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsync())
                )
        };
    }
}