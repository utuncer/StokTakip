using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DTO;

namespace StokTakip.DAL.DAO
{
    public class KategoriDAO : StokContext, IDAO<KATEGORI, KategoriDetayDTO>
    {
        public bool Delete(KATEGORI entity)
        {
            KATEGORI kk = db.KATEGORI.First(x => x.ID == entity.ID);
            kk.isDeleted = true;
            kk.DeletedDay = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public bool GetBack(int ID)
        {
            KATEGORI kk = db.KATEGORI.First(x => x.ID == ID);
            kk.isDeleted = false;
            db.SaveChanges();
            return true;
        }

        public bool Insert(KATEGORI entity)
        {

            try
            {
                db.KATEGORI.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KategoriDetayDTO> Select()
        {
            try
            {
                var list = db.KATEGORI.Where(x => x.isDeleted == false);
                List<KategoriDetayDTO> liste = new List<KategoriDetayDTO>();
                foreach (var item in list)
                {
                    KategoriDetayDTO dto = new KategoriDetayDTO();
                    dto.ID = item.ID;
                    dto.KategoriAd = item.KategoriAd.Trim();
                    liste.Add(dto);
                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<KategoriDetayDTO> Select(bool delete)
        {
            try
            {
                var list = db.KATEGORI.Where(x => x.isDeleted == delete);
                List<KategoriDetayDTO> liste = new List<KategoriDetayDTO>();
                foreach (var item in list)
                {
                    KategoriDetayDTO dto = new KategoriDetayDTO();
                    dto.ID = item.ID;
                    dto.KategoriAd = item.KategoriAd.Trim();
                    liste.Add(dto);
                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(KATEGORI entity)
        {
            try
            {
                KATEGORI kt = db.KATEGORI.First(x => x.ID == entity.ID);
                kt.KategoriAd = entity.KategoriAd.Trim();
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
