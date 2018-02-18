using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollissionEnter" + gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter" + gameObject.name);
    }
}
