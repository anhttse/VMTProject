using System.Collections.Generic;
using System.Threading.Tasks;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Repository
{
    public interface IHangHoaRepository
    {
        Task<Response> Add(HangHoa hangHoa);
        Task<IEnumerable<HangHoa>> GetAll(string qr);
        Task<HangHoa> Find(int id);
        Task<Response> Update(int id, HangHoa hangHoa);
        Task<Response> Remove(int id);
    }
}
