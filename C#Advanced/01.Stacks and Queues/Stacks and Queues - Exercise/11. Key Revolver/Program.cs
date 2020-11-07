using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            int[] bullet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] numberOfLocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int totalMoney = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(bullet);
            Queue<int> locks = new Queue<int>(numberOfLocks);
            int barel = sizeBarrel;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                
                if(locks.Peek() >= bullets.Pop())
                {
                    locks.Dequeue();
                    totalMoney -= priceForBullet;
                    barel--;
                    Console.WriteLine("Bang!");
                }
                else
                {
                    barel--;
                    totalMoney -= priceForBullet;
                    Console.WriteLine("Ping!");
                }
                if(bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
                else if(bullets.Count== 0 && locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${totalMoney}");
                    return;
                }
                if(barel == 0)
                {
                    barel = sizeBarrel;
                    Console.WriteLine("Reloading!");
                }
            }
            if(locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${totalMoney}");
            }
        }
    }
}
