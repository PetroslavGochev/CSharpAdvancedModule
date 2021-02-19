using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooking
{
    public class StartUp
    {
        private static IDictionary<int, string> products = new Dictionary<int, string>()
            {
                {25,"Bread"},
                {50,"Cake"},
                {75,"Pastry"},
                {100,"Fruit Pie"}
            };
        private static IDictionary<string, int> cookingProduct = new Dictionary<string, int>()
            {
                {"Bread",0},
                {"Cake",0},
                {"Fruit Pie",0},
                {"Pastry",0}
            };
        private static Stack<int> ingredient = new Stack<int>();
        private static Queue<int> liquid = new Queue<int>();
        private static int[] liquids;
        private static int[] ingredients;
        static void Main(string[] args)
        {
            liquids = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            ingredients = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var l in liquids)
            {
                liquid.Enqueue(l);

            }
            foreach (var i in ingredients)
            {
                ingredient.Push(i);
            }
            while (ingredient.Count != 0 && liquid.Count != 0)
            {
                int sum = ingredient.Peek() + liquid.Peek();
                if (products.ContainsKey(sum))
                {
                    cookingProduct[products[sum]]++;
                    ingredient.Pop();
                    liquid.Dequeue();
                }
                else
                {
                    liquid.Dequeue();
                    int valueIngrediant = ingredient.Pop() + 3;
                    ingredient.Push(valueIngrediant);
                }
            }
            Console.WriteLine(ProductResult());
            Console.WriteLine(PrintLiquids());
            Console.WriteLine(PrintIgredient());
            Console.WriteLine(PrintCookingProduct());
        }
        private static string PrintCookingProduct()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in cookingProduct.OrderBy(x => x.Key))
            {
                sb.AppendLine($"{item.Key}: {item.Value}");
            }
            return sb.ToString().TrimEnd();
        }

        private static string PrintIgredient()
        {
            StringBuilder sb = new StringBuilder();
            if (ingredient.Count == 0)
            {
                sb.AppendLine("Ingredients left: none");
            }
            else
            {
                sb.Append("Ingredients left: ");

                while (ingredient.Count != 0)
                {
                    if (ingredient.Count == 1)
                    {
                        sb.AppendLine($"{ingredient.Pop()}");
                        break;
                    }
                    sb.Append($"{ingredient.Pop()}, ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static string PrintLiquids()
        {
            StringBuilder sb = new StringBuilder();
            if (liquid.Count == 0)
            {
                sb.AppendLine("Liquids left: none");
            }
            else
            {
                sb.Append("Liquids left: ");
                while (liquid.Count != 0)
                {
                    if (liquid.Count == 1)
                    {
                        sb.AppendLine($"{liquid.Dequeue()}");
                        break;
                    }
                    sb.Append($"{liquid.Dequeue()}, ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static string ProductResult()
        {
            foreach (var b in cookingProduct)
            {
                if (b.Value == 0)
                {
                    return "Ugh, what a pity! You didn't have enough materials to cook everything.";
                }
            }
            return "Wohoo! You succeeded in cooking all the food!";
        }
    }
}
