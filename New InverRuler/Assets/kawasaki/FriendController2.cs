using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2人目味方機体の弾、HPを管理するスクリプト
/// </summary>
public class FriendController2 : MonoBehaviour
{
    public GameObject friend;
    public static int hp2 = 1; // 味方のHP
    public GameObject effectPrefab; // 死亡時のエフェクト（3段階）
    public AudioSource explosionAudioSource; // 爆発効果音用
    bool inDamage = true; // ダメージ中フラグ
    Bulletstrengthening bulletstrengthening;
    const int FIRSTHP = 1;
    // Start is called before the first frame update
    void Awake()
    {
       
        hp2 = PlayerPrefs.GetInt("Number of Lives", FIRSTHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp2 == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "friend")
        {
            // 衝突を無効にする処理
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
                hp2--;
            }

            if (hp2 > 0)
            {
                inDamage = false;
                Invoke("DamageEnd", 0.5f); // 0.5秒後に無敵状態を終了

            }
            else
            {
                Destroy(friend, 0.1f); // プレイヤーを消す
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
        // 爆発効果音を再生
        if (explosionAudioSource != null)
        {
            explosionAudioSource.Play();
        }

        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.1f); // 0.5秒後にエフェクトを消去


    }

    public void ResetHealth2()
    {
        hp2 = PlayerPrefs.GetInt("Number of Lives", FIRSTHP); // 保存された弾の威力を読み込む
    }


}