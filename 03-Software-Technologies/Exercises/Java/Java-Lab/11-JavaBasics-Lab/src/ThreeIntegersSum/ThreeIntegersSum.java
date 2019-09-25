package ThreeIntegersSum;

import java.util.Scanner;

public class ThreeIntegersSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");

        int num1 = Integer.parseInt(input[0]);
        int num2 = Integer.parseInt(input[1]);
        int num3 = Integer.parseInt(input[2]);

        if (!CheckThreeIntegers(num1, num2, num3)
                && !CheckThreeIntegers(num2, num3, num1)
                && !CheckThreeIntegers(num1, num3, num2)) {
            System.out.println("No");
        }
    }

    static boolean CheckThreeIntegers(int num1, int num2, int num3) {
        if (num1 + num2 != num3) {
            return false;
        }

        if (num1 <= num2) {
            System.out.printf("%d + %d = %d%n", num1, num2, num3);
        } else {
            System.out.printf("%d + %d = %d%n", num2, num1, num3);
        }

        return true;
    }
}
