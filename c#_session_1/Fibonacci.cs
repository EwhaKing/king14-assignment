using System;

class MainClass {
    public static void Main (string[] args) {
        int T, max = 0;
        int[] input;
        int[,] answer = new int[41, 2];

        T = int.Parse(Console.ReadLine());
        input = new int[T];

        for (int i = 0; i < T; i++) {
            input[i] = int.Parse(Console.ReadLine());
            if (input[i] > max) max = input[i];
        }

        answer[0, 0] = 1;
        answer[0, 1] = 0;
        answer[1, 0] = 0;
        answer[1, 1] = 1;

        for (int i = 2; i <= max; i++) {
            answer[i, 0] = answer[i - 1, 0] + answer[i - 2, 0];
            answer[i, 1] = answer[i - 1, 1] + answer[i - 2, 1];
        }

        for (int i = 0; i < T; i++) {
            Console.WriteLine($"{answer[input[i], 0]} {answer[input[i], 1]}");
        }
    }
}
