import java.util.Scanner;

public class VariableInHexFormat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String hexNum = scanner.nextLine();

        int convertedNum = Integer.parseInt(hexNum, 16);

        System.out.println(convertedNum);
    }
}
