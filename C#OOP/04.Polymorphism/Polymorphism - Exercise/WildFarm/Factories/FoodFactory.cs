using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static Food CreateFood(string[] foodData)
        {
            Food food = null;
            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);
            if(type == "Vegetable")
            {
               return food = new Vegetable(quantity);
            }
            else if(type == "Fruit")
            {
                return food = new Fruit(quantity);
            }
            else if(type == "Meat")
            {
                return food = new Meat(quantity);
            }
            else if(type == "Seeds")
            {
                return food = new Seeds(quantity);
            }
            return food;
        }
    }
}
