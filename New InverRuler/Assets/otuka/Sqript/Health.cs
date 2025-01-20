using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public AudioSource LifeAudioSource; // �_���[�W���ʉ��p
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
             PlayerController player = other.GetComponent<PlayerController>();
            
            if (player != null && PlayerController.hp < 3)
            { 
               
            if (LifeAudioSource != null)
            {
                Debug.Log("life");
                LifeAudioSource.Play();
            } 
                PlayerController.hp++;
            }
            Destroy(gameObject);
        }
    }
}
