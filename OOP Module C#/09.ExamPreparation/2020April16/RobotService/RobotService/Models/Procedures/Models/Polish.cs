using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Models
{
    public class Polish : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness -= 7;
            base.DoService(robot, procedureTime);
        }
    }
}
