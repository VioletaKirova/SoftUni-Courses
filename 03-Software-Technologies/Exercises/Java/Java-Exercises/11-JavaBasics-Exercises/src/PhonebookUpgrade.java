import java.util.Arrays;
import java.util.Scanner;
import java.util.HashMap;


public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> phonebook = new HashMap<>();

        String input = scanner.nextLine();

        while (!input.equals("END")) {
            String[] tokens = input.split(" ");

            if (input.startsWith("A")) {
                if (phonebook.containsKey(tokens[1])) {
                    phonebook.put(tokens[1], tokens[2]);
                } else {
                    phonebook.put(tokens[1], tokens[2]);
                }
            } else if (input.startsWith("S")) {
                if (phonebook.containsKey(tokens[1])) {
                    System.out.printf("%s -> %s%n", tokens[1], phonebook.get(tokens[1]));
                } else {
                    System.out.printf("Contact %s does not exist.%n", tokens[1]);
                }
            } else if (input.equals("ListAll")) {
                String[] keys = phonebook.keySet().toArray(new String[phonebook.size()]);
                Arrays.sort(keys);
                for (String key : keys) {
                    System.out.printf("%s -> %s%n", key, phonebook.get(key));
                }
            }
            input = scanner.nextLine();
        }
    }
}
