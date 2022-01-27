using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteka.Core.Domain
{
    public class BookshelfInfo
    {
        [ForeignKey("Bookshelf")]
        public int Id { get; set; }
        public int NOfShelves { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        
        public virtual Bookshelf Bookshelf {get; set;}
    }
}
