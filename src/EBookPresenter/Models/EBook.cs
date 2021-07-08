using System;

namespace EBookPresenter.Models
{
    public class EBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}