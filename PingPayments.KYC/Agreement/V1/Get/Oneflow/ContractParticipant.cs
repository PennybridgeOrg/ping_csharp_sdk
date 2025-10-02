using PingPayments.KYC.Agreement.V1.Create.Oneflow;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get.Oneflow
{
    public class ContractParticipant
    {
        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets Delivery Channel
        /// </summary>
        [JsonPropertyName("delivery_channel")]
        public ContractDeliveryChannelEnum DeliveryChannel { get; set; }

        /// <summary>
        /// Gets or Sets delivery_status
        /// </summary>
        [JsonPropertyName("delivery_status")]
        public ContractDeliveryStatusEnum DeliveryStatus { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// participant id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Identity
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets organizer
        /// </summary>
        [JsonPropertyName("organizer")]
        public bool Organizer { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets SignState
        /// </summary>
        [JsonPropertyName("sign_state")]
        public ContractSignedStateEnum SignState { get; set; }

        /// <summary>
        /// Gets or Sets SignStateUpdatedAt
        /// </summary>
        [JsonPropertyName("sign_state_updated_at")]
        public DateTimeOffset? SignStateUpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets SignMethod
        /// </summary>
        [JsonPropertyName("sign_method")]
        public SignMethodEnum SignMethod { get; set; }

        /// <summary>
        /// Gets or Sets Signatory
        /// </summary>
        [JsonPropertyName("signatory")]
        public bool? Signatory { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets TwoStepAuthenticationMethod
        /// </summary>
        [JsonPropertyName("two_step_authentication_method")]
        public AuthenticationMethodEnum? TwoStepAuthenticationMethod { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneflowContractParticipant {\n");
            sb.Append("  Identity: ").Append(Identity).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SignState: ").Append(SignState).Append("\n");
            sb.Append("  Signatory: ").Append(Signatory).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

    }
}
