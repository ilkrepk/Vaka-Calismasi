using Example.Model;

namespace Example.Receiver
{
    public interface IReceiver
    {
        void SetMoveResult();
        void SetLeftRotateResult();
        void SetRightRotateResult();
        PointModel SetAction(ActionEnum moveAction);
    }
}