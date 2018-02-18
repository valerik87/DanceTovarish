﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollissionEnter" + gameObject.name);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter" + gameObject.name);
    }
}
