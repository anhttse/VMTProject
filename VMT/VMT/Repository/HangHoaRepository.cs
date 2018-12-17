using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Repository
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly VMTContext _db;

        public HangHoaRepository(VMTContext context)
        {
            _db = context;
        }
        public async Task<Response> Add(HangHoa hangHoa)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Thêm xe không thành công" };
            try
            {
                hangHoa.Ref = Guid.NewGuid().ToString();
                await _db.HangHoa.AddAsync(hangHoa);
                var rs = await _db.SaveChangesAsync();
                if (rs <= 0) return rp;
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Thêm hàng thành công";

                return rp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return rp;
            }
        }

        public async Task<IEnumerable<HangHoa>> GetAll(string qr)
        {
            var rs = await _db.HangHoa.Where(x => !string.IsNullOrEmpty(qr) || x.Ten.Contains(qr)).ToListAsync();
            return rs;
        }

        public async Task<HangHoa> Find(int id)
        {
            return await _db.HangHoa.FindAsync(id);
        }

        public async Task<Response> Update(int id, HangHoa hangHoa)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Cập nhật hàng thất bại" };
            try
            {
                var obj = await _db.HangHoa.FindAsync(id);
                if (obj == null) return rp;
                obj.Ten = hangHoa.Ten;
                obj.Gia = hangHoa.Gia;
                obj.GhiChu = hangHoa.GhiChu;
                await _db.SaveChangesAsync();
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Cập nhật hàng thành công";
                return rp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return rp;
            }
        }

        public async Task<Response> Remove(int id)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Xóa hàng thất bại" };
            var entry = await _db.HangHoa.FindAsync(id);
            _db.HangHoa.Remove(entry);
            var rs = await _db.SaveChangesAsync();
            if (rs <= 0) return rp;
            rp.ResultCode = ResultCode.Success;
            rp.Message = "Xóa hàng thành công";
            return rp;
        }
    }
}
