using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: This script implements only Step one of the challenge
public class DemoScript : MonoBehaviour
{
    // Recipe for creating a variable:
    // type name (= value) (items inside parentheses are optional)
    // Example: int counter = 0;
    // Declaring the variable here, inside the class, at the top of
    // the class definition, makes it a class variable
    int counter;
    string prefix;
    string currentPhase, phase1, phase2, phase3;
    // Recipe for a function
    // "return type" FunctionName() {}
    void Start()
    {
        // Here we are assigning initial values to the variables
        // This called "initializing" the variable
        // We do this in the Start function because it is the first
        // code that runs when we start the scene
        counter = 0;
        prefix = "The counter's value is: ";
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(prefix + counter); // + converting "counter" to a string
                                    // then sticking on the end of "prefix"

        // Once the counter exceeds the specified value, re-assign its value to 0
        // Recipe for a conditional statement
        // if (boolean expression) {} — boolean expression is one that evaluates to either true or false
        // 0–4999: Phrase 1
        // 5000–9999: Phrase 2
        // 10000–19999: Phrase 3
        // After reaching 20000, the counter variable’s value should be reassigned to 0.
        // if (counter > 0 && counter < 5000) {
        if (/*counter >= 0 && */ counter <= 4999) { //&& is a "logical AND" 
                                            // (both expressions must be true for the overall expression to be true)
            Debug.Log("You have " + counter + " cantaloupes.");
        } else if (/*counter >= 5000 && */ counter <= 9999) {
            Debug.Log("You have " + counter + " watermelons.");
        } else if (/*counter >= 10000 && */ counter <= 19999) {
            Debug.Log("You have " + counter + " honeydew.");
        } else {
            Debug.Log("YOU GOT THE SUPERMELON.");
            counter = 0;
        }

        // Increment the value after I print to the Console
        counter = counter + 1;
    }
}
