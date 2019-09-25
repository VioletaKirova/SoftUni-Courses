import java.util.Scanner;

public class ReverseCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] charArr = new String[3];

        for (int i = 0; i < 3; i++) {
            charArr[i] = scanner.nextLine();
        }

        StringBuilder reversedChars = new StringBuilder();

        for (int i = charArr.length - 1; i >= 0; i--) {
            reversedChars.append(charArr[i]);
        }

        String output = reversedChars.toString();

        System.out.println(output);
    }
}
