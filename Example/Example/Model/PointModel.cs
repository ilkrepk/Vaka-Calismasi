using Example.Receiver;

namespace Example.Model
{
    public class PointModel
    {
        public int x { get; set; }
        public int y { get; set; }
        public StateEnum state { get; set; }

        public PointModel(int x, int y, StateEnum state)
        {
            this.x = x;
            this.y = y;
            this.state = state;
        }

        public PointModel()
        {
            
        }
    }
}