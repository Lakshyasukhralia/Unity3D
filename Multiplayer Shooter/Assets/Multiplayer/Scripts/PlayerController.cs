using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Camera LocalCam;
    public bool CanJump;
    public Rigidbody player;
    
  
  

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        

    }

    // Update is called once per frame
    void Update () {


        

        if (!isLocalPlayer)
        {
            LocalCam.enabled = false;
            CanJump = false;
            return;
           
        }


        Jump();

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        float y = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100.0f;

        transform.Rotate(0, x, 0);
        transform.Rotate(y,0,0);
        transform.Translate(0, 0, z);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdFire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }

    }

  

    

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10.0f;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }

    void Jump()
    {
        if (Input.GetKeyDown("space")&&CanJump==true)
        {
            player.velocity = player.velocity + Vector3.up * 5;
            
            CanJump = false;
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground"|| other.gameObject.tag == "block")
        {
            CanJump = true;
        }
    }


    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }


}
