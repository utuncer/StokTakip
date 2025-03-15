using StokTakip.DAL;
using StokTakip.DAL.DAO;
using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BLL
{
    public class SatisBLL : IBLL<SatisDetayDTO, SatisDTO>
    {
        KategoriDAO kategoridao = new KategoriDAO();
        MusteriDAO musteridao = new MusteriDAO();
        UrunDAO urundao = new UrunDAO();
        SatisDAO dao = new SatisDAO();
        public bool Delete(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.ID = entity.SatisID;
            dao.Delete(satis);
            urundao.stokGuncelle(entity); //--------------------------------------
            return true;
        }

        public bool GetBack(int TableID, SatisDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.UrunID = entity.UrunID;
            satis.MusteriID = entity.MusteriID;
            satis.SatisMiktar = entity.SatisMiktar;
            satis.SatisTarihi = DateTime.Today;
            satis.SatisFiyat = entity.Fiyat;
            satis.KategoriID = entity.KategoriID;
            dao.Insert(satis);
            URUN urun = new URUN();
            urun.ID = entity.UrunID;
            int temp = entity.StokMiktar - entity.SatisMiktar;
            urun.Stok = temp;
            urundao.Update(urun);
            return true;
        }

        public SatisDTO Select()
        {
            SatisDTO dto = new SatisDTO();
            dto.Kategoriler = kategoridao.Select();
            dto.Musteriler = musteridao.Select();
            dto.Urunler = urundao.Select();
            dto.Satislar = dao.Select();
            return dto;
        }

        public bool Update(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.SatisMiktar = entity.SatisMiktar;
            satis.ID = entity.SatisID;
            dao.Update(satis);
            int temp = entity.StokMiktar;
            URUN urun = new URUN();
            urun.Stok = entity.StokMiktar - (entity.SatisMiktar - temp);
            urun.ID = entity.UrunID;
            urundao.Update(urun);

            return true;
        }
    }
}
