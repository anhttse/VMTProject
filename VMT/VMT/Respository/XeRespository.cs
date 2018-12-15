using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Respository
{
    public class XeRespository : IXeRespository
    {
        private VMTContext _db;

        public XeRespository()
        {
            _db = new VMTContext();
        }

        public async Task<Response> Add(Xe xe)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Thêm xe không thành công" };
            try
            {
                await _db.Xe.AddAsync(xe);
                var rs = await _db.SaveChangesAsync();
                if (rs <= 0) return rp;
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Thêm xe thành công";

                return rp;
            }
            catch (SqlException sqlE)
            {
                Console.WriteLine(sqlE.ToString());
                return rp;
            }
        }

        public Task<IEnumerable<Xe>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Xe> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Xe xe)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
