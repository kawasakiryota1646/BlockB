using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject friend;
    public static int hp1 = 1; // ������HP
    public GameObject effectPrefab; // ���S���̃G�t�F�N�g�i3�i�K�j
    public AudioSource explosionAudioSource; // �������ʉ��p
    bool inDamage = true; // �_���[�W���t���O
    Bulletstrengthening bulletstrengthening;
    const int FIRSTHP = 1;
    // Start is called before the first frame update
    void Awake()
    {
       
        hp1 = PlayerPrefs.GetInt("Number of Lives", FIRSTHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp1 == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "friend")
        {
            // �Փ˂𖳌��ɂ��鏈��
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
        else if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            GetDamage();
           
        }
    }

    void GetDamage()
    {
        if (inDamage)
        {
            if (inDamage == true)
            {
                hp1--;
            }
            
            if (hp1 > 0)
            {
                inDamage = false;
                Invoke("DamageEnd", 0.5f); // 0.5�b��ɖ��G��Ԃ��I��
                
            }
            else
            {
                Destroy(friend, 0.1f); // �v���C���[������
            }
        }
    }

    void DamageEnd()
    {
        inDamage = true;
        Debug.Log("true");
    }

    void Destroy(GameObject hp)
    {
        // �������ʉ����Đ�
        if (explosionAudioSource != null)
        {
            explosionAudioSource.Play();
        }

        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.1f); // 0.5�b��ɃG�t�F�N�g������

        
    }

    public void ResetHealth()
    {
        hp1 = PlayerPrefs.GetInt("Number of Lives", FIRSTHP); // �ۑ����ꂽ�e�̈З͂�ǂݍ���
    }


}







