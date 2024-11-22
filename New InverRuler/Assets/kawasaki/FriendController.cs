using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject[] deathEffects; // 死亡時のエフェクト（3段階）
    public AudioSource explosionAudioSource; // 爆発効果音用
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            StartCoroutine(HandleExplosion()); // コルーチンを開始
            Destroy(gameObject); // 味方機体を消滅させる
        }
    }

    IEnumerator HandleExplosion()
    {
        // 3段階のエフェクトを0.2秒ずつ表示
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 0.5秒後にエフェクトを消去
            yield return new WaitForSeconds(0.2f);
        }
    }
}







