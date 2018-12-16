using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VMT.Models;
using VMT.Respository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VMT.Controllers
{
    [Route("api/[controller]")]
    public class XeController : Controller
    {
        public IXeRespository XeRespository { get; set; }

        public XeController(IXeRespository repo)
        {
            XeRespository = repo;
        }
        // GET: api/values
        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Get(string qr)

        {
            var rs = await XeRespository.GetAll();
            return Ok(rs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rs = await XeRespository.Find(id);
            return Ok(rs);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Xe xe)
        {
            var rs = await XeRespository.Add(xe);
            return Ok(rs);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Xe xe)
        {
            var rs = await XeRespository.Update(id, xe);
            return Ok(rs);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await XeRespository.Remove(id);
            return Ok(rs);
        }
    }
}
