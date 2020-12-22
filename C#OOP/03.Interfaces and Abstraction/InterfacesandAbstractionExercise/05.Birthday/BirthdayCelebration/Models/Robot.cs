using BirthdayCelebration.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration.Models
{
    public class Robot : IId
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
