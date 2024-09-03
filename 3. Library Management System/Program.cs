using System;

namespace myApp
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsIssued { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsIssued = false;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Added: {book.Title}");
        }

        public void IssueBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null && !book.IsIssued)
            {
                book.IsIssued = true;
                Console.WriteLine($"Issued: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book not available or already issued");
            }
        }

        public void ReturnBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null && book.IsIssued)
            {
                book.IsIssued = false;
                Console.WriteLine($"Returned: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book not issued");
            }
        }

        public void ListBooks()
        {
            Console.WriteLine("Available Books:");
            foreach (var book in books)
            {
                if (book.IsIssued == false)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("C# Programming", "John Doe", "123456"));
            library.AddBook(new Book("Learn OOP", "Jane Doe", "654321"));

            library.ListBooks();

            library.IssueBook("123456");
            library.ListBooks();

            library.ReturnBook("123456");
            library.ListBooks();
        }
    }

}