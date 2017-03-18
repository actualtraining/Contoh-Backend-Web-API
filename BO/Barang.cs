using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Barang
    {
        public string BarangID { get; set; }
        public int? KategoriID { get; set; }
        public string NamaBarang { get; set; }
        public int? Stok { get; set; }
        public decimal? HargaBeli { get; set; }
        public decimal? HargaJual { get; set; }
        public string PicUrl { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
