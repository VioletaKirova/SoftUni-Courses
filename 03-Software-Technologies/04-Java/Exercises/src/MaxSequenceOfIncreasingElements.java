import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfIncreasingElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int start = 0;
        int length = 0;
        int currentLen = 0;

        for (int i = 0; i < nums.length - 1; i++) {
            if (nums[i] < nums[i + 1]){
                currentLen++;
                if (currentLen > length){
                    start = i - currentLen + 1;
                    length = currentLen;
                }
            } else {
                currentLen = 0;
            }
        }

        for (int i = start; i <= start + length; i++) {
            System.out.print(nums[i] + " ");
        }
    }
}
