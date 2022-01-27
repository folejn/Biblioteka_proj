using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Infrastructure.Commands
{
    public class UpdateAuthor
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
