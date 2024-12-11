using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public AudioSource LifeAudioSource; // �_���[�W���ʉ��p
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
            PlayerController player = other.GetComponent<PlayerController>();
            if (LifeAudioSource != null)
            {
                Debug.Log("life");
                LifeAudioSource.Play();
            } 
            if (player != null && PlayerController.hp < 3)
            { 
                
            

                PlayerController.hp++;
                Destroy(gameObject); // �񕜃A�C�e��������
            }
        }
    }
}
