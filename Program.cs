using System;
using System.Collections.Generic;

namespace Delegates01
{
    
    public class Book
    {
        public int ID;
        public string Name;
        public bool Paperback;
        public string Comment;

        public Book(int in_counter, string in_name, bool in_paperback, string in_comment)
        {
            ID = in_counter;
            Name = in_name;
            Paperback = in_paperback;
            Comment = in_comment;
        }
    }
    
    public delegate void ProcessBooksFromStore(Book in_Book);

    class BookDB
    {
        public List<Book> Books = new List<Book>();

        public void AddBook(Book in_Book)
        {
            Books.Add(in_Book);
        } 
    
        public void doSomeThingWithBookDB(ProcessBooksFromStore delProc)
        {
            foreach(Book book in Books)
            {
                if(book.Paperback)
                {
                    delProc(book);
                }
            }
        }
        public void PrintBookInfo(Book in_Book)
        {
            Console.WriteLine("ID: " + in_Book.ID);
            Console.WriteLine("Name: " + in_Book.Name);
            Console.WriteLine("Paperback: " + in_Book.Paperback);
            Console.WriteLine("Comment: " + in_Book.Comment);
        }    
        public void AddComment(Book in_Book)
        {
            in_Book.Comment = "first comment";
        }
    }

    public class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test code ..");
            var bookDB = new BookDB();
            AddBooks(bookDB);
            bookDB.doSomeThingWithBookDB(bookDB.AddComment);     
            bookDB.doSomeThingWithBookDB(bookDB.PrintBookInfo);
        } 
        
        static void AddBooks(BookDB in_BookDB)
        {
            in_BookDB.AddBook(new Book(1, "book 1",true, "Test"));
            in_BookDB.AddBook(new Book(2,"book 2",true,""));
            in_BookDB.AddBook(new Book(3,"book 3",false,""));
        }
    
    }
}