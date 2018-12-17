using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Repository
{
    public class VanChuyenRepository:IVanChuyenRepository
    {
        private readonly VMTContext _db;

        public VanChuyenRepository(VMTContext context)
        {
            _db = context;
        }
        public async Task<Response> Add(VanChuyen vanChuyen)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Thêm chuyến không thành công" };
            try
            {
                vanChuyen.Ref = Guid.NewGuid().ToString();
                await _db.VanChuyen.AddAsync(vanChuyen);
                var rs = await _db.SaveChangesAsync();
                if (rs <= 0) return rp;
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Thêm chuyến thành công";

                return rp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return rp;
            }
        }

        public async Task<IEnumerable<VanChuyen>> GetAll(string qr)
        {
            var rs = await _db.VanChuyen.Where(x => !string.IsNullOrEmpty(qr) || x.BienSoXe.Contains(qr)).ToListAsync();
            return rs;
        }

        public async Task<VanChuyen> Find(int id)
        {
            return await _db.VanChuyen.FindAsync(id);
        }

        public async Task<Response> Update(int id, VanChuyen vanChuyen)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Cập nhật chuyến thất bại" };
            try
            {
                var obj = await _db.VanChuyen.FindAsync(id);
                if (obj == null) return rp;
                obj.XeId = vanChuyen.XeId;
                obj.BienSoXe = vanChuyen.BienSoXe;
                obj.HangHoaId = vanChuyen.HangHoaId;
                obj.SoChuyen = vanChuyen.SoChuyen;
                obj.NgayVanChuyen = vanChuyen.NgayVanChuyen;
                obj.GhiChu = vanChuyen.GhiChu;
                await _db.SaveChangesAsync();
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Cập nhật chuyến thành công";
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
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Xóa chuyến thất bại" };
            var entry = await _db.HangHoa.FindAsync(id);
            _db.HangHoa.Remove(entry);
            var rs = await _db.SaveChangesAsync();
            if (rs <= 0) return rp;
            rp.ResultCode = ResultCode.Success;
            rp.Message = "Xóa chuyến thành công";
            return rp;
        }
    }
}
