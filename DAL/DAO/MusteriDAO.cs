using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DAO;
using System.Runtime.InteropServices;

namespace StokTakip.DAL.DAO
{
    public class MusteriDAO : StokContext, IDAO<MUSTERI, MusteriDetayDTO>

    {
        public bool Delete(MUSTERI entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MUSTERI entity)
        {
            try
            {
                db.MUSTERI.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MusteriDetayDTO> Select()
        {
            try
            {
                List<MusteriDetayDTO> liste = new List<MusteriDetayDTO>();
                var list = db.MUSTERI;
                foreach (var item in list)
                {
                    MusteriDetayDTO dto = new MusteriDetayDTO();
                    dto.ID = item.ID;
                    dto.MusteriAd = item.MusteriAd.Trim();
                    liste.Add(dto);
                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(MUSTERI entity)
        {
            MUSTERI mm = db.MUSTERI.First(x => x.ID == entity.ID);
            mm.MusteriAd = entity.MusteriAd.Trim();
            db.SaveChanges();
            return true;    
        }
    }
}
