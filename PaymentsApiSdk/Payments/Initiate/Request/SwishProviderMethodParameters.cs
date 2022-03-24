﻿using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Initiate.Request
{
    public record SwishProviderMethodParameters
    (
        string Message,
        string PhoneNumber
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "message", Message ?? "" },
            { "phone_number", PhoneNumber }
        };
    }
}
