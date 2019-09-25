import java.util.Scanner;

public class FitStringIn20Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        StringBuilder strBuilder = new StringBuilder();

        if (text.length() >= 20){
            for (int i = 0; i < 20; i++) {
                strBuilder.append(text.charAt(i));
            }
        } else {
            int len = 20 - text.length();

            strBuilder.append(text);

            for (int i = 0; i < len; i++) {
                strBuilder.append('*');
            }
        }

        String output = strBuilder.toString();

        System.out.println(output);
    }
}
