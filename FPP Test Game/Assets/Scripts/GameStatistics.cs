using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    //STATS
    private static float playingTime = 0;

    public static int correctNeutralizedDoors = 0;
    public static int incorrentNeutralizedDoors = 0;

    //ERRORS
    public static int noMeasurement = 0;
    public static int higherRingValue = 0;
    public static int lowerRingValue = 0;
    public static int badRingValue = 0;
    public static int missedWalls = 0;
    public static int moreThanOneInteractWalls = 0;

    public static void IncreaseValue(int value)
    {
        value++;
    }
}
