
using System;
using System.Collections.Generic;
using Example.Command;
using Example.ConcreteCommand;
using Example.Helper;
using Example.Model;
using Example.Receiver;

namespace Example
{
    public class Program
    {
        IReceiver calculator = null;
        ACommand command = null;
        LeftCommand leftCommand = null;
        RightCommand rightCommand = null;
        MoveCommand moveCommand = null;
        HelperMethods helperMethods = new HelperMethods();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.MainMethod();
        }
        public void MainMethod()
        {

            int x;
            int y;
            int lx;
            int ly;
            StateEnum state;
            List<PointModel> results = new List<PointModel>();
            PointModel V1result = new PointModel();
            PointModel V2result = new PointModel();
            do
            {
                Console.WriteLine("Please Enter Limits");
                var border = Console.ReadLine().Split(' ');
                lx = helperMethods.isInt(border[0]);
                ly = helperMethods.isInt(border[1]);

            } while (lx == -1 || ly == -1);

            //Voyager 1 Process
            for (int v = 0; v < 2; v++)
            {
                do
                {
                    Console.WriteLine("Please Enter Voyager_" + Convert.ToInt32(v+1) + " Start Location");
                    var firstInput = Console.ReadLine().Split(' ');
                    x = helperMethods.isInt(firstInput[0]);
                    y = helperMethods.isInt(firstInput[1]);
                    if (x > lx)
                    {
                        x = lx;
                    }
                    if (y > ly)
                    {
                        y = ly;
                    }
                    state = helperMethods.StateFactory(firstInput[2]);
                    if (results.Count>0)
                    {
                        foreach (var item in results)
                        {
                            if (x == item.x && y == item.y)
                            {
                                Console.WriteLine("The location of two voyagers can not be the same !");
                                x = -1;
                                y = -1;
                            }
                        }
                    }

                } while (x == -1 || y == -1 || state == StateEnum.NONE);


                calculator = new Calculator(x, y, lx, ly, state);
                leftCommand = new LeftCommand(calculator);
                rightCommand = new RightCommand(calculator);
                moveCommand = new MoveCommand(calculator);

                var secondInputList = new List<ActionEnum>();
                char[] secondInput;
                do
                {
                    Console.WriteLine("Please Enter Voyager_"+ Convert.ToInt32(v + 1) + " Commands");
                    secondInput = Console.ReadLine().ToCharArray();
                    secondInputList = helperMethods.getMoveEnumList(secondInput);
                } while (secondInputList == null);

                PointModel result = new PointModel();
                for (int i = 0; i < secondInputList.Count; i++)
                {
                    switch (secondInputList[i])
                    {
                        case ActionEnum.LEFT:
                            command = leftCommand;
                            result = command.Execute();
                            break;
                        case ActionEnum.RIGHT:
                            command = rightCommand;
                            result = command.Execute();
                            break;
                        case ActionEnum.MOVE:
                            command = moveCommand;
                            result = command.Execute();
                            if (results.Count>0)
                            {
                                foreach (var item in results)
                                {
                                    if (result.x==item.x && result.y==item.y)
                                    {
                                        switch (result.state)
                                        {
                                            case StateEnum.NORTH:
                                                result.y--;
                                                break;
                                            case StateEnum.SOUTH:
                                                result.y++;
                                                break;
                                            case StateEnum.EAST:
                                                result.x--;
                                                break;
                                            case StateEnum.WEST:
                                                result.x++;
                                                break;
                                            case StateEnum.NONE:
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                results.Add(result);
            }
            //Voyager 1 Process End.
            foreach (var item in results)
            {
                Console.WriteLine("x=" + item.x + " y=" + item.y + " state=" + item.state);
            }
            Console.Read();


        }
    }
}
