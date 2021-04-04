using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Models
{
    public class Work : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {

            base.DoService(robot, procedureTime);
            robot.Energy -= 6;
            robot.Happiness += 12;
        }
    }
}
