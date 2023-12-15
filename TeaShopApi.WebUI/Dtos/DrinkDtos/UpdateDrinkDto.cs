namespace TeaShopApi.WebUI.Dtos.DrinkDtos
{
    public class UpdateDrinkDto
    {
        public int drinkID { get; set; }

        public string drinkName { get; set; }

        public float drinkPrice { get; set; }

        public string drinkImage { get; set; }
    }
}
