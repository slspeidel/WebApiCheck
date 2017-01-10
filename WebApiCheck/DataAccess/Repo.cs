using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCheck.DataAccess
{
    public class Repo
    {
        private readonly Entities1 _db;
        public Repo()
        {
            _db = new Entities1();
        }
        public IEnumerable<Book> GetBooks()
        {
            var books = from b in _db.Books
                        //where b.Price < (decimal)100.00
                        select b;
            return books;
        }
        public Book GetBook(int id)
        {
            var book = (from b in _db.Books
                       where b.Id == id
                       select b).Single<Book>();
            return book;
        }
        public void PostBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void PutBook(int id, Book changedBook)
        {
            // get a reference to the book with the given id
            var book = (from b in _db.Books
                        where b.Id == id
                        select b).Single();
            // put the values from changedBook into the book
            SetProperties(ref book, changedBook);

            _db.SaveChanges();  // save the modifications to the database
        }

        public int DeleteBook(int id)
        {
            var result = 0;
            try
            {
                // get a reference to the book with the given id
                var book = (from b in _db.Books
                            where b.Id == id
                            select b).Single();
                _db.Books.Remove(book);
                _db.SaveChanges();  // save the modifications to the database
                result = 1;
            }
            catch { }

            return result;
        }

        protected void SetProperties(ref Book book, Book changedBook)
        {
            //use reflection
            var bookType = book.GetType();
            var props = bookType.GetProperties();
            foreach (var prop in props)
            {
                try
                {
                    if (prop.Name != "Id") prop.SetValue(book, prop.GetValue(changedBook, null), null);
                }
                catch { }  // ignore exception for properties without a set
            }
        }
    }
}