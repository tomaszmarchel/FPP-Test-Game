using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    [SerializeField] List<Room> rooms;
    private int finishedRoomsCount = 0;
    private int destroydedRoomsCount = 0;

    private void Start()
    {
        rooms = new List<Room>();

        var childRooms = GetComponentsInChildren<Room>();
        rooms.AddRange(childRooms);
    }

    public void RoomFinished()
    {
        finishedRoomsCount++;

        if (finishedRoomsCount + destroydedRoomsCount == rooms.Count)
            GameManager.Instance.GameOver();
    }

    public void RoomDestroyded()
    {
        destroydedRoomsCount++;

        if (finishedRoomsCount + destroydedRoomsCount == rooms.Count)
            GameManager.Instance.GameOver();
    }

    public int GetMissedWalls()
    {
        int missedWalls = 0;

        foreach (var room in rooms)
        {
            // -1 because one wall is separated
            missedWalls +=room.GetWallsToHitList().Count - 1;
        }

        return missedWalls;
    }
}
