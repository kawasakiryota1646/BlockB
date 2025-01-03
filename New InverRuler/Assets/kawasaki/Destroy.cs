using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")//プレイヤーの弾を消す
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "FriendBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
