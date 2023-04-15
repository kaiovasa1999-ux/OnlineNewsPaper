﻿using OnlineNewsPaper.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace OnlineNewsPaper.Models.News
{
    public class CreateNewsAdInputModel
    {
        [Required]
        public string Title { get; set; }

        public int NewsCategoryId { get; set; }

        [Display(Name ="Article Category")]
        [Required]
        public ICollection<NewsCategory> NewsCategories { get; set; }

        [Display(Name = "Content")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name ="Subcategory")]
        public ICollection<SpecificCategoryiesAJAXModel> SpecificCategories { get; set; }

        public int SpecificCategoryId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
