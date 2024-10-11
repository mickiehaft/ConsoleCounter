using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        // Destroy(collision.gameObject);
        // Call the ReactToHit method of the ReactiveTarget script 
        // attached to the object
        ReactiveTarget target = collision.gameObject.GetComponent<ReactiveTarget>(); 
        if (target != null) {
            target.ReactToHit();
        }
    }
}
