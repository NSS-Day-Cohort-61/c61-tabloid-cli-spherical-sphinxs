using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabloidCLI.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
