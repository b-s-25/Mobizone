using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Specification
    {
        public int id { get; set; }


        [ForeignKey("productStorageId")]
        public int productStorageId { get; set; }
        public ProductStorage productStorage { get; set; }


        [ForeignKey("productBrandId")]
        public int productBrandId { get; set; }
        public ProductBrand productBrand { get; set; }


        [ForeignKey("productSimId")]
        public int productSimId { get; set; }
        public ProductSim productSim { get; set; }


        [ForeignKey("productColorId")]
        public int productColorId { get; set; }
        public ProductColor productColor { get; set; }


        [ForeignKey("productModelId")]
        public int productModelId { get; set; }
        public ProductModel productModel { get; set; }


        [ForeignKey("productRamId")]
        public int productRamId { get; set; }
        public ProductRam productRam { get; set; }


        [ForeignKey("productImageId")]
        public int productImageId { get; set; }
        public ProductImage productImage { get; set; }


        public DateTime modified_on { get; set; }
        public DateTime created_on { get; set; }
        public string modified_by { get; set; }
        public string created_by { get; set; }


        public ICollection<ProductStorage> productStorages { get; set; }
        public ICollection<ProductBrand> productBrands { get; set; }
        public ICollection<ProductSim> productSims { get; set; }
        public ICollection<ProductColor> productColors { get; set; }
        public ICollection<ProductModel> productModels { get; set; }
        public ICollection<ProductRam> productRams { get; set; }
        public ICollection<ProductImage> productImages { get; set; }
    }
}
