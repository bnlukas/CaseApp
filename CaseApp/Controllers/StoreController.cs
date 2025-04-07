using CaseApp; 
using CaseApp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace CaseApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;

    public StoreController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Store>> GetStores()
    {
        return Ok(_storeRepository.GetStores());
    }

    [HttpGet("{id}")]
    public ActionResult<Store> GetStore(int id)
    {
        var store = _storeRepository.GetById(id);
        if (store is null)
        {
            return NotFound();
        }
        return Ok(store);
    }

    [HttpPost]
    public ActionResult<Store> CreateStore(Store store)
    {
        var createdStore = _storeRepository.AddStore(store);
        return CreatedAtAction(nameof(GetStore), new { id = createdStore.Id }, createdStore);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStore(int id, Store store)
    {
        if (id != store.Id)
        {
            return BadRequest();
        }

        var existingStore = _storeRepository.GetById(id);
        if (existingStore is null)
        {
            return NotFound();
        }

        _storeRepository.UpdateStore(store);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStore(int id)
    {
        var store = _storeRepository.GetById(id);
        if (store is null)
        {
            return NotFound();
        }

        _storeRepository.DeleteStore(id);
        return NoContent();
    }
}