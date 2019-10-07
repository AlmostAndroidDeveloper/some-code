package com.company;

import org.junit.Test;

import java.math.BigInteger;
import java.util.ArrayList;

import static org.junit.Assert.*;

public class Task2Test {

    @Test
    public void getSequenceSizeTest(){
        ArrayList<BigInteger> sequence = Task2.getSequence(5,5);
        assertEquals(sequence.size(),15);
    }
}