using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j

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
            StartCoroutine(HandleExplosion()); // �R���[�`�����J�n
            Destroy(gameObject); // �����@�̂����ł�����
        }
    }

    IEnumerator HandleExplosion()
    {
        // 3�i�K�̃G�t�F�N�g��0.2�b���\��
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 0.5�b��ɃG�t�F�N�g������
            yield return new WaitForSeconds(0.2f);
        }
    }
}







