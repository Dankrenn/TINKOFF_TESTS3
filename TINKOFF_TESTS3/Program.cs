using System;
// дана строка состоящая из 4 элементов ,найти минимальный размер подстроки в котором эти элементы находятся и вывести результат
public class Program
{
    public static string GetSubString(string str)
    {
        string result = "";
        Dictionary<char, int> countChars = new Dictionary<char, int>()
        {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 },
            { 'd', 0 }
        };

        int i = 0;
        while ((countChars['a'] == 0 || countChars['b'] == 0 || countChars['c'] == 0 || countChars['d'] == 0) && i < str.Length)
        {
            result += str[i];
            countChars[str[i]]++;
            i++;
        }

        if (countChars['a'] == 0 || countChars['b'] == 0 || countChars['c'] == 0 || countChars['d'] == 0)
        {
            throw new Exception("Нет хорошей строки");
        }

        return result;
    }

    public static List<string> GetAllSubString(string str)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < str.Length - 4; i++)
        {
            try
            {
                result.Add(GetSubString(str.Remove(0, i)));
            }
            catch
            {
                break;
            }
        }

        return result;
    }

    public static string GetMinString(List<string> strings, int length)
    {
        int minLength = length + 1;
        string minString = "";
        foreach (string str in strings)
        {
            if (str.Length < minLength)
            {
                minLength = str.Length;
                minString = str;
            }
        }

        return minString;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string line = Console.ReadLine();
        string minString = GetMinString(GetAllSubString(line), n);
        Console.WriteLine(minString.Length > 0 ? minString.Length : -1);
        Console.ReadLine();
    }
}
