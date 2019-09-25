import java.util.Arrays;
import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] vowels = new String[]{"a", "o", "u", "e", "i"};
        String[] digits = new String[10];

        for (int i = 0; i < digits.length; i++) {
            digits[i] = String.valueOf(i);
        }

        String input = scanner.nextLine();

        if (Arrays.asList(vowels).contains(input)){
            System.out.println("vowel");
        } else if (Arrays.asList(digits).contains(input)) {
            System.out.println("digit");
        } else {
            System.out.println("other");
        }
    }
}
