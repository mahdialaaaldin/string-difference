using System;
public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        List<string> results=FindStringDifference(str1, str2);

        Console.WriteLine("All possible outcomes:");
        foreach (string result in results)
            Console.WriteLine(result);


    }

    static List<string> FindStringDifference(string str1, string str2)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        Dictionary<char, int> letterToNumber = new Dictionary<char, int>();
        for (int i = 0; i < alphabet.Length; i++)
        {
            letterToNumber[alphabet[i]] = i;
        }

        string numStr1 = "", numStr2 = "";
        foreach (char c in str1)
        {
            numStr1 = numStr1 + letterToNumber[c]; 
        }

        foreach (char c in str2)
        {
            numStr2 = numStr2 + letterToNumber[c];
        }

        int num1 = int.Parse(numStr1),num2 = int.Parse(numStr2);

        int diff = Math.Abs(num1 - num2);

        List<string> results = FindAllCombinations(diff.ToString());
        return results;
    }
    static List<string> FindAllCombinations(string str)
    {
        List<string> results = new List<string>();
        FindAllCombinationsHelper(str, "", results);
        return results;
    }
    static void FindAllCombinationsHelper(string str, string currentCombination, List<string> results)
    {
        if (str.Length == 0)
            results.Add(NumberToString(currentCombination));

        for (int i = 1; i <= str.Length; i++)
        {
            string newCombination = currentCombination + str.Substring(0, i) + " ";
            int value = int.Parse(str.Substring(0, i));
            if (value >= 0 && value <= 25)
                FindAllCombinationsHelper(str.Substring(i), newCombination, results);
        }
    }

    static string NumberToString(string numberString)
    {
        string[] numbers = numberString.Split(' ');
        string result = "";
        foreach (string number in numbers)
        {
            if (number != "")
                result += (char)(int.Parse(number) + 'a');
        }
        return result;
    }

}

