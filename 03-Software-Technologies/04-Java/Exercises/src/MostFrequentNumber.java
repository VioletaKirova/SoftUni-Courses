import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        LinkedHashMap<Integer, Integer> numsByCount = new LinkedHashMap<>();

        for (int i = 0; i < nums.length; i++) {
            if (numsByCount.containsKey(nums[i])) {
                numsByCount.put(nums[i], numsByCount.get(nums[i]) + 1);
            } else {
                numsByCount.put(nums[i], 1);
            }
        }

        int currentLen = 0;
        int maxLen = 0;
        int number = 0;

        for (Integer current : numsByCount.keySet()) {
            currentLen = numsByCount.get(current);

            if (currentLen > maxLen){
                maxLen = currentLen;
                number = current;
            }
        }

        System.out.println(number);
    }
}
