//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunStokTakip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar
    {
        public int Id { get; set; }
        public Nullable<int> UrunId { get; set; }
        public Nullable<int> Adet { get; set; }
        public Nullable<decimal> Fiyaf { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Resim { get; set; }
        public Nullable<int> KullaniciId { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
        public virtual Kullanici Kullanici1 { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
