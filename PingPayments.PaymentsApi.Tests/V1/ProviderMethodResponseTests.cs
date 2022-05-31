﻿using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using System.Threading.Tasks;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using Xunit;
using System.Text.Json.Serialization;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class ProviderMethodResponseTests
    {
        [Fact]
        public async Task Can_parse_dummy() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.dummy, 
                    MethodEnum.dummy,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is DummyResponseBody
            );        
        
        [Fact]
        public async Task Can_parse_swish_ecommerce() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.swish, 
                    MethodEnum.e_commerce,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is SwishECommerceResponseBody
            );        
        
        [Fact]
        public async Task Can_parse_swish_mcommerce_without_qr() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.swish, 
                    MethodEnum.m_commerce,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"url\":\"swish://paymentrequest?token=c28a4061470f4af48973bd2a4642b4fa&callbackurl=merchant%253A%252F%252F\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is SwishMCommerceResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.SwishUrl)
            );

        [Fact]
        public async Task Can_parse_swish_mcommerce_with_qr() =>
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.swish,
                    MethodEnum.m_commerce,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"url\":\"swish://paymentrequest?token=c28a4061470f4af48973bd2a4642b4fa&callbackurl=merchant%253A%252F%252F\",\"qr_code\":\"<svg>foo</svg>\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() } }
                ) is SwishMCommerceResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.SwishUrl) &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.QrCode)
            );

        [Fact]
        public async Task Can_parse_verifone() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.verifone, 
                    MethodEnum.card,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"redirect_url\":\"https://verifone.com/pay/whatever\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is VerifoneResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.RedirectUrl)
            );
        
        [Fact]
        public async Task Can_parse_billmate() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.billmate, 
                    MethodEnum.invoice,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"invoice_url\":\"https://billmate.com/invoice\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is BillmateResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.InvoiceUrl)
            );
        
        [Fact]
        public async Task Can_parse_paymentiq_card() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.payment_iq, 
                    MethodEnum.card,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"pay_url\":\"https://payment-iq.com/pay\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is PaymentIqResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.PayUrl)
            );

        [Fact]
        public async Task Can_parse_paymentiq_vipps() => 
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.payment_iq, 
                    MethodEnum.vipps,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"pay_url\":\"https://payment-iq.com/pay\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() }}
                ) is PaymentIqResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.PayUrl)
            );

        [Fact]
        public async Task Can_parse_ping_deposit() =>
            Assert.True
            (
                await InitiateOperation.GetResponseBody
                (
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"reference\":\"abcd1234\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() } }
                ) is PingDepositResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse.Reference)
            );
    }
}
