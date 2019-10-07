package com.company;

class Task4 {

    private static boolean isPalindrome(String string){
        StringBuilder reverseString = new StringBuilder();
        for(char symbol : string.toCharArray())
            reverseString.insert(0,symbol);
        return reverseString.toString().equals(string);
    }

    static long getAllPalindromesSum(int max){
        int sum = 0;
        for(int i=0;i<=max;i++){
            if(isPalindrome(String.valueOf((i))) && isPalindrome(getBinaryNumber(i))) {
                sum+=i;
            }
        }
        return sum;
    }

    private static String getBinaryNumber(int num){
        StringBuilder result = new StringBuilder();
        while(num>0){
            result.append(num%2);
            num/=2;
        }
        return result.toString();
    }
}
