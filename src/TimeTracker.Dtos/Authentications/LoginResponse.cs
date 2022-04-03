using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TimeTracker.Dtos.Authentications
{
	public class LoginResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
		
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
		
		[JsonProperty("token_type")]
		public string TokenType { get; set; }
		
		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

        public static implicit operator LoginResponse(JObject v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator LoginResponse(JToken v)
        {
            throw new NotImplementedException();
        }
    }
}