import java.util.Scanner;

public class IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());

        String hex = Integer.toString(num, 16);
        System.out.println(hex.toUpperCase());

        String binary = Integer.toString(num, 2);
        System.out.println(binary);
    }
}
