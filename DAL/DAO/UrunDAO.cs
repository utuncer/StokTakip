using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.DAL.DAO
{
    public class UrunDAO : StokContext, IDAO<URUN, UrunDetayDTO>
    {
        public bool Delete(URUN entity)
        {
            if (entity.ID != 0)
            {
                URUN urun = db.URUN.First(x => x.ID == entity.ID);
                urun.isDeleted = true;
                urun.DeletedDay = DateTime.Now;
                db.SaveChanges();
            }
            else if (entity.KategoriID != 0)
            {
                List<URUN> list = db.URUN.Where(x => x.KategoriID == entity.KategoriID).ToList();
                foreach (var item in list)
                {
                    item.isDeleted = true;
                    item.DeletedDay = DateTime.Now;
                    List<SATIM> satis = db.SATIM.Where(x => x.UrunID == item.ID).ToList();
                    foreach (var item2 in satis)
                    {
                        item2.isDeleted = true;
                        item2.DeletedDay = DateTime.Now;
                    }
                    db.SaveChanges();
                }
                db.SaveChanges();
            }
            return true;
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(URUN entity)
        {
            try
            {
                db.URUN.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UrunDetayDTO> Select()
        {
            List<UrunDetayDTO> liste = new List<UrunDetayDTO>();
            //Tablo birleştirme
            var list = (from u in db.URUN.Where(x => x.isDeleted == false)
                        join
                        k in db.KATEGORI on u.KategoriID equals k.ID
                        select new
                        {
                            urunad = u.UrunAd,
                            stok = u.Stok,
                            fiyat = u.Fiyat,
                            urunID = u.ID,
                            kategoriad = k.KategoriAd,
                            kID = k.ID
                        }).OrderBy(x => x.urunad).ToList();
            foreach (var item in list)
            {
                UrunDetayDTO dto = new UrunDetayDTO();
                dto.Fiyat = item.fiyat;
                dto.ID = item.urunID;
                dto.KategoriAd = item.kategoriad.Trim();
                dto.KategoriID = item.kID;
                dto.StokMiktar = item.stok;
                dto.UrunAd = item.urunad.Trim();
                liste.Add(dto);
            }
            return liste;
        }

        public bool Update(URUN entity)
        {
            try
            {
                URUN urun = db.URUN.First(x => x.ID == entity.ID);
                if (entity.Fiyat == 0)
                {
                    urun.Stok = entity.Stok;
                }
                else
                {
                    urun.KategoriID = entity.KategoriID;
                    urun.UrunAd = entity.UrunAd.Trim();
                    urun.Fiyat = entity.Fiyat;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void stokGuncelle(SatisDetayDTO entity)
        {
            URUN urun = db.URUN.First(x => x.ID == entity.UrunID);
            int temp = urun.Stok + entity.SatisMiktar;
            urun.Stok = temp;
            db.SaveChanges();
        }
    }
}
