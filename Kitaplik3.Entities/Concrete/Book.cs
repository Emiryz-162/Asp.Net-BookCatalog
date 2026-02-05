using Kitaplik3.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public bool IsDelete { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public string? FotoUrl { get; set; }

    }
}
