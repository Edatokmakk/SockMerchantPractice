using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

class Result
{

    /*
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */

    public static int sockMerchant(int n, List<int> ar)
    {
        int pairs = 0;
        int arrLength = ar.Count;
        int[] frequencyArray = new int[arrLength];
        int frequencyTemp = -1;
        for (int i = 0; i < ar.Count; i++)
        {
            int count = 1;
            for (int j = i + 1; j < ar.Count; j++)
            {
                if (ar[i] == ar[j])
                {
                    count++;
                    frequencyArray[j] = frequencyTemp;
                }
            }
            if (frequencyArray[i] != frequencyTemp)
            {
                frequencyArray[i] = count;
            }
        }

        for (int i = 0; i < (frequencyArray.Length); i++)
        {
            if (frequencyArray[i] != frequencyTemp)
            {
                int divide = frequencyArray[i] / 2;
                pairs += divide;
            }
        }
        return pairs;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        var outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "default_path";
        TextWriter textWriter = new StreamWriter(outputPath, true);

        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//with hashmap
//public static int sockMerchant(int n, List<int> ar)
//{
//    Dictionary<int, int> sockCount = new Dictionary<int, int>();
//    int pairs = 0;

//    // Çorap renklerini say
//    foreach (int sock in ar)
//    {
//        if (sockCount.ContainsKey(sock))
//        {
//            sockCount[sock]++;
//        }
//        else
//        {
//            sockCount[sock] = 1;
//        }
//    }

//    // Her çorap renginden çiftleri hesapla
//    foreach (int count in sockCount.Values)
//    {
//        pairs += count / 2;
//    }

//    return pairs;
////}


//Why Use a HashMap:
//A HashMap allows us to efficiently track how many times each sock color appears in the list. It provides O(1) average time complexity for inserting and searching, making it much faster than a nested loop solution (which would be O(n^2)).