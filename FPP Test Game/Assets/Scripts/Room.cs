using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomsController roomController;

    [SerializeField] Wall[] walls;
    public List<Wall> wallsToHit;

    private bool roomDestroyded = false;

    void Start()
    {
        roomController = GetComponentInParent<RoomsController>();
        wallsToHit = walls.ToList();
    }

    public void RoomFinishCheck()
    {
        if (wallsToHit.Count == 0)
            RoomFinished();
    }

    public void DeleteWallFromList(Wall wall)
    {
        wallsToHit.Remove(wall);
    }

    public void RoomDestroyded()
    {
        roomDestroyded = true;
        roomController.RoomDestroyded();
    }

    public void RoomFinished()
    {
        GameStatistics.correctNeutralizedRooms++;
        roomController.RoomFinished();
    }

    public List<Wall> GetWallsToHitList()
    {
        return wallsToHit;
    }
}
