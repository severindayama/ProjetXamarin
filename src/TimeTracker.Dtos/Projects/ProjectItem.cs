using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TimeTracker.Dtos.Projects
{
    public class ProjectItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("total_seconds")]
        public long TotalSeconds { get; set; }

       

        public void fill(JToken  liste)
        {
            this.Id = (long)liste["id"];
            this.Name = (string)liste["name"];
            this.TotalSeconds = (long)liste["total_seconds"];
            this.Description = (string)liste["description"];
        }
    }
}