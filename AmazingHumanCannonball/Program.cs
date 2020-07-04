using System;

namespace AmazingHumanCannonball
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Amazing Human Cannonball
            // https://open.kattis.com/problems/humancannonball2 
            // simple numerical program

            int generalCounter = EnterTestNo();
            string[] ans = new string[generalCounter];


            double[] myInfo = new double[5];
            double myHoleTime;
            double myYAxis;

            for (int k = 0; k < generalCounter; k++)
            {

                myInfo = EnterInfo();

                myHoleTime = GetHoleTime(myInfo);

                myYAxis = GetYAxis(myInfo, myHoleTime);

                if (SafeHuman(myInfo, myYAxis) == true)
                    ans[k] = "Safe";
                else
                    ans[k] = "Not Safe";
            }

            PrintArray(ans);
        }


        private static bool SafeHuman(double[] nums, double YAxis)
        {
            double myH1 = nums[3];
            double myH2 = nums[4];

            if (YAxis > myH1 + 1 && YAxis < myH2 - 1)
                return true;
            else
                return false;
        }
        private static double GetYAxis(double[] nums, double myTime)
        {
            double myV = nums[0];
            double tetaD = nums[1];
            double myX = nums[2];
            double myH1 = nums[3];
            double myH2 = nums[4];

            double tetaR = tetaD * Math.PI / 180;
            double gravity = 9.81;

            double first = myV * myTime * Math.Sin(tetaR);
            double second = gravity * myTime * myTime / 2;
            return first - second;
        }

        private static double GetHoleTime(double[] nums)
        {
            double myV = nums[0];
            double tetaD = nums[1];
            double myX = nums[2];
            double myH1 = nums[3];
            double myH2 = nums[4];

            double tetaR = tetaD * Math.PI / 180;
            double myTime = myX / (myV * Math.Cos(tetaR));
            return myTime;
        }

        private static double[] EnterInfo()
        {
            double[] res = new double[5];
            string[] arr = new string[5];

            try
            {
                arr = Console.ReadLine().Split(' ', 5);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = double.Parse(arr[i]);
                }
                if (Conditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterInfo();
            }
            return res;
        }
        private static bool Conditions(double[] nums)
        {
            return true;
        }
        private static int EnterTestNo()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                EnterTestNo();
            }
            return a;
        }
        private static void PrintArray(string[] arr)
        {
            for (int q = 0; q < arr.Length; q++)
            {
                Console.WriteLine(arr[q]);
            }
        }
    }
}
