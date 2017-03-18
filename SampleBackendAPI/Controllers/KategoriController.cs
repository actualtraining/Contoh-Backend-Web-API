using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using BL;
using System.Threading.Tasks;

namespace SampleBackendAPI.Controllers
{
    public class KategoriController : ApiController
    {
        // GET: api/Kategori
        public async Task<IEnumerable<Kategori>> Get()
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetAllKategori();
        }

        // GET: api/Kategori/5
        public async Task<Kategori> Get(int id)
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetKategoriByID(id);
        }

        // POST: api/Kategori
        public async Task<IHttpActionResult> Post(Kategori kategori)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.TambahKategori(kategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error : " + ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public async Task<IHttpActionResult> Put(Kategori kategori)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.UpdateKategori(kategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error : " + ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            KategoriBL kategoriBL = new KategoriBL();
            try
            {
                await kategoriBL.DeleteKategori(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error : " + ex.Message);
            }
        }
    }
}
