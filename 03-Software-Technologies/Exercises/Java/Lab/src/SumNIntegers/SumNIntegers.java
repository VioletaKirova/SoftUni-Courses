package SumNIntegers;

import java.util.Scanner;

public class SumNIntegers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int sum = 0;

        for (int i = 0; i < n; i++) {
            int currentNum = Integer.parseInt(scanner.nextLine());
            sum += currentNum;
        }

        System.out.printf("Sum = %d", sum);
    }
}
