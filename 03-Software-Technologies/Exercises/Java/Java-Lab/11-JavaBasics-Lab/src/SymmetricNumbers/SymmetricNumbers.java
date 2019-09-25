package SymmetricNumbers;

import java.util.ArrayList;
import java.util.Scanner;

public class SymmetricNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        
        int n = Integer.parseInt(scan.nextLine());
        
        ArrayList<Integer> array = new ArrayList<>();
        
        for (int i = 1; i <= n; i++) {
            int reversed = Integer.parseInt(new StringBuffer(String.valueOf(i)).reverse().toString());
            if (i == reversed)
                array.add(reversed);
        }

        for (Integer num : array) {
            System.out.printf("%d ", num);
        }
    }
}
