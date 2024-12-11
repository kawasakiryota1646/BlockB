using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    public int ammoAmount = 5;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<BulletController>().AddBullets(ammoAmount);
            FindObjectOfType<Healitem>().OnAmmoCollected();
            Destroy(gameObject);
        }
    }
}
