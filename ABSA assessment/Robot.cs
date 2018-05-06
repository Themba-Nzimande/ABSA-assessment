using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA_assessment
{
    public class Robot
    {



        public void GetMovements()
        {
            Console.WriteLine("Enter North movement");
            int NorthMovement = Convert.ToInt16(Console.ReadLine());
            int[] NorthMovements = MoveNorth(NorthMovement);

            Console.WriteLine("Enter South movement");
            int SouthMovement = Convert.ToInt16(Console.ReadLine());
            int[] SouthMovements = MoveSouth(SouthMovement, NorthMovements.Last().ToString());

            //East and West section
            Console.WriteLine("Enter East movement");
            int EastMovement = Convert.ToInt16(Console.ReadLine());
            int[] eastMovements = MoveEast(EastMovement, SouthMovements.Last());

            Console.WriteLine("Enter West movement");
            int WestMovement = Convert.ToInt16(Console.ReadLine());
            int[] westMovements = MoveWest(WestMovement, eastMovements.Last(), SouthMovements.Last());

            GetUniqueBlocks(NorthMovements, SouthMovements, eastMovements, westMovements);
            Console.ReadKey();
        }


        public int[] MoveNorth(int northInput)
        {
            int lastYPosition = 9;
            //North movement section
            int[] NorthArray = new int[northInput + 1];

            if (northInput == 0 || northInput == null)
            {
                NorthArray[0] = 99;
            }
            else
            {
                for (int NorthMoves = 0; NorthMoves < NorthArray.Length; NorthMoves++)
                {
                    string tempNorth = "9" + (lastYPosition - NorthMoves).ToString();
                    NorthArray[NorthMoves] = Convert.ToInt32(tempNorth);
                }

            }
            foreach (int norths in NorthArray)
            {
                //Console.WriteLine("North moves - " + norths.ToString());
            }
            return NorthArray;
        }

        public int[] MoveSouth(int southInput, string lastYPosition)
        {
            //South movement section
            int[] SouthArray = new int[southInput + 1];

            if (southInput == 0 || southInput == null)
            {
                SouthArray[0] = Convert.ToInt32(lastYPosition);
            }
            else
            {
                for (int SouthMoves = 0; SouthMoves < SouthArray.Length; SouthMoves++)
                {
                    string tempLastNorthPos = lastYPosition;
                    tempLastNorthPos = tempLastNorthPos.Remove(0, 1);
                    string tempSouth = "9" + (Convert.ToInt32(tempLastNorthPos) + SouthMoves).ToString();
                    SouthArray[SouthMoves] = Convert.ToInt32(tempSouth);
                }


            }

            foreach (int souths in SouthArray)
            {
                //Console.WriteLine("South moves - " + souths.ToString());
            }
            return SouthArray;
        }

        public int[] MoveEast(int eastInput, int lastYPosition)
        {
            //East movement section
            int[] EastArray = new int[eastInput + 1];

            if (eastInput == 0 || eastInput == null)
            {
                EastArray[0] = lastYPosition;
            }
            else
            {
                int lastXPosition = 9;
                for (int EastMoves = 0; EastMoves < EastArray.Length; EastMoves++)
                {
                    //Must get the x position of last movement here
                    string tempEast = (lastXPosition + EastMoves).ToString() + lastYPosition.ToString().Remove(0, 1);
                    EastArray[EastMoves] = Convert.ToInt32(tempEast);
                }
            }
            foreach (int easts in EastArray)
            {
                //Console.WriteLine("East moves - " + easts.ToString());
            }
            return EastArray;
        }

        public int[] MoveWest(int westInput, int lastXPosition, int lastYPosition)
        {
            //West movement section
            int[] WestArray = new int[westInput + 1];
            if (westInput == 0 || westInput == null)
            {
                WestArray[0] = lastXPosition;
            }
            else
            {
                for (int WestMoves = 0; WestMoves < WestArray.Length; WestMoves++)
                {
                    string tempLastEastPos = lastXPosition.ToString();
                    string tempWest = (Convert.ToInt32(tempLastEastPos.Remove(1, 1)) - WestMoves).ToString() + lastYPosition.ToString().Remove(0, 1);
                    WestArray[WestMoves] = Convert.ToInt32(tempWest);
                }
            }
            foreach (int wests in WestArray)
            {
                //Console.WriteLine("West moves - " + wests.ToString());
            }
            return WestArray;
        }

        public void GetUniqueBlocks(int[] northArray, int[] southArray, int[] eastArray, int[] westArray)
        {
            //Combining North and West into one array with all values
            int[] northAndSouthArray = new int[southArray.Length + northArray.Length];
            Array.Copy(northArray, northAndSouthArray, northArray.Length);
            Array.Copy(southArray, 0, northAndSouthArray, northArray.Length, southArray.Length);

            //Combining West and East into one array with all values
            int[] eastAndWestArray = new int[westArray.Length + eastArray.Length];
            Array.Copy(eastArray, eastAndWestArray, eastArray.Length);
            Array.Copy(westArray, 0, eastAndWestArray, eastArray.Length, westArray.Length);

            //Combining NorthandWest array and WestandEast array into one array with all values
            int[] combinedArray = new int[eastAndWestArray.Length + northAndSouthArray.Length];
            Array.Copy(eastAndWestArray, combinedArray, eastAndWestArray.Length);
            Array.Copy(northAndSouthArray, 0, combinedArray, eastAndWestArray.Length, northAndSouthArray.Length);

            //removing blocks already visited into unique blocks array
            int[] uniqueBlocks = combinedArray.Distinct().ToArray();

            //Output of unique blocks
            foreach (int ns in uniqueBlocks)
            {
                Console.WriteLine("Unique moves blocks visited- " + ns.ToString());
            }

            Console.WriteLine("Number of unique blocks visited- " + uniqueBlocks.Length.ToString());
        }

    }
}

