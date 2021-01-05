using WildFarm.Models.Animal;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalData)
        {
            Animal animal = null;
            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            if (type == "Owl" || type == "Hen")
            {
                double wingSize = double.Parse(animalData[3]);
                if (type == "Hen")
                {
                    return animal = new Hen(name, weight, wingSize);
                }
                return animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = animalData[3];
                if (type == "Dog")
                {
                    return animal = new Dog(name, weight, livingRegion);
                }
                return animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                if(type == "Cat")
                {
                    return animal = new Cat(name, weight, livingRegion, breed);
                }
                return animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }
    }
}
