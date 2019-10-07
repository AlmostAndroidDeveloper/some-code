package com.company;

import org.junit.Test;

import static org.junit.Assert.*;

public class Task5Test {
    @Test
    public void isRoundSimpleTest(){
        assertTrue(Task5.isRoundSimple(197));
    }

    @Test
    public void isSimpleTest(){
        assertTrue(Task5.isSimple(3));
    }

}