﻿using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.Create
{
    public class CreatePaymentOrderEndpoint : TenantEndpointBase<Guid?, GuidResponse>
    {
        public CreatePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<GuidResponse> Action(Guid? SplitTreeId = null) => 
            await Execute
            (
                $"api/v1/payment_orders", 
                RequestTypeEnum.POST,
                SplitTreeId.HasValue ? ToJson(new { split_tree_id = SplitTreeId.Value }) : ToJson(new {})
            );

        protected override async Task<GuidResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new GuidResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<GuidResponseBody>(responseBody)
                    ),
                _ =>
                    new GuidResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}