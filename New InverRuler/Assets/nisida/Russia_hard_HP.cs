using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Russia_hard_HP : MonoBehaviour
{
    public int maxHealth = 100;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.1f;
    public GameObject[] deathEffects; // 死亡時のエフェクト（3段階）

    public GameObject gameClearText; // GAMEクリアのテキスト
    public GameObject NEXTButton;
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
    public GameObject gameOverUI; // ゲームオーバー時のUI
    public GameObject retryUI; // ゲームオーバー時のUI
    public GameObject StageSelectUI; // ゲームオーバー時のUI
    void Start()
    {

        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        UpdateAmmoText();
        // ボタンとテキストを非表示にする
        NEXTButton.SetActive(false);
        gameClearText.SetActive(false);
    }

    void UpdateBossAppearance()
    {
        UpdateAmmoText();
        if (currentHealth <= 1500)
        {
            spriteRenderer.sprite = phase2Sprite; // フェーズ2に変更
        }
        if (currentHealth <= 1000)
        {
            spriteRenderer.sprite = phase3Sprite; // フェーズ3に変更
        }
        if (currentHealth <= 500)
        {
            spriteRenderer.sprite = phase4Sprite; // フェーズ4に変更
        }
        UpdateAmmoText();
    }


    public void TakeDamage(float damage)
    {
        UpdateAmmoText();
        UpdateBossAppearance();

        currentHealth -= damage;
        // ダメージ効果音を再生
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
        yield return StartCoroutine(HandleExplosion()); // コルーチンを開始
        Debug.Log("Boss died");

       

        // シーン内のすべての "EnemyBullet" タグが付いたオブジェクトを消滅させる
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in enemyBullets)
        {
            Destroy(bullet);
        }

        Destroy(gameObject); // 敵を消す

        // ボタンとテキストを表示する
        NEXTButton.SetActive(true);
        gameClearText.SetActive(true);



        if (NEXTButton == true)
        {
            // ゲームオーバーUIを表示
            gameOverUI.SetActive(false);
            retryUI.SetActive(false);
            StageSelectUI.SetActive(false);
        }
        // ゲームクリアBGMを再生する
        if (bgmController != null)
        {
            bgmController.PlayGameClearBGM();
        }

        // コインを生成する
        SpawnCoins();

        // コインを追加する前に前回のコイン数を更新
        CoinManager.instance.UpdatePreviousCoinCount();

        // コインを追加する
        CoinManager.instance.AddCoins(coinsToAdd);


    }

    private IEnumerator Flash()
    {
        UpdateAmmoText();
        spriteRenderer.color = Color.red; // 点滅色
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
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
        coin.SetActive(false); // コインを非表示にする
    }

    IEnumerator HandleExplosion()
    {
        UpdateAmmoText();
        // 3段階のエフェクトを0.2秒ずつ表示
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); // 1秒後にエフェクトを消去
            yield return new WaitForSeconds(0.2f);
        }
    }

    void UpdateAmmoText()
    {
        ammoText.text = "残りHP: " + currentHealth;
    }
}
