using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Infrastructure.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
