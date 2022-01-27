using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Infrastructure.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime IssueDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BookDTO dTO &&
                   Id == dTO.Id &&
                   Title == dTO.Title &&
                   IssueDate == dTO.IssueDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, IssueDate);
        }
    }
}
