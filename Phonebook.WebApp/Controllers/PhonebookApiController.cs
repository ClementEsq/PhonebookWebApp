using Phonebook.WebApp.Infrastructure.Interfaces;
using Phonebook.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Phonebook.WebApp.Controllers
{
    [RoutePrefix("api/phonebook")]
    public class PhonebookApiController : ApiController
    {
        private readonly IPhonebookService PhonebookService;

        public PhonebookApiController(IPhonebookService PhonebookService)
        {
            this.PhonebookService = PhonebookService;
        }

        [Route("new")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostPhonebookEntry(Entry request)
        {
            if (ModelState.IsValid)
            {
                var entry = await PhonebookService.CreatePhonebookEntry(request);

                //return CreatedAtRoute("DefaultApi", new { id = entry.Id }, entry);
                return StatusCode(HttpStatusCode.NoContent);
            }
            return BadRequest(ModelState);
        }

        [Route("delete/{id}")]
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> DeletePhonebookEntry(int id)
        {
            var entry = await PhonebookService.GetSinglePhonebookEntry(id);
            if (entry == null)
            {
                return NotFound();
            }

            await PhonebookService.DeletePhonebookEntry(id);

            return Ok(entry);
        }

        [Route("edit/{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhonebookEntry(int id, Entry request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                await PhonebookService.EditPhonebookEntry(request);
            }
            catch (Exception ex)
            {
                if (PhonebookService.GetSinglePhonebookEntry(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("entries/{id:int:min(1)}")]
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> GetPhonebookEntry(int id)
        {
            Entry entry = await PhonebookService.GetSinglePhonebookEntry(id);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [Route("entries")]
        public async Task<IQueryable<Entry>> GetPhonebookEntries()
        {
            var entries = await PhonebookService.GetPhonebookEntries();
            return entries.AsQueryable();
        }
    }
}
