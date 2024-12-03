using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEKIHP1 : MonoBehaviour
{
    public int maxHealth = 100;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j

    public GameObject gameClearText; // GAME�N���A�̃e�L�X�g
    public GameObject NEXTButton; // GAME�N���A�̃e�L�X�g
    public BGMController bgmController; // BGM�R���g���[���[
    public GameObject coinPrefab; // �R�C���̃v���n�u
    public int coinCount = 10; // ��������R�C���̐�
    public int coinsToAdd = 10; // �ǉ�����R�C���̐�
    public AudioSource damageAudioSource; // �_���[�W���ʉ��p
    public AudioSource explosionAudioSource; // �������ʉ��p
    public float currentHealth;
    public SpriteRenderer spriteRenderer2;
    public Sprite phase1Sprite;
    public Sprite phase2Sprite;
    public Sprite phase3Sprite;
    public Sprite phase4Sprite;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // �{�^���ƃe�L�X�g���\���ɂ���
     
        gameClearText.SetActive(false);
        NEXTButton.SetActive(false);
    }

    void UpdateBossAppearance()
    {
        if (currentHealth <= 525)
        {
            spriteRenderer.sprite = phase2Sprite; // �t�F�[�Y2�ɕύX
        }
        if (currentHealth <= 350)
        {
            spriteRenderer.sprite = phase3Sprite; // �t�F�[�Y3�ɕύX
        }
        if (currentHealth <= 175)
        {
            spriteRenderer.sprite = phase4Sprite; // �t�F�[�Y4�ɕύX
        }
    }


    public void TakeDamage(float damage)
    {
        UpdateBossAppearance();

        currentHealth -= damage;
        // �_���[�W���ʉ����Đ�
        if (damageAudioSource != null)
        {
            damageAudioSource.Play();
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
           
        }
        StartCoroutine(Flash());
    }

    IEnumerator Die()
    {
        yield return StartCoroutine(HandleExplosion()); // �R���[�`�����J�n
        Debug.Log("Boss died");

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // �V�[�����̂��ׂĂ� "EnemyBullet" �^�O���t�����I�u�W�F�N�g�����ł�����
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in enemyBullets)
        {
            Destroy(bullet);
        }
        Invoke("changeEnd", 0.5f);
        Destroy(gameObject); // �G������

        // �{�^���ƃe�L�X�g��\������
        NEXTButton.SetActive(true);
        gameClearText.SetActive(true);

        // �Q�[���N���ABGM���Đ�����
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // �R�C���𐶐�����
        SpawnCoins();

        // �R�C����ǉ�����
        CoinManager.instance.AddCoins(coinsToAdd);
        Debug.Log("coin");

        
    }
    

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // �_�ŐF
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            StartCoroutine(HideCoinAfterDelay(coin, 2f)); // 2�b��ɃR�C�����\���ɂ���
        }
    }

    IEnumerator HideCoinAfterDelay(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        coin.SetActive(false); // �R�C�����\���ɂ���
    }

    IEnumerator HandleExplosion()
    {
        // 3�i�K�̃G�t�F�N�g��0.2�b���\��
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 1�b��ɃG�t�F�N�g������
            yield return new WaitForSeconds(0.2f);
        }
    }
}
