using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteka.Core.Domain
{
    public class Copy
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public Book Book { get; set; }
        
        public Bookshelf Bookshelf { get; set; }
    }
}
