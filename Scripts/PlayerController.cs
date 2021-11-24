using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour {
    
    private float speed = 5f;
    
    private Vector3 velo = Vector3.zero;
    private Rigidbody rb;
    public GameObject sword;
    public Animator anim;
    public Vector3 spawn;
    public float rotSpeed=100;
    

  

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        sword = GameObject.FindGameObjectWithTag("Sword");
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isLocalPlayer)
        {
            return;
        }

        // Input
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        // Calc movement
        Vector3 moveHor = transform.right * xMove;
        Vector3 moveVer = transform.forward * zMove;

        // Final movement
        velo = (moveHor + moveVer).normalized * speed;
     

    }


    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float xRot = Input.GetAxisRaw("Mouse X");
     
            CmdMovement(velo,xRot);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdAttack();

        }
    }

    
    [Command(channel =2)]
    void CmdMovement(Vector3 mov,float rot)
    {

        if (mov != Vector3.zero)
        {
            rb.MovePosition(rb.position + mov * Time.fixedDeltaTime);
        }
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y + rot*rotSpeed*Time.fixedDeltaTime, gameObject.transform.rotation.eulerAngles.z);
            
        
    }

    [Command]
    void CmdAttack()
    {

        RpcAnimation();
        
    }

    [ClientRpc]

    void RpcAnimation()
    {
        anim.Play("swingSword");        
    }
   
}
