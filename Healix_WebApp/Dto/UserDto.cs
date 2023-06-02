using Healix_WebApp.Models;
using System.Text.Json.Serialization;

namespace Healix_WebApp.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNumber { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }
    }

}
