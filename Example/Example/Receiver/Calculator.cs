using System;
using Example.Model;

namespace Example.Receiver
{
    public class Calculator :IReceiver
    {
        public int x { get; set; }
        public int y { get; set; }

        public int lx { get; set; }
        public int ly { get; set; }

        public ActionEnum currentMoveAction { get; set; }
        public StateEnum currentRotateAction { get; set; }

        public Calculator(int x, int y, int lx, int ly, StateEnum RotateAction)
        {
            this.x = x;
            this.y = y;
            this.lx = lx;
            this.ly = ly;
            this.currentRotateAction = RotateAction;
        }

        #region IReceiver Members
        
        public void SetMoveResult()
        {
            switch (currentRotateAction)
            {
                case StateEnum.EAST:
                    if (x >= lx)
                    {
                        x = lx;
                        break;
                    }
                    x++;
                    break;
                case StateEnum.NORTH:
                    if (y >= ly)
                    {
                        y = ly;
                        break;
                    }
                    y++;
                    break;
                case StateEnum.WEST:
                    if (x <= 0)
                    {
                        break;
                    }
                    x--;
                    break;
                case StateEnum.SOUTH:
                    if (y - 1 < 0)
                    {
                        break;
                    }
                    y--;
                    break;
            }
        }

        public void SetLeftRotateResult()
        {
            switch (currentRotateAction)
            {
                case StateEnum.EAST:
                    currentRotateAction = StateEnum.NORTH;
                    break;
                case StateEnum.NORTH:
                    currentRotateAction = StateEnum.WEST;
                    break;
                case StateEnum.WEST:
                    currentRotateAction = StateEnum.SOUTH;
                    break;
                case StateEnum.SOUTH:
                    currentRotateAction = StateEnum.EAST;
                    break;
            }
        }
        public void SetRightRotateResult()
        {
            switch (currentRotateAction)
            {
                case StateEnum.EAST:
                    currentRotateAction = StateEnum.SOUTH;
                    break;
                case StateEnum.NORTH:
                    currentRotateAction = StateEnum.EAST;
                    break;
                case StateEnum.WEST:
                    currentRotateAction = StateEnum.NORTH;
                    break;
                case StateEnum.SOUTH:
                    currentRotateAction = StateEnum.WEST;
                    break;
            }
        }
        public PointModel SetAction(ActionEnum moveAction)
        {
            currentMoveAction = moveAction;
            switch (currentMoveAction)
            {
                case ActionEnum.LEFT:
                    SetLeftRotateResult();
                    break;
                case ActionEnum.MOVE:
                    SetMoveResult();
                    break;
                case ActionEnum.RIGHT:
                    SetRightRotateResult();
                    break;
            }
            PointModel pointModel = new PointModel(x,y, currentRotateAction);
            return pointModel;
        }
    }

    #endregion
}