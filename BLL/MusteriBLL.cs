using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DAO;
using StokTakip.DAL.DTO;
using StokTakip.DAL;
using System.Security.Cryptography.X509Certificates;

namespace StokTakip.BLL
{
    public class MusteriBLL : IBLL<MusteriDetayDTO, MusteriDTO>
    {
        SatisDAO satisdao = new SatisDAO();
        MusteriDAO dao = new MusteriDAO();
        UrunDAO urundao = new UrunDAO();
        public bool Delete(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.ID = entity.ID;
            dao.Delete(musteri);
            SATIM satis = new SATIM();
            satis.MusteriID = entity.ID;
            satisdao.Delete(satis);
            return true;
        }

        public bool GetBack(MusteriDetayDTO entity)
        {
            return dao.GetBack(entity.ID);
        }

        public bool Insert(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.MusteriAd = entity.MusteriAd.Trim();
            musteri.isDeleted = false;
            return dao.Insert(musteri);
        }

        public MusteriDTO Select()
        {
            MusteriDTO dto = new MusteriDTO();
            dto.Musteriler = dao.Select();
            return dto;
        }

        public bool Update(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.ID = entity.ID;
            musteri.MusteriAd = entity.MusteriAd.Trim();
            return dao.Update(musteri);
        }
    }
}
