package com.company;

import java.util.ArrayList;

class Task5 {
    static int getRoundSimpleNumbersCount(int max) {
        ArrayList<Integer> roundSimpleNumbers = new ArrayList<>();
        roundSimpleNumbers.add(2);
        for (int num = 3; num <= max; num += 2) {
            if (isRoundSimple(num))
                roundSimpleNumbers.add(num);
        }
        return roundSimpleNumbers.size();
    }

    public static boolean isRoundSimple(int num) {
        String numberString = String.valueOf(num);
        for (int i = 0; i < numberString.length(); i++) {
            if (!isSimple(Integer.valueOf(numberString))) return false;
            else {
                numberString = numberString.concat(String.valueOf(numberString.charAt(0)));
                numberString = numberString.substring(1, numberString.length() - 1);
            }
        }
        return true;
    }

    public static boolean isSimple(int number) {
        for (int i = 2; i < number; i++)
            if (number % i == 0) return false;
        return true;
    }
}
