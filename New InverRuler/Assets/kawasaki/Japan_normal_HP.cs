using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Japan_normal_HP : MonoBehaviour
{
    public PlayerController playerController;
    public int maxHealth = 100;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j
    public GameObject retryButton; // ���g���C�{�^��
    public GameObject nextButton; // ���փ{�^��
    public GameObject gameClearText; // GAME�N���A�̃e�L�X�g
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
    public GameObject gameOverUI; // �Q�[���I�[�o�[����UI
    public GameObject retryUI; // �Q�[���I�[�o�[����UI
    public GameObject StageSelectUI; // �Q�[���I�[�o�[����UI
    void Start()
    {
        
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        UpdateAmmoText();
        // �{�^���ƃe�L�X�g���\���ɂ���
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);
    }

    void UpdateBossAppearance()
    {
        UpdateAmmoText();
        if (currentHealth <= 74)
        {
            spriteRenderer.sprite = phase2Sprite; // �t�F�[�Y2�ɕύX
        }
        if (currentHealth <= 49)
        {
            spriteRenderer.sprite = phase3Sprite; // �t�F�[�Y3�ɕύX
        }
        if (currentHealth <= 24)
        {
            spriteRenderer.sprite = phase4Sprite; // �t�F�[�Y4�ɕύX
        }
        UpdateAmmoText();
    }


    public void TakeDamage(float damage)
    {
        
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
        
       
       

        // �V�[�����̂��ׂĂ� "EnemyBullet" �^�O���t�����I�u�W�F�N�g�����ł�����
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in enemyBullets)
        {
            Destroy(bullet);
        }

        Destroy(gameObject); // �G������


        
        
         // �{�^���ƃe�L�X�g��\������
         retryButton.SetActive(true);
         nextButton.SetActive(true);
         gameClearText.SetActive(true);
        if(retryButton == true)
        {
            gameOverUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
            retryUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
            StageSelectUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        }
      


        // �Q�[���N���ABGM���Đ�����
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // �R�C���𐶐�����
        SpawnCoins();

        // �R�C����ǉ�����O�ɑO��̃R�C�������X�V
        CoinManager.instance.UpdatePreviousCoinCount();

        // �R�C����ǉ�����
        CoinManager.instance.AddCoins(coinsToAdd);
    }

    private IEnumerator Flash()
    {
       
        spriteRenderer.color = Color.red; // �_�ŐF
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        UpdateAmmoText();
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
        Destroy(coin);
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
