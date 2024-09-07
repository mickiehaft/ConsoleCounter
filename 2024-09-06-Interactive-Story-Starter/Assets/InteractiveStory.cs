using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveStory : MonoBehaviour
{
    // Setting is AIMM 202
    // Goal: Turn on the projector

    // Recipe for creating a variable:
    // type name (= value) (items inside parentheses are optional)
    // Example: int counter = 0;
    // Declaring the variable here, inside the class, at the top of
    // the class definition, makes it a class variable

    // This variable represents the current state of the game
    // 0: Beginning of the game
    // 1: Looking for the light switch
    // 2: Going into the hallway towards the light
    int currentGameState;
    int prevGameState;

    // Recipe for a function/method:
    // return "type" Name (parameter list (optional))
    // { commands inside the function }

    // Start is called before the first frame update
    void Start()
    {
        // Here we are assigning an initial value to the currentGameState and prevGameState variables
        // This is called "initializing" the variable
        // We do this in the Start function because it is the first
        // code that runs when we start the scene
        currentGameState = 0;
        prevGameState = -1; //Start at -1 to ensure that the current and prev
                            // game states are different so that we actually
                            // show the text for the first scene
    }

    // Update is called once per frame
    void Update()
    {
        // This if-else structure checks the current currentGameState
        // and calls the appropriate function based on that state
        if (currentGameState == 0)
        {
            Beginning();
        }
        else if (currentGameState == 1)
        {
            LookingforLightswitch();
        }
        else if (currentGameState == 2)
        {
            Hallway();
        }
    }

    // *** Game State Functions *** //
    // This function handles the beginning state of the game
    void Beginning()
    {
        // Only show the text for this scene once, the first time we enter the scene
        if (prevGameState != currentGameState)
        {
            prevGameState = currentGameState; //Ensure that the code below only runs once

            // 1. Set the stage for the player
            // Debug.Log is used to print messages to the Unity Console
            // The + operator is used to concatenate strings
            Debug.Log("You find yourself in the AIMM building on TCNJ's campus, specifically in room 202 for some reason." +
            "It's dark in here and you need to turn on the projector. You can't see anything in the room! But, you see" +
            "a light in the hallway. Do you: ");

            // 2. Present options to the player
            Debug.Log("1. Run your hand along the wall to look for the light switch; 2. Walk toward the light in the hallway.");
        }
        // 3. Check for player input
        // Input.GetKeyDown checks if a key was pressed this frame
        // KeyCode.Alpha1 represents the '1' key, KeyCode.Alpha2 represents the '2' key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentGameState = 1;  // Change game state to "Looking for light switch"
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentGameState = 2;  // Change game state to "Hallway"
        }
    }

    // This function handles the state where the player is looking for the light switch
    void LookingforLightswitch()
    {
        if (prevGameState != currentGameState)
        {
            prevGameState = currentGameState;
            Debug.Log("You are looking for the lightswitch");
        }
    }

    // This function handles the state where the player is in the hallway
    void Hallway()
    {
        if (prevGameState != currentGameState)
        {
            prevGameState = currentGameState;
            Debug.Log("You are in the hallway");
        }
    }
    // *** End Game State Functions *** //
}