using System;
using System.Collections.Generic;

namespace TimeTracker.Apps.ViewModels
{
    public class Token
    {
        public Token()
        { }
        
        public  string access_token { get; set; }


		public string refresh_token { get; set; }


		public string token_type { get; set; }


		public int expires_in { get; set; }
	}
}
