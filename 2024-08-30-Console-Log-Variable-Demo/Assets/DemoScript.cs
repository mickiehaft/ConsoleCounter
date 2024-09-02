using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    // Recipe for creating a variable:
    // type name (= value) (items inside parentheses are optional)
    // Example: int counter = 0;
    // Declaring the variable here, inside the class, at the top of
    // the class definition, makes it a class variable
    int counter;
    string prefix;

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
        counter = counter + 1;
        Debug.Log(prefix + counter); // + converting "counter" to a string
                                    // then sticking on the end of "prefix"

        // Once the counter exceeds the specified value, re-assign its value to 0
        if (counter > 5000) {
            counter = 0;
        }
    }
}
