using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {

    private GameObject player;
    public float offset;
    bool cam=false;



    // Update is called once per frame
    void Update()
    {

        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].isLocalPlayer)
            {
                player = players[i].gameObject;
                cam = true;

            }
        }
    }


    void FixedUpdate()
    {
        CameraMove();
    }


    void CameraMove() // Camera Rotatioin
    {
        if (cam)
        {
             gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+offset, player.transform.position.z);
             gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
             gameObject.transform.position -= player.transform.forward * offset;
        }
     }
}
