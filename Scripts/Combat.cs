using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{

    public const int maxHealth = 100;
    public bool DestroyONdeath;
    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        health -= amount;
        if (health <= 0)
        {
            if (DestroyONdeath)
            {
                Destroy(gameObject);
            }
            health = maxHealth;
            
            CmdRespawn();
        }
    }


    [Command]
    void CmdRespawn()
    { 
            transform.position = GetComponent<PlayerController>().spawn; 
    }
}
