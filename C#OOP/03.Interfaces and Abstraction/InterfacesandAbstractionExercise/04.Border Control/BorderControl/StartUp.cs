using BorderControl.Contract;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IId> idList = new List<IId>();
            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split();
                var nameOrModel = data[0];
                if(data.Length == 3)
                {
                    var age = int.Parse(data[1]);
                    var id = data[2];
                    IId citizen = new Citizen(nameOrModel,age,id);
                    idList.Add(citizen);
                }
                else
                {
                    var id = data[1];
                    IId robot = new Robot(nameOrModel, id);
                    idList.Add(robot);
                }
            }
            string lastId = Console.ReadLine();
            idList = idList.Where(x => x.Id.EndsWith(lastId)).ToList();
            idList.ForEach(Console.WriteLine);
        }
    }
}
