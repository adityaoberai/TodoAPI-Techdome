using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string TaskToDo { get; set; }
    }
}
