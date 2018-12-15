using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Respository
{
    public interface IXeRespository
    {
        Task<Response> Add(Xe xe);
        Task<IEnumerable<Xe>> GetAll();
        Task<Xe> Find(int id);
        Task<Response> Update(Xe xe);
        Task<Response> Remove(int id);
    }
}
