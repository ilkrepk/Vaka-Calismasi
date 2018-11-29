using Example.Model;
using Example.Receiver;

namespace Example.Command
{
    public abstract class ACommand
    {
        protected IReceiver receiver = null;

        public ACommand(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract PointModel Execute();
    }
}