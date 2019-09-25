import javafx.util.Pair;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class AverageGrades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double n = Double.parseDouble(scanner.nextLine());

        List<Pair<String, Double>> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] array = scanner.nextLine().split(" ");

            double grade = 0;
            double gradeCount = 0;

            for (int j = 1; j < array.length; j++) {
                grade += Double.parseDouble(array[j]);
                gradeCount++;
            }

            if (grade / gradeCount >= 5.00) {
                students.add(new Pair<>(array[0], grade / gradeCount));
            }
        }

        students.stream()
                .sorted((s1, s2) -> {
                    int compareResult = s1.getKey().compareTo(s2.getKey());

                    if (compareResult == 0) {
                        compareResult = Double.compare(s2.getValue(), s1.getValue());
                    }

                    return compareResult;
                })
                .forEach(s -> System.out.printf("%s -> %.2f%n", s.getKey(), s.getValue()));
    }
}
