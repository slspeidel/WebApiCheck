using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCheck.DataAccess;
using Newtonsoft.Json;

namespace WebApiCheck.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Repo _repo;
        public ValuesController()
        {
            _repo = new DataAccess.Repo();
        }
        // GET api/values
        public IEnumerable<Book> Get()
        {
            var values = _repo.GetBooks();
            //var values = "{'result': [{'value1': 0, 'value2': 1}, {'value3': 2, 'value4': 3}]}";
            
            return values;
        }

        // GET api/values/5
        public Book Get(int id)
        {
            return _repo.GetBook(id);
        }

        // POST api/values
        public void Post([FromBody]string bookStr)
        {
            Book book = JsonConvert.DeserializeObject<Book>(bookStr);
            _repo.PostBook(book);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string bookStr)
        {
            Book book = JsonConvert.DeserializeObject<Book>(bookStr);
            _repo.PutBook(id, book);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var result = _repo.DeleteBook(id);
        }
    }
}
