//using AbsenseApi.DBContext;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using AbsenseApi.DBContext;
//using NPOI.SS.Formula.Functions;
//using System.Data.SqlClient;

//namespace AbsenseApi.Services
//{
//    public class DBService<T> where T : class
//    {
//        public async Task<IEnumerable<T>> GetObjectsAsync()
//        {
//            using (var context = new StudentContext())
//            {
//                return await context.Set<T>().AsNoTracking().ToListAsync();
//            }
//        }

//        public async Task<T> GetObjectByNFCIdAsync(long nFCId)
//        {
//            using (var context = new StudentContext())
//            {
//                return await context.Set<T>().FindAsync(nFCId);
//            }
//        }

//        public async Task AddObjectAsync(T obj)
//        {
//            using (var context = new StudentContext())
//            {
//                context.Set<T>().Remove(obj);
//                await context.SaveChangesAsync();
//            }
//        }
//    }
//}
