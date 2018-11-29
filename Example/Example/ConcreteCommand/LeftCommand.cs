using Example.Command;
using Example.Model;
using Example.Receiver;

namespace Example.ConcreteCommand
{
    public class LeftCommand : ACommand
    {
        public LeftCommand(IReceiver receiver)
            : base(receiver)
        {

        }
        public override PointModel Execute()
        {
            return receiver.SetAction(ActionEnum.LEFT);
        }
    }
}