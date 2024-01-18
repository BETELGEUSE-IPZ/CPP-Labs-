namespace Labs;


public class Lab1 : ILab
{
    private Lab1() { }


    public static Lab1 Instance { get; } = new();


    public string Calculate(string text)
    {
        // Ініціалізація змінних для зберігання мінімального числа та кількості чисел
        int minNumber = int.MaxValue;
        int count = 0;
        int N = int.Parse(text);
        GenerateNumbers("", N);
        return $"{count} {minNumber}";


        void GenerateNumbers(string prefix, int N)
        {
            // Якщо ми сгенерували N-значне число
            if (N == 0)
            {
                // Перевіряємо, чи дорівнює сума цифр їх добутку
                if (SumEqualsProduct(prefix))
                {
                    // Якщо так, збільшуємо лічильник і оновлюємо мінімальне число
                    count++;
                    minNumber = Math.Min(minNumber, int.Parse(prefix));
                }
            }
            else
            {
                // Генеруємо всі можливі числа, додаючи цифри від 0 до 9
                for (int i = 0; i <= 9; i++)
                {
                    // Дозволяємо провідні нулі для всіх випадків, крім випадку, коли N є довжиною числа
                    if (prefix.Length == 0 && i == 0 && N > 1) continue;

                    // Рекурсивно генеруємо числа
                    GenerateNumbers(prefix + i, N - 1);
                }
            }
        }
    }


    private static bool SumEqualsProduct(string number)
    {
        // Конвертуємо рядок у масив цифр
        int[] digits = number.Select(c => c - '0').ToArray();

        // Обчислюємо суму та добуток цифр
        int sum = digits.Sum();
        int product = digits.Aggregate(1, (a, b) => a * b);

        // Повертаємо true, якщо сума дорівнює добутку, інакше false
        return sum == product;
    }
}