using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteka.Core.Domain
{
    public class Book
    {
		public Book()
		{
			this.Authors = new HashSet<Author>();
		}
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime IssueDate { get; set; }
		public virtual ICollection<Author> Authors { get; set; }


	}
}
