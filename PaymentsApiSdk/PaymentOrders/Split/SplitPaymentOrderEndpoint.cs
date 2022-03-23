﻿using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.Split
{
    public class SplitPaymentOrderEndpoint : TenantEndpointBase<Guid, EmptyResponse>
    {
        public SplitPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<EmptyResponse> Action(Guid orderId) => 
            await Execute
            (
                $"api/v1/payment_orders/{orderId}/split", 
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