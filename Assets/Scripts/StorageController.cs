using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StorageController
{
    private static int gamePoints;
    private static int healthPoints;

    // Add game points to the users session
    public static void AddGamePoints(int pointsToAdd)
    {
        gamePoints += pointsToAdd;

    }

    // Check if a user can afford to remove game points and return a bool and
    // remove the points if they can afford it
    public static bool RemoveGamePoints(int pointsToRemove)
    {
        if (gamePoints < pointsToRemove) return false;
        gamePoints -= pointsToRemove;
        return true;
    }

    // Get current number of game points in the users session
    public static int GetGamePoints()
    {
        return gamePoints;
    }

    // Set the number of game points in the users session
    public static void SetGamePoints(int newPoints)
    {
        gamePoints = newPoints;
    }

    // Add game points to the users session
    public static void AddHealthPoints(int pointsToAdd)
    {
        healthPoints += pointsToAdd;

    }

    public static bool RemoveHealthPoints(int pointsToRemove)
    {
        if (gamePoints < pointsToRemove) return false;
        healthPoints -= pointsToRemove;
        return true;
    }

    // Get current number of health points in the users session
    public static int GetHealthPoints()
    {
        return healthPoints;
    }

    // Set the number of health points in the users session
    public static void SetHealthPoints(int newPoints)
    {
        healthPoints = newPoints;
    }
}
