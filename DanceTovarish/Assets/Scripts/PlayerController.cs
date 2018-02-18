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
            CmdFire();
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

        //Points: Player and Mouse coord
        Vector2 PlayerPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 MousePointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("PlayerPosition: " + PlayerPosition);
        //Debug.Log("MousePointerPosition: " + MousePointerPosition);

        //Direction: PlayerUpDirection and PlayerMousePointerDirection 
        Vector2 heading = MousePointerPosition - PlayerPosition;
        Vector2 MousePointDirection = heading / heading.magnitude;
        //Debug.Log("MousePointDirection: " + MousePointDirection);

        Vector2 PlayerUpDirection = new Vector2(this.transform.up.x, this.transform.up.y);
        //Debug.Log("PlayerUpDirection: " + PlayerUpDirection);

        //Debug.DrawRay(this.transform.position, PlayerUpDirection, Color.green);
        Debug.DrawRay(this.transform.position, MousePointDirection, Color.red);

        float angle = Vector2.SignedAngle(PlayerUpDirection, MousePointDirection);
        //Debug.Log("angle: " + angle);

        transform.Rotate(0f,0f,angle);
        transform.Translate(MovementHorizontal, MovementVertical, 0f);

    }

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate<GameObject>(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * (fBulletVelocity) ;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
