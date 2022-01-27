using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Infrastructure.Commands
{
    public class CreateBook
    {
        public string Title { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
