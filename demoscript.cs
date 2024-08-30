using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoscript : MonoBehaviour
{
    //Recipe for creating a variable
    // variable type name (=value) (items inside parentheses are optional)
    // Example: int counter = 0;
    // Declaring the variable, here, inside of your public class
    // (inside of these {} curly brackets)
    // Will allow you to use the variable anywhere within the public class.

    int counter;
    string prefix;

    //Recipe for a function
    // "return type" FunctionName() {}


    // Start is called before the first frame update
    void Start()
    {
        // Here we are assigning initial values to the variables
        // This is called "initializing variables"
        // We do this in the Start function because this will be 
        // first thing Unity runs when we start the scene.
        counter = 0;
        prefix = "The counter's value is: ";
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + 1;
        Debug.Log(prefix + counter); // The plus sign here is converting
                                     // "counter" to a string, then sticking
                                     // it to the end of "prefix"

        if(counter > 120)
        {
            counter = 0;
        }   // this "if statement" makes it so that when the counter gets over
            // the value of 120, it will reset the value beack to 0.
    }
}
