namespace Labs;


public class Lab2 : ILab
{
    private Lab2() { }


    public static Lab2 Instance { get; } = new();


    public string Calculate(string text)
    {
        string input = text;

        string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); // Розбиває вміст змінної "input" на рядки.
        string originalString = lines[0]; // Зберігає перший рядок у змінну "originalString".
        string subString = lines[1]; // Зберігає другий рядок у змінну "subString".

        for (int k = 1; k <= originalString.Length; k++) // Цикл, який проходиться по всіх символах в "originalString".
        {
            string cyclicExtension = string.Concat(Enumerable.Repeat(originalString, k)).Substring(0, k); // Створює циклічне k-розширення рядка "originalString".
            if (cyclicExtension.Contains(subString)) // Перевіряє, чи містить "cyclicExtension" підрядок "subString".
            {
                return "YES"; // Якщо "cyclicExtension" містить "subString", повертає "YES".
            }
        }

        return "NO"; // Якщо "cyclicExtension" не містить "subString", повертає "NO".
    }
}