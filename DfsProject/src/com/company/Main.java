package com.company;

import java.awt.*;
import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Stack;

public class Main {

    enum State {
        Empty,
        Wall,
        Visited
    }

    /*private static String[] labyrinth = new String[]{
            " XXXXXXXXXXX XXX",
            " X              ",
            " X XX XXXXXXXX  ",
            "   XXXXXX    X  ",
            " X XXX  X X  X  ",
            " X      X XXXX  ",
            "  XXXXXX        ",
            "XX       XXXX   ",
    };*/
    private  static String[] labyrinth = new String[]{
            " X   X    ",
            " X XXXXX X",
            "      X   ",
            "XXXX XXX X",
            "         X",
            " XXX XXXXX",
            " X        ",
    };

    private static int[] dx = {-2, -2, -1, -1, 1, 1, 2, 2};
    private static int[] dy = {-1, 1, -2, 2, -2, 2, -1, 1};

    public static void main(String[] args) {
        simpleLabyrinthSearch();
    }

    private static void simpleLabyrinthSearch() {
        State[][] map = fillMap();
        ArrayDeque<Point> stack = new ArrayDeque<>();
        stack.push(new Point(0, 0));
        while (!stack.isEmpty()) {
            Point point = stack.pop();
            if (map[point.x][point.y] != State.Empty) continue;
            map[point.x][point.y] = State.Visited;
            printMap(map);

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++) {
                    if (i != 0 && j != 0) continue;
                    if (point.x + i < 0 || point.x + i >= map.length || point.y + j < 0 || point.y + j >= map[0].length)
                        continue;
                    else stack.push(new Point(point.x + i, point.y + j));
                }
        }
        System.out.println("Depth-first search finished");
    }

    private static State[][] fillMap() {
        State[][] map = new State[labyrinth.length][labyrinth[0].length()];
        for (int i = 0; i < labyrinth.length; i++)
            for (int j = 0; j < labyrinth[i].length(); j++)
                map[i][j] = labyrinth[i].charAt(j) == 'X' ? State.Wall : State.Empty;
        return map;
    }

    private static void printMap(State[][] map) {
        for (int i = 0; i < map.length; i++) {
            for (int j = 0; j < map[i].length; j++)
                System.out.print(map[i][j] == State.Wall ? "X" : map[i][j] == State.Visited ? "." : " ");
            System.out.print("\n");
        }
        System.out.println("----------");
        makeDelay(500);
    }

    private static void makeDelay(int millis) {
        try {
            Thread.sleep(millis);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
