import java.util.HashMap;
import java.util.Scanner;

public class Phonebook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> phonebook = new HashMap<>();

        String input = scanner.nextLine();

        while (!input.equals("END")){
            String[] tokens = input.split(" ");

            if (input.contains("A")){
                if (phonebook.containsKey(tokens[1])){
                    phonebook.put(tokens[1], tokens[2]);
                } else {
                    phonebook.put(tokens[1], tokens[2]);
                }
            } else if (input.contains("S")) {
                if (phonebook.containsKey(tokens[1])){
                    System.out.printf("%s -> %s%n", tokens[1], phonebook.get(tokens[1]));
                } else {
                    System.out.printf("Contact %s does not exist.%n", tokens[1]);
                }
            }

            input = scanner.nextLine();
        }

    }
}
