import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Integer> nums =  Arrays.stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int[] specialNums = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        while (nums.contains(specialNums[0])) {
            int position = nums.indexOf(specialNums[0]);
            int start = position - specialNums[1];
            int end = position + 1 + specialNums[1];

            if (start < 0 && end > nums.size() - 1)
                nums.clear();
            else if (start < 0)
                nums.subList(0, end).clear();
            else if (end > nums.size())
                nums.subList(start, nums.size()).clear();
            else {
                nums.subList(start, end).clear();
            }
        }
        int sum = nums.stream().mapToInt(i -> i).sum();

        System.out.println(sum);
    }
}
