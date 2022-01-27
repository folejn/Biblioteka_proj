using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteka.Core.Domain
{
    public class Bookshelf
    {
        [Key]
        public int Id { get; set; }
        public int Floor { get; set; }
        public virtual BookshelfInfo BookshelfInfo { get; set; }
    }
}
