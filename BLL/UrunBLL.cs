using StokTakip.DAL;
using StokTakip.DAL.DAO;
using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BLL
{
    public class UrunBLL : IBLL<UrunDetayDTO, UrunDTO>
    {
        KategoriDAO kategoridao = new KategoriDAO();
        UrunDAO dao = new UrunDAO();
        public bool Delete(UrunDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int TableID, UrunDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            urun.Fiyat = entity.Fiyat;
            urun.UrunAd = entity.UrunAd;
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
            throw new NotImplementedException();
        }
    }
}
