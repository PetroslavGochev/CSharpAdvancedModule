using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string guest = string.Empty;
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while((guest = Console.ReadLine()) !=  "PARTY")
            {
                if(guest.Length == 8 && Char.IsDigit(guest[0]))
                {
                    vip.Add(guest);
                }
                else if (guest.Length == 8)
                {
                    regular.Add(guest);
                }
            }
            while((guest = Console.ReadLine()) != "END")
            {
                if (vip.Contains(guest))
                {
                    vip.Remove(guest);
                }
                else if (regular.Contains(guest))
                {
                    regular.Remove(guest);
                }      
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
