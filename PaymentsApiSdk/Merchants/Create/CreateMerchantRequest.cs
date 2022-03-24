﻿using PingPayments.PaymentsApi.Merchants.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Create
{
    public record CreateMerchantRequest
    {
        /// <summary>
        /// Tenants name of the merchant
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The merchants underlying organization
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}