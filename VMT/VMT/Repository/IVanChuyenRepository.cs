using System.Collections.Generic;
using System.Threading.Tasks;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Repository
{
    public interface IVanChuyenRepository
    {
        Task<Response> Add(VanChuyen vanChuyen);
        Task<IEnumerable<VanChuyen>> GetAll(string qr);
        Task<VanChuyen> Find(int id);
        Task<Response> Update(int id, VanChuyen vanChuyen);
        Task<Response> Remove(int id);
    }
}
