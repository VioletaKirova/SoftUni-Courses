package SumTwoNumbers;

import java.util.Scanner;

public class SumTwoNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double num1 = Double.parseDouble(scanner.nextLine());
        double num2 = Double.parseDouble(scanner.nextLine());
        double sum = num1 + num2;

        System.out.printf("Sum = %.2f", sum);
    }
}
