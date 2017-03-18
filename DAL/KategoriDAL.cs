using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using BO;

namespace DAL
{
    public class KategoriDAL : IDisposable
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SampleDbConnection"].ConnectionString;
        }

        public async Task<IEnumerable<Kategori>> GetAllKategori()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Kategori order by KategoriNama asc";
                return await conn.QueryAsync<Kategori>(strSql);
            }
        }

        public async Task<Kategori> GetKategoriByID(int kategoriID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Kategori where KategoriID=@KategoriID";
                var param = new { KategoriID = kategoriID };
                var result = await conn.QuerySingleAsync<Kategori>(strSql, param);
                return result;
            }
        }

        public async void TambahKategori(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into Kategori(KategoriID,KategoriNama) values(@KategoriID,@KategoriNama)";
                var param = new { KategoriID = kategori.KategoriID, KategoriNama = kategori.KategoriNama };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : "+sqlEx.Message);
                }
            }
        }

        public async void UpdateKategori(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"update Kategori set KategoriNama=@KategoriNama where KategoriID=@KategoriID";
                var param = new { KategoriNama = kategori.KategoriNama, KategoriID = kategori.KategoriID };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : " + sqlEx.Message);
                }
            }
        }

        public async void DeleteKategori(int kategoriID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"delete Kategori where KategoriID=@KategoriID";
                var param = new { KategoriID = kategoriID };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : " + sqlEx.Message);
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
