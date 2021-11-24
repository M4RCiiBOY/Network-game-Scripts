using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        
        GameObject hit = col.gameObject;
        Combat hitCombat = hit.GetComponent<Combat>();

        if (hitCombat != null)
        {
            hitCombat.TakeDamage(20);
        }
    }
}
