using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "www.runoob.com";
            string result = s.Substring(7, 1);
            // Console.WriteLine(result);

            string S1 = "7832974972840919321747983209327", S2 = "1987432091904327543957";
            string ss = multiply(S1, S2);
            Console.WriteLine(ss);
            Console.ReadLine();
        }
        public static string  multiply(String num1, String num2)
        {
            int l = num1.Length;
            int r = num2.Length;
            //用来存储结果的数组，可以肯定的是两数相乘的结果的长度，肯定不会大于两个数各自长度的和。
            int[] num = new int[l + r];
            //第一个数按位循环
            for (int ii = 0; ii < l; ii++)
            {
                //得到最低位的数字
                int n1 = num1.Substring(l - 1 - ii, 1).ToCharArray()[0] - '0';
                //保存进位
                int tmp = 0;
                //第二个数按位循环
                for (int j = 0; j < r; j++)
                {
                    int n2 = num2.Substring(r - 1 - j, 1).ToCharArray()[0] - '0';
                    //拿出此时的结果数组里存的数+现在计算的结果数+上一个进位数
                    tmp = tmp + num[ii + j] + n1 * n2;
                    //得到此时结果位的值
                    num[ii + j] = tmp % 10;
                    //此时的进位
                    tmp /= 10;
                }
                //第一轮结束后，如果有进位，将其放入到更高位
                num[ii + r] = tmp;
            }

            int i = l + r - 1;
            //计算最终结果值到底是几位数，
            while (i > 0 && num[i] == 0)
            {
                i--;
            }
            StringBuilder result = new StringBuilder();
            //将数组结果反过来放，符合正常读的顺序，
            //数组保存的是：1 2 3 4 5 
            //但其表达的是54321，五万四千三百二十一。
            while (i >= 0)
            {
                result.Append(num[i--]);
            }
            return result.ToString();
        }

    }
}
