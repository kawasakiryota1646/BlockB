using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Japan_normal_HP : MonoBehaviour
{
    public int maxHealth = 100;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // 死亡時のエフェクト（3段階）
    public GameObject retryButton; // リトライボタン
    public GameObject nextButton; // 次へボタン
    public GameObject gameClearText; // GAMEクリアのテキスト
    public BGMController bgmController; // BGMコントローラー
    public GameObject coinPrefab; // コインのプレハブ
    public int coinCount = 10; // 生成するコインの数
    public int coinsToAdd = 10; // 追加するコインの数
    public AudioSource damageAudioSource; // ダメージ効果音用
    public AudioSource explosionAudioSource; // 爆発効果音用
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
        // ボタンとテキストを非表示にする
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        gameClearText.SetActive(false);
    }

    void UpdateBossAppearance()
    {
        UpdateAmmoText();
        if (currentHealth <= 75)
        {
            spriteRenderer.sprite = phase2Sprite; // フェーズ2に変更
        }
        if (currentHealth <= 50)
        {
            spriteRenderer.sprite = phase3Sprite; // フェーズ3に変更
        }
        if (currentHealth <= 25)
        {
            spriteRenderer.sprite = phase4Sprite; // フェーズ4に変更
        }
        UpdateAmmoText();
    }


    public void TakeDamage(float damage)
    {
        
        UpdateBossAppearance();

        currentHealth -= damage;
        UpdateAmmoText();
        // ダメージ効果音を再生
        if (damageAudioSource != null)
        {
            damageAudioSource.Play();
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());

        }
        StartCoroutine(Flash());
        UpdateAmmoText();
    }

    IEnumerator Die()
    {
        currentHealth = 0;
        UpdateAmmoText();
        yield return StartCoroutine(HandleExplosion()); // コルーチンを開始
        Debug.Log("Boss died");
        
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // シーン内のすべての "EnemyBullet" タグが付いたオブジェクトを消滅させる
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in enemyBullets)
        {
            Destroy(bullet);
        }

        Destroy(gameObject); // 敵を消す




        // ボタンとテキストを表示する
        retryButton.SetActive(true);
        nextButton.SetActive(true);
        gameClearText.SetActive(true);

        // ゲームクリアBGMを再生する
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // コインを生成する
        SpawnCoins();

        // コインを追加する
        CoinManager.instance.AddCoins(coinsToAdd);
    }

    private IEnumerator Flash()
    {
       
        spriteRenderer.color = Color.red; // 点滅色
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        UpdateAmmoText();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            StartCoroutine(HideCoinAfterDelay(coin, 2f)); // 2秒後にコインを非表示にする
        }
    }

    IEnumerator HideCoinAfterDelay(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(coin);
    }

    IEnumerator HandleExplosion()
    {
        // 3段階のエフェクトを0.2秒ずつ表示
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 1秒後にエフェクトを消去
            yield return new WaitForSeconds(0.2f);
        }
        UpdateAmmoText();
    }
    void UpdateAmmoText()
    {
        ammoText.text = "残りHP: " + currentHealth;
    }

}
