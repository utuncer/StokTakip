using StokTakip.DAL;
using StokTakip.DAL.DAO;
using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.BLL
{
    public class UrunBLL : IBLL<UrunDetayDTO, UrunDTO>
    {
        KategoriDAO kategoridao = new KategoriDAO();
        UrunDAO dao = new UrunDAO();
        SatisDAO satisdao = new SatisDAO();
        public bool Delete(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            urun.ID = entity.ID;
            dao.Delete(urun);
            SATIM satis = new SATIM();
            satis.UrunID = entity.ID;
            satisdao.Delete(satis); 
            return true;
        }

        public bool GetBack(int TableID, UrunDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            urun.Fiyat = entity.Fiyat;
            urun.UrunAd = entity.UrunAd.ToString().Trim();
            urun.KategoriID = entity.KategoriID;
            urun.isDeleted = false;
            return dao.Insert(urun);
        }

        public UrunDTO Select()
        {
            UrunDTO dto = new UrunDTO();
            dto.Kategoriler = kategoridao.Select();
            dto.Urunler = dao.Select();
            return dto;
        }

        public bool Update(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            if (entity.isStokEkleme)
            {
                urun.ID = entity.ID;
                urun.Stok = entity.StokMiktar;
            }
            else
            {
                urun.ID = entity.ID;
                urun.Fiyat = entity.Fiyat;
                urun.KategoriID = entity.KategoriID;
                urun.UrunAd = entity.UrunAd.Trim();
            }
            return dao.Update(urun);
        }
    }
}
