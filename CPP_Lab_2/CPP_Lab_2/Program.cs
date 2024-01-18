using System; // Використовується для включення простору імен System, який містить функції для роботи з файлами, виводу даних тощо.
using System.IO; // Використовується для включення простору імен System.IO, який містить функції для роботи з файлами.
using System.Linq; // Використовується для включення простору імен System.Linq, який містить методи для роботи з даними.

class Program // Оголошення класу "Program".
{
    static void Main() // Головний метод програми.
    {
        string input = File.ReadAllText("INPUT.TXT"); // Читає весь текст з файлу "INPUT.TXT" і зберігає його в змінну "input".

        string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); // Розбиває вміст змінної "input" на рядки.
        string originalString = lines[0]; // Зберігає перший рядок у змінну "originalString".
        string subString = lines[1]; // Зберігає другий рядок у змінну "subString".

        for (int k = 1; k <= originalString.Length; k++) // Цикл, який проходиться по всіх символах в "originalString".
        {
            string cyclicExtension = string.Concat(Enumerable.Repeat(originalString, k)).Substring(0, k); // Створює циклічне k-розширення рядка "originalString".
            if (cyclicExtension.Contains(subString)) // Перевіряє, чи містить "cyclicExtension" підрядок "subString".
            {
                File.WriteAllText("OUTPUT.TXT", "YES"); // Якщо "cyclicExtension" містить "subString", записує "YES" у файл "OUTPUT.TXT".
                return; // Завершує виконання програми.
            }
        }

        File.WriteAllText("OUTPUT.TXT", "NO"); // Якщо "cyclicExtension" не містить "subString", записує "NO" у файл "OUTPUT.TXT".
    }
}
