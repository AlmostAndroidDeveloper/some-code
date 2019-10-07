package com.company;

import java.util.ArrayList;

class Task1 {

    static boolean containsAllDigits(long number) {
        ArrayList<Integer> digits = new ArrayList<>(9);
        while (number > 0) {
            int lastDigit = (int) (number % 10);
            if (digits.contains(lastDigit)) return false;
            digits.add(lastDigit);
            number /= 10;
        }
        return true;
    }

    static ArrayList<Long> getPandigitalNumbers() {
        ArrayList<Long> pandigitalNumbers = new ArrayList<>();
        for (int a = 1; a < 999; a++)
            for (int b = 1; b < 9999; b++) {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.append(a);
                stringBuilder.append(b);
                if (!containsAllDigits(Integer.valueOf(stringBuilder.toString()))) continue;
                stringBuilder.append(a * b);
                if (!containsAllDigits(Long.valueOf(stringBuilder.toString()))) continue;
                if (!pandigitalNumbers.contains(Long.valueOf(stringBuilder.toString())))
                    pandigitalNumbers.add(Long.valueOf(stringBuilder.toString()));
            }
        return pandigitalNumbers;
    }

    static long getPandigitalNumbersSum(ArrayList<Long> pandigitalNumbers){
        long sum = 0;
        for(long number: pandigitalNumbers)
            sum+=number;
        return sum;
    }

    static void printAllNumbers(ArrayList<Long> pandigitalNumbers){
        for(long number: pandigitalNumbers)
            System.out.println(number);
    }

}
