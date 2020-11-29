using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.authors = new List<string>(authors);
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors => this.authors.AsReadOnly();

        public int CompareTo(Book book)
        {
            int compare = this.Year.CompareTo(book.Year);
            if (compare == 0)
                compare = this.Title.CompareTo(book.Title);

            return compare;
        }

        public override string ToString() => $"{this.Title} - {this.Year}";
    }
}
