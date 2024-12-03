using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }

        if (other.gameObject.tag == "friend")
        {
            Destroy(gameObject);

        }



    }


}
