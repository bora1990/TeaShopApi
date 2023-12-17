using System.ComponentModel.DataAnnotations;

namespace TeaShopApi.WebUI.Dtos.AboutDtos
{
    public class ResultAboutDto
    {
        public int AboutID { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage ="En az 80 karakter girmelisin. ")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
