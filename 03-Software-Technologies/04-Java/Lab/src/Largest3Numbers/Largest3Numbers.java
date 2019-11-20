package Largest3Numbers;

import java.util.Arrays;
import java.util.Scanner;

public class Largest3Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        Arrays.sort(nums);

        int count = Math.min(nums.length, 3);

        for (int i = 0; i < count; i++) {
            System.out.printf("%d%n", nums[nums.length - 1 - i]);
        }
    }
}
