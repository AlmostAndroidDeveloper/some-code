package com.company;

import java.math.BigInteger;
import java.util.ArrayList;

class Task2 {

    static ArrayList<BigInteger> getSequence(int a,int b){
        ArrayList<BigInteger> sequence = new ArrayList<>();
        for(int i=2;i<=a;i++)
            for(int j=2;j<=b;j++){
                BigInteger number = BigInteger.valueOf(i);
                number = number.pow(j);
                if(!sequence.contains(number))
                    sequence.add(number);
            }
        return sequence;
    }
}
