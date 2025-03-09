using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.DAL.DTO
{
    public class SatisDTO //Tüm tablolara bağlı olduğu için tüm listeleri almalıyız
    {
        public List<SatisDetayDTO> Satislar { get; set; }
        public List<KategoriDetayDTO> Kategoriler { get; set; }
        public List<UrunDetayDTO> Urunler { get; set; }
        public List<MusteriDetayDTO> Musteriler { get; set; }
    }
}
