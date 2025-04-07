using Microsoft.AspNetCore.Mvc;
using CaseApp.Klasser;
using CaseApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseApp.Controllers
{
    [ApiController]
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository storeRepo;

        public StoreController(IStoreRepository storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        // GET: api/store
        [HttpGet]
        public async Task<IEnumerable<Store>> GetStores()
        {
            return await storeRepo.GetStores();
        }

        // GET: api/store/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetById(int id)
        {
            var store = await storeRepo.GetById(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }

        // POST: api/store
        [HttpPost]
        public async Task<IActionResult> AddStore(Store store)
        {
            await storeRepo.AddStore(store);
            return Ok();
        }

        // PUT: api/store
        [HttpPut]
        public async Task<IActionResult> UpdateStore(Store store)
        {
            await storeRepo.UpdateStore(store);
            return Ok();
        }

        // DELETE: api/store/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            await storeRepo.DeleteStore(id);
            return Ok();
        }
    }
}
