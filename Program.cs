using System;
using System.Collections.Generic;

namespace Delegates01
{
    
    public struct Book
    {
        public int ID;
        public string Name;
        public bool Paperback;
        public string Comment;

        public Book(int in_counter, string in_name, bool in_paperback, string in_comment = "")
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
    }
        
    class BookProcessing
    {
        public void PrintBookInfo(Book in_Book)
        {
            Console.WriteLine("ID: " + in_Book.ID);
            Console.WriteLine("Name: " + in_Book.Name);
            Console.WriteLine("Paperback: " + in_Book.Paperback);
            Console.WriteLine("Comment: " + in_Book.Comment);
        }     
    }

    public class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test code ..");
            var bookDB = new BookDB();
            AddBooks(bookDB);
            var bookProc = new BookProcessing();
            bookDB.doSomeThingWithBookDB(AddComment);     
            bookDB.doSomeThingWithBookDB(bookProc.PrintBookInfo);
        } 

        static void AddComment(Book in_Book)
        {
            in_Book.Comment = "first comment";
        }
        
        static void AddBooks(BookDB in_BookDB)
        {
            in_BookDB.AddBook(new Book {ID=1, Name="book 1", Paperback=true, Comment="Test"});
            in_BookDB.AddBook(new Book {ID=2, Name="book 2", Paperback=true});
            in_BookDB.AddBook(new Book {ID=3, Name="book 3", Paperback=false});
        }
    
    }
}