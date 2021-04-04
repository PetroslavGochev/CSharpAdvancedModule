﻿using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Models
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Energy -= 8;
            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }
            else
            {
                robot.IsChecked = true;
            }
            base.DoService(robot, procedureTime);
        }
    }
}
