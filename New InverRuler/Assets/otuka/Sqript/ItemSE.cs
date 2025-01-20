using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ItemSE : MonoBehaviour
{
    public AudioSource itemSE;
    public AudioSource itemSE2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            // è’ìÀÇñ≥å¯Ç…Ç∑ÇÈèàóù
            Physics2D.IgnoreCollision(other.composite, GetComponent<Collider2D>());
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            if (itemSE != null)
            {
                itemSE.Play();
            }
        }
        if (other.gameObject.CompareTag("Heal"))
        {
            if (itemSE2 != null)
            {
                itemSE2.Play();
            }
        }
    }
}
