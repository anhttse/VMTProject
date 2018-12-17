using System.Collections.Generic;
using System.Threading.Tasks;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Repository
{
    public interface IXeRepository
    {
        Task<Response> Add(Xe xe);
        Task<IEnumerable<Xe>> GetAll();
        Task<Xe> Find(int id);
        Task<Response> Update(int id,Xe xe);
        Task<Response> Remove(int id);
    }
}
