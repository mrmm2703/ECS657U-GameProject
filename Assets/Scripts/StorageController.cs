using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class which stores persistent data to be accessed throughout the game
public static class StorageController
{
    private static int gamePoints;
    private static int healthPoints;
    private static int gameRound;

    private static float soundEffectsVolume = 1f;
    private static float backgroundMusicVolume = 1f;

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

    // Get current round number in the users session
    public static int GetGameRound()
    {
        return gameRound;
    }

    // Set the game round number in the users session
    public static void SetGameRound(int newRound)
    {
        gameRound = newRound;
    }

    // Add health points to the users session
    public static void AddHealthPoints(int pointsToAdd)
    {
        healthPoints += pointsToAdd;

    }

    // Remove number of health points given
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

    // Set the volume for all sound effects
    public static void SetSoundEffectsVolume(float newVol)
    {
        soundEffectsVolume = newVol;
    }

    // Get the volume of sound effects
    public static float GetSoundEffectsVolume()
    {
        return soundEffectsVolume;
    }

    // Set the volume for background music
    public static void SetBackgroundMusicVolume(float newVol)
    {
        backgroundMusicVolume = newVol;
        BackgroundMusic.GetControllerInScene().UpdateVolume(newVol);
    }

    // Get the volume of background music
    public static float GetBackgroundMusicVolume()
    {
        return backgroundMusicVolume;
    }
}
