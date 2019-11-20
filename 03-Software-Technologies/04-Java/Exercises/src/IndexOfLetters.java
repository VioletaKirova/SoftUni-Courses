import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        for (int i = 0; i < input.length(); i++) {
            System.out.printf("%c -> %d%n", input.charAt(i), input.charAt(i) - 97);

        }
    }
}
