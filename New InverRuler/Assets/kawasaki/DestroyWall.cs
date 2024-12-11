using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "FriendBullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
        }
    }

}


