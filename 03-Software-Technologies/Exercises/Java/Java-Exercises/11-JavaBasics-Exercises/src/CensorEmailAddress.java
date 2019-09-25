import java.util.Arrays;
import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String email = scanner.nextLine();
        String[] emailArr = email.split("@");

        String text = scanner.nextLine();

        String name = emailArr[0];

        String censoredEmail = name.replaceAll(".", "*") + "@" + emailArr[1];

        String output = text.replaceAll(email, censoredEmail);

        System.out.println(output);
    }
}
