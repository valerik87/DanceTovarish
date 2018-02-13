using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float fVelocityVertical;
    public float fVelocityHorizontal;

    public float fBulletVelocity;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    /*
    // Use this for initialization
    void Start () {
		
	}*/

    // Update is called once per frame
    void Update () {
        //Update only local
        if(!isLocalPlayer)
        {
            return;
        }

        float MovementVertical = 0;
        float MovementHorizontal = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MovementVertical = Time.deltaTime * fVelocityVertical;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovementVertical = -Time.deltaTime * fVelocityVertical;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovementHorizontal = Time.deltaTime * fVelocityHorizontal;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovementHorizontal = -Time.deltaTime * fVelocityHorizontal;
        }

        transform.Translate(MovementHorizontal, MovementVertical, 0f);
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate<GameObject>(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * (fBulletVelocity) ;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
