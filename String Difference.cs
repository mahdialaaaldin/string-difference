using System;
public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        List<string> results = FindAllCombinations(FindStringDifference(str1, str2));
        Console.WriteLine("All possible outcomes:");
        foreach (string result in results)
            Console.WriteLine(result);
    }
    static String FindStringDifference(string str1, string str2)
    {
        return Math.Abs(transformToNumber(str1) - transformToNumber(str2)).ToString();
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
    public static Dictionary<char, int> CreateLetterToNumberDictionary()
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        Dictionary<char, int> letterToNumber = new Dictionary<char, int>();
        for (int i = 0; i < alphabet.Length; i++)
        {
            letterToNumber[alphabet[i]] = i;
        }
        return letterToNumber;
    }
    public static int transformToNumber(string str)
    {
        Dictionary<char, int> letterToNumber = CreateLetterToNumberDictionary();
        string numStr = "";
        foreach (char c in str)
        {
            numStr = numStr + letterToNumber[c];
        }
        return int.Parse(numStr);
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
