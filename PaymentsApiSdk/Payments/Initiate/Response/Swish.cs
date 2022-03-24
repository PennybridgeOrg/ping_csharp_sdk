﻿using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Initiate.Response
{
    public record Swish
    {
        public Swish(string swishUrl) => SwishUrl = swishUrl;

        [JsonPropertyName("swish_url")]
        public string SwishUrl { get; set; }
    }
}
