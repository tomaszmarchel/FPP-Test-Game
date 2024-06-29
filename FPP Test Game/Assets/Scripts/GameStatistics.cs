using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    public static float playingTime = 0;

    public static int correctNeutralizedDoors = 0;
    public static int correctNeutralizedRooms = 0;

    //ERRORS
    public static int noMeasurementError = 0;
    public static int tooHighRingValueDoorsError = 0;
    public static int tooLowRingValueDoorsError = 0;

    public static int wrongRingValueInRoomError = 0;
    public static int missedWallsInRoomError = 0;
    public static int moreThanOneShootToWallError = 0;
}
