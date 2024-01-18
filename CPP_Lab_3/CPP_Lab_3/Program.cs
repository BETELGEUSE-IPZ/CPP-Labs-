using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Зчитуємо всі рядки з файлу INPUT.TXT
        var lines = File.ReadAllLines("INPUT.TXT");
        // Розбиваємо перший рядок на числа: кількість комп'ютерів (n) та кількість з'єднань (m)
        var nm = lines[0].Split().Select(int.Parse).ToArray();
        int n = nm[0], m = nm[1];

        // Створюємо матрицю суміжності для графа
        int[,] g = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                g[i, j] = i == j ? 0 : int.MaxValue / 2;

        // Заповнюємо матрицю суміжності на основі вхідних даних
        for (int i = 1; i <= m; i++)
        {
            var xy = lines[i].Split().Select(int.Parse).ToArray();
            int x = xy[0] - 1, y = xy[1] - 1;
            g[x, y] = g[y, x] = 1;
        }

        // Використовуємо алгоритм Флойда-Уоршалла для знаходження найкоротших шляхів між усіма парами вершин
        for (int k = 0; k < n; k++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    g[i, j] = Math.Min(g[i, j], g[i, k] + g[k, j]);

        // Обчислюємо коефіцієнт зв'язності як суму довжин найкоротших шляхів між усіма парами вершин
        int ans = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                ans += g[i, j];

        // Записуємо результат у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", ans.ToString());
    }
}
