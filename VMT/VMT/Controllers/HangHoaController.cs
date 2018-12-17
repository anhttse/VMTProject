using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VMT.Models;
using VMT.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VMT.Controllers
{
    [Route("api/[controller]")]
    public class HangHoaController : Controller
    {
        public IHangHoaRepository HangHoa { get; set; }

        public HangHoaController(IHangHoaRepository repo)
        {
            HangHoa = repo;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get(string qr)
        {
            var rs = await HangHoa.GetAll(qr);
            return Ok(rs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rs = await HangHoa.Find(id);
            return Ok(rs);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HangHoa hangHoa)
        {
            var rs = await HangHoa.Add(hangHoa);
            return Ok(rs);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]HangHoa hangHoa)
        {
            var rs = await HangHoa.Update(id, hangHoa);
            return Ok(rs);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await HangHoa.Remove(id);
            return Ok(rs);
        }
    }
}
