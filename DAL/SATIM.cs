//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakip.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SATIM
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public int MusteriID { get; set; }
        public int KategoriID { get; set; }
        public int SatisMiktar { get; set; }
        public int SatisFiyat { get; set; }
        public System.DateTime SatisTarihi { get; set; }
        public bool isDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDay { get; set; }
    }
}
