using Example.Command;
using Example.Model;
using Example.Receiver;

namespace Example.ConcreteCommand
{
    public class MoveCommand : ACommand
    {
        public MoveCommand(IReceiver receiver)
            : base(receiver)
        {

        }
        public override PointModel Execute()
        {
            return receiver.SetAction(ActionEnum.MOVE);
        }
    }
}