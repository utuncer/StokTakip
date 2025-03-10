using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DTO;
using StokTakip.DAL;
using StokTakip.DAL.DAO;

namespace StokTakip.BLL
{
    public class KategoriBLL : IBLL<KategoriDetayDTO, KategoriDTO>
    {
        KategoriDAO dao = new KategoriDAO();
        public bool Delete(KategoriDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int TableID, KategoriDetayDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(KategoriDetayDTO entity)
        {
            KATEGORI kategori = new KATEGORI();
            kategori.KategoriAd = entity.KategoriAd;
            kategori.isDeleted = false;
            return dao.Insert(kategori);
        }

        public KategoriDTO Select()
        {
            KategoriDTO dto = new KategoriDTO();
            dto.Kategoriler = dao.Select();
            return dto;
        }

        public bool Update(KategoriDetayDTO entity)
        {
            KATEGORI kt= new KATEGORI();
            kt.ID=entity.ID;
            kt.KategoriAd=entity.KategoriAd;
            return dao.Update(kt);
        }
    }
}
