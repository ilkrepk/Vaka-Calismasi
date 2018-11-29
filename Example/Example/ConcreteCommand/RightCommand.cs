using Example.Command;
using Example.Model;
using Example.Receiver;

namespace Example.ConcreteCommand
{
    public class RightCommand : ACommand
    {
        public RightCommand(IReceiver receiver): base(receiver)
        {

        }
        public override PointModel Execute()
        {
            return receiver.SetAction(ActionEnum.RIGHT);
        }
    }
}