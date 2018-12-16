using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VMT.Models;
using VMT.Models.Response;

namespace VMT.Respository
{
    public class XeRespository : IXeRespository
    {
        private readonly VMTContext _db;

        public XeRespository()
        {
            _db = new VMTContext();
        }

        public async Task<Response> Add(Xe xe)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Thêm xe không thành công" };
            try
            {
                xe.Ref = Guid.NewGuid().ToString();
                await _db.Xe.AddAsync(xe);
                var rs = await _db.SaveChangesAsync();
                if (rs <= 0) return rp;
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Thêm xe thành công";

                return rp;
            }
            catch (Exception e)
            {
                if (e.InnerException is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2601 || sqlEx.Number == 2627)
                    {
                        rp.Message = $"Xe có biển số {xe.BienSoXe} đã tồn tại";
                    }
                }
//                Console.WriteLine(e.ToString());
                return rp;
            }
        }

        public async Task<IEnumerable<Xe>> GetAll()
        {
            var rs = await _db.Xe.ToListAsync();
            return rs;
        }

        public async Task<Xe> Find(int id)
        {
            return await _db.Xe.FindAsync(id);
        }

        public async Task<Response> Update(int id, Xe xe)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Cập nhật xe thất bại" };
            try
            {
                var obj = await _db.Xe.FindAsync(id);
                if (obj == null) return rp;
                obj.BienSoXe = xe.BienSoXe;
                obj.HangXe = xe.HangXe;
                obj.GhiChu = xe.GhiChu;
                obj.TheTich = xe.TheTich;
                obj.TheTichThuc = xe.TheTichThuc;
                await _db.SaveChangesAsync();
                rp.ResultCode = ResultCode.Success;
                rp.Message = "Cập nhật xe thành công";
                return rp;
            }
            catch (Exception e)
            {
                if (e is DbUpdateConcurrencyException concurrencyEx)
                {
                    // A custom exception of yours for concurrency issues
//                    Console.WriteLine(concurrencyEx.StackTrace);
                    return rp;
                }

                if (e is DbUpdateException dbUpdateEx)
                {
                    if (dbUpdateEx.InnerException != null && dbUpdateEx.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627: // Unique constraint error
                            case 547: // Constraint check violation
                            case 2601: // Duplicated key row error
                                // Constraint violation exception
                                // A custom exception of yours for concurrency issues
                                rp.Message = $"Xe có biển số {xe.BienSoXe} đã tồn tại";
                                return rp;
                            default:
                                // A custom exception of yours for other DB issues
                                rp.Message = "Hệ thống xảy ra lỗi";
                                return rp;
                        }
                    }
                }
//                Console.WriteLine(e);
                return rp;
            }
        }

        public async Task<Response> Remove(int id)
        {
            var rp = new Response { ResultCode = ResultCode.Error, Message = "Xóa xe thất bại" };
            var entry = await _db.Xe.FindAsync(id);
            _db.Xe.Remove(entry);
            var rs = await _db.SaveChangesAsync();
            if (rs <= 0) return rp;
            rp.ResultCode = ResultCode.Success;
            rp.Message = "Xóa xe thành công";
            return rp;
        }
    }
}
