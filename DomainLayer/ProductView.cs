﻿using DomainLayer.ImageAttribute;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ProductView
    {
        public int id { get; set; }/*
        [Display(Name = "Type")]
        [Required(ErrorMessage = "*This field is Required")]
        public string productType { get; set; }*/
        [Display(Name = "Name ")]
        [Required(ErrorMessage = "*This field is Required")]
        public string productName { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "*This field is Required")]
        public string productModel { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "*This field is Required")]
        public int productPrice { get; set; }
        [Display(Name ="Image")]
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile image { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "*This field is Required")]
        public string description { get; set; }
    }
}
