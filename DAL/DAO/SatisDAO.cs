using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.DAL.DAO
{
    public class SatisDAO : StokContext, IDAO<SATIM, SatisDetayDTO>
    {
        public bool Delete(SATIM entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SATIM entity)
        {
            try
            {
                db.SATIM.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SatisDetayDTO> Select()
        {
            try
            {
                List<SatisDetayDTO> liste = new List<SatisDetayDTO>();
                var list = (from s in db.SATIM
                            join u in db.URUN on s.UrunID equals u.ID
                            join k in db.KATEGORI on s.KategoriID equals k.ID
                            join m in db.MUSTERI on s.MusteriID equals m.ID
                            select new
                            {
                                musteriad = m.MusteriAd,
                                urunad = u.UrunAd,
                                kategoriad = k.KategoriAd,
                                fiyat = s.SatisFiyat,
                                satistarihi=s.SatisTarihi,
                                satismiktari=s.SatisMiktar,
                                stok = u.Stok,
                                satisID = s.ID,
                                urunID = s.UrunID,
                                musteriID = s.MusteriID,
                                kategoriID = s.KategoriID
                            }).OrderBy(x => x.satistarihi);

                foreach (var item in list)
                {
                    SatisDetayDTO dto = new SatisDetayDTO();
                    dto.MusteriAd = item.musteriad;
                    dto.UrunAd = item.urunad;
                    dto.KategoriAd = item.kategoriad;
                    dto.Fiyat = item.fiyat;
                    dto.SatisTarihi = item.satistarihi;
                    dto.SatisMiktar = item.satismiktari;
                    dto.SatisID = item.satisID;
                    dto.UrunID = item.urunID;
                    dto.MusteriID = item.musteriID;
                    dto.KategoriID = item.kategoriID;
                    liste.Add(dto);
                }

                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(SATIM entity)
        {
            SATIM ss = db.SATIM.First(x => x.ID == entity.ID);
            ss.SatisMiktar = entity.SatisMiktar;
            db.SaveChanges();
            return true;
        }
    }
}
