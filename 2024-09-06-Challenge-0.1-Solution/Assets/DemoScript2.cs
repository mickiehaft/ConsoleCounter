using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

// NOTE: This script implements all four challenge steps
public class DemoScript2 : MonoBehaviour
{
    // Recipe for creating a variable:
    // type name (= value) (items inside parentheses are optional)
    // Example: int counter = 0;
    // Declaring the variable here, inside the class, at the top of
    // the class definition, makes it a class variable

    bool stateJustEntered;
    int counter;
    int money;
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
        stateJustEntered = false;
        counter = 0;
        money = 2000;
        prefix = "The counter's value is: ";
        phase1 = "I love Cantaloupes";
        phase2 = "I love Watermelons";
        phase3 = "I love Honeydew";
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
            if (counter == 0) {
                stateJustEntered = true;
            }

            // Nested if statement to check money value
            if ( money < 0 ) {
                currentPhase = "Return your cantaloupes or lose your kneecaps: ";
            }
            else if (money == 0) {
                currentPhase = "You lose all your cantaloupes. You had this many: ";
            } else {
                currentPhase = phase1;
            }

            // If I've just entered this range of numbers, then 
            // I want to print the phrase to the console. If not,
            // I don't want to print it to the console
        } else if (/*counter >= 5000 && */ counter <= 9999) {
            if (counter == 5000) {
                stateJustEntered = true;
            }
            currentPhase = phase2;
        } else if (/*counter >= 10000 && */ counter <= 19999) {
            if (counter == 10000) {
                stateJustEntered = true;
            }
            currentPhase = phase3;
        } else {
            counter = -1;
        }

        if (stateJustEntered) {
            Debug.Log(currentPhase);
            stateJustEntered = false;
        }
        // Increment the value after I print to the Console
        counter = counter + 1;
        
        money -= 5;
        if (money < -1000) {
            money = Random.Range(2000, 5000);
        }
        //Debug.Log("Money: $" + money);
    }
}
