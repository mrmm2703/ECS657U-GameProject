using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StorageController
{
    private static int gamePoints;

    public static void AddGamePoints(int pointsToAdd)
    {
        gamePoints += pointsToAdd;
        Debug.Log("Added " + pointsToAdd.ToString() + " points. Points: " + gamePoints.ToString());

    }

    public static void RemoveGamePoints(int pointsToRemove)
    {
        gamePoints -= pointsToRemove;
        Debug.Log("Removed " + pointsToRemove.ToString() + " points. Points: " + gamePoints.ToString());
    }

    public static int GetGamePoints()
    {
        return gamePoints;
    }

    public static void SetGamePoints(int newPoints)
    {
        gamePoints = newPoints;
    }
}
