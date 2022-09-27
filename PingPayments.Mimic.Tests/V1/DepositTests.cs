﻿using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.Shared.Enums;

namespace PingPayments.Mimic.Tests.V1
{
    public class DepositTests : BaseResourceTests
    {

        [Fact]
        public async Task Create_deposit_returns_204()
        {
            var request = new CreateDepositRequest(2000, CurrencyEnum.SEK, "OCR", "100817790");
            var response = await _api.Deposit.V1.Create(request);
            AssertHttpNoContent(response);
        }
    }
}
