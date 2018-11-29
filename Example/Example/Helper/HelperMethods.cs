using System;
using System.Collections.Generic;
using System.ComponentModel;
using Example.Receiver;

namespace Example.Helper
{
    public class HelperMethods
    {
        public StateEnum StateFactory(string key)
        {
            
            switch (key)
            {
                case "N":
                    return StateEnum.NORTH;
                case "S":
                    return StateEnum.SOUTH;
                case "E":
                    return StateEnum.EAST;
                case "W":
                    return StateEnum.WEST;
                default:
                    return StateEnum.NONE;
            }
        }

        public List<ActionEnum> getMoveEnumList(char[] secondInput)
        {
            var secondInputList = new List<ActionEnum>();

            foreach (var action in secondInput)
            {
                switch (action)
                {
                    case 'L':
                        secondInputList.Add(ActionEnum.LEFT);
                        break;
                    case 'R':
                        secondInputList.Add(ActionEnum.RIGHT);
                        break;
                    case 'M':
                        secondInputList.Add(ActionEnum.MOVE);
                        break;
                    default:
                        return null;
                }
            }

            return secondInputList;
        }

        public int isInt(string key)
        {
            int result;

            if (Int32.TryParse(key.ToString(), out result) && result>=0)
            {
                return result;
            }
            return -1;
        }
    }
}