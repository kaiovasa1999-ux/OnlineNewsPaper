using System.ComponentModel.DataAnnotations;

namespace OnlineNewsPaper.Models.Home
{
    public class IndexViewModel
    {

        [Display(Name = "Articles")]
        public int NewsAdCount { get; set; }


        [Display(Name = "Total Categories")]
        public int CategoriesCount { get; set; }

        [Display(Name = "Total Views")]
        public int TotalViews { get; set; }

        [Display(Name = "Total Coments")]
        public int TotalComents { get; set; }

    }
}
