using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using NetCoreODataSample.Data;

namespace NetCoreODataSample.Controllers
{
    public class BooksController : ODataController
    {
        private readonly BookStoreContext _bookStoreContext;


        public BooksController(BookStoreContext context)
        {
            _bookStoreContext = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in BooksDataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }


        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_bookStoreContext.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_bookStoreContext.Books.FirstOrDefault(c => c.Id == key));
        }


        [EnableQuery]
        public IActionResult Post([FromBody]Book book)
        {
            _bookStoreContext.Books.Add(book);
            _bookStoreContext.SaveChanges();
            return Created(book);
        }



    }
}