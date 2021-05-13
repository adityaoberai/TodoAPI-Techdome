using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("task")]
        public string TaskToDo { get; set; }
    }
}
