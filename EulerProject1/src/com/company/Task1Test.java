package com.company;

import org.junit.Assert;
import org.junit.Test;

import static org.junit.Assert.*;

public class Task1Test {

    @Test
    public void containsAllDigitsTest(){
        assertTrue(Task1.containsAllDigits(123456789));
        assertTrue(Task1.containsAllDigits(12345));
        assertFalse(Task1.containsAllDigits(221331313));
    }

}