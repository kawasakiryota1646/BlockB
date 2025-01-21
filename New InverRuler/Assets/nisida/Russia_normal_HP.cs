using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Russia_normal_HP : MonoBehaviour
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
    public Text ammoText;
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        UpdateAmmoText();
        // �{�^���ƃe�L�X�g���\���ɂ���

        gameClearText.SetActive(false);
        NEXTButton.SetActive(false);
    }

    void UpdateBossAppearance()
    {
        UpdateAmmoText();
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
        UpdateAmmoText();
    }


    public void TakeDamage(float damage)
    {
        UpdateAmmoText();
        UpdateBossAppearance();

        currentHealth -= damage;
        UpdateAmmoText();
        // �_���[�W���ʉ����Đ�
        if (damageAudioSource != null)
        {
            damageAudioSource.Play();
        }
        if (currentHealth <= 0)
        {
            if (explosionAudioSource != null)
            {
                explosionAudioSource.Play();
            }
            StartCoroutine(Die());
           
        }
        StartCoroutine(Flash());
        UpdateAmmoText();
    }

    IEnumerator Die()
    {
        currentHealth = 0;
        UpdateAmmoText();
        yield return StartCoroutine(HandleExplosion()); // �R���[�`�����J�n
        Debug.Log("Boss died");

        // �{�X��|�������Ƃ��L�^
        PlayerPrefs.SetInt("BossDefeated", 1);

        

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

        // �R�C����ǉ�����O�ɑO��̃R�C�������X�V
        CoinManager.instance.UpdatePreviousCoinCount();


    }
    

    private IEnumerator Flash()
    {
        UpdateAmmoText();
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
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "�c��HP: " + currentHealth;
    }
}
