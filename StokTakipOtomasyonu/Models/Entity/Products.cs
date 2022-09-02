//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipOtomasyonu.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.Basket = new HashSet<Basket>();
            this.Sales = new HashSet<Sales>();
            this.BrandList = new List<SelectListItem>();
            BrandList.Insert(0, new SelectListItem { Text = "Select the Category for Brands", Value = "" });
        }
    
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public string ProductName { get; set; }
        public string BarcodNo { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Tax { get; set; }
        public int UnitID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }
        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Units Units { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }

        public List<SelectListItem> CategoryList  { get; set; }


        public List<SelectListItem> UnitList    { get; set; }
        public List<SelectListItem> BrandList { get; set; }
    }
}
