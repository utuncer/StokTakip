﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StokTakip.DAL.DTO
{
    public class UrunDTO
    {
        public List<UrunDetayDTO> Urunler { get; set; }
        public List<KategoriDetayDTO> Kategoriler { get; set; }
    }
}
