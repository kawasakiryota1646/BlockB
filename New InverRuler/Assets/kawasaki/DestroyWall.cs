using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�e�������ǂ̃X�N���v�g
public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }

        

        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
        }
    }

}


