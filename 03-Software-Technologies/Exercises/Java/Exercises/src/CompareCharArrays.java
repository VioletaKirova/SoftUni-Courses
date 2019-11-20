import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstStr = scanner.nextLine();
        String secondStr = scanner.nextLine();

        int compared = firstStr.compareTo(secondStr);

        if (compared < 0){
            System.out.println(firstStr.replaceAll("\\W", ""));
            System.out.println(secondStr.replaceAll("\\W", ""));
        } else {
            System.out.println(secondStr.replaceAll("\\W", ""));
            System.out.println(firstStr.replaceAll("\\W", ""));
        }
    }
}
