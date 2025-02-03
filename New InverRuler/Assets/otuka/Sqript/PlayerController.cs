using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIを使用するために必要
/// <summary>
/// プレイヤーのHPを管理するスクリプト
/// </summary>
public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f; //移動スピード
    float axisH; //横軸
    float axisV; //縦軸
    Rigidbody2D rbody; //Rigidbody2D
                       //ダメージ対応

    public static int hp = 3; //プレイヤーのHP
    public static string gameState; //ゲームの状態
    bool inDamage = true; //ダメージ中フラグ
    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.5f;
    public GameObject[] deathEffects; // 死亡時のエフェクト（3段階）
    public GameObject gameOverUI; // ゲームオーバー時のUI
    public GameObject retryUI; // ゲームオーバー時のUI
    public GameObject StageSelectUI; // ゲームオーバー時のUI
    public GameObject gameStartText; // GAME STARTのテキスト
    public BGMController bgmController; // BGMコントローラー
    public AudioSource damageAudioSource; // ダメージ効果音用
    public AudioSource explosionAudioSource; // 爆発効果音用
    public GameObject healthPickupPrefab; // 回復アイテムのプレハブ
    public Transform cameraTransform; // カメラのTransform
    public float spawnRangeX = 10f; // X軸方向の出現範囲
    public float spawnHeight = 4f; // Y軸方向の出現高さ
    public GameObject retryButton; // リトライボタン
    public GameObject nextButton; // 次へボタン
    public GameObject gameClearText; // GAMEクリアのテキスト
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // FPSを60に固定
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        rbody = GetComponent<Rigidbody2D>(); //Rigidbody2Dを得る
        gameState = "playing"; //ゲームの状態をプレイ中にする
        gameOverUI.SetActive(false); // ゲームオーバーUIを非表示にする
        retryUI.SetActive(false); // ゲームオーバーUIを非表示にする
        StageSelectUI.SetActive(false); // ゲームオーバーUIを非表示にする
        StartCoroutine(SpawnHealthPickups()); // 回復アイテムを出現させるコルーチンを開始
        // GAME STARTテキストを表示するコルーチンを開始
        StartCoroutine(ShowGameStartText());
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal"); //左右キー入力
        axisV = Input.GetAxisRaw("Vertical"); //上下キー入力

        
        //hpが０ならGameOver関数に飛ぶ
        if (hp <= 0)
        {
            StartCoroutine(GameOver());
        }
        
    }

    void FixedUpdate()
    {
        //移動速度を更新する
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

    //接触
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemyタグ　EnemyBulletタグの接触を感知
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage();//GetDamage関数に移動
        }
       
    }



    //ダメージ
    void GetDamage()
    {
        if (gameState == "playing")//gameStateがplayingなら中の処理を実行
        {
            if (inDamage == true)//trueならhpを-1　falseならhpは変動しない
            {
                hp--;
            }

            if (hp > 0)//hpが0以上なら中の処理を実行
            {
                // ダメージ効果音を再生
                if (damageAudioSource != null)
                {
                    damageAudioSource.Play();
                }
                //ダメージフラグON
                inDamage = false;
                Debug.Log("false");
                StartCoroutine(Flash());
                Invoke("DamageEnd", 0.5f); // 0.5秒後に無敵状態を終了
                //// hpが3未満の場合、回復アイテムを出現させる
                //if (hp < 3)
                //{
                //    Vector3 spawnPosition = new Vector3(cameraTransform.position.x, cameraTransform.position.y + 5, 0);
                //    Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
                //}
            }
        }
    }

    void DamageEnd()
    {
        
        inDamage = true;
        Debug.Log("true");
    }

    IEnumerator SpawnHealthPickups()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f); // 5秒待つ

            if (hp < 3)
            {
                float randomX = Random.Range(cameraTransform.position.x - spawnRangeX, cameraTransform.position.x + spawnRangeX);
                float spawnY = cameraTransform.position.y + spawnHeight;
                Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
                Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    //ゲームオーバー
    IEnumerator GameOver()
    {
        gameState = "gameover";
        // プレイヤーの操作を無効にする
        GetComponent<PlayerController>().enabled = false;
        //Heartタグの付いているオブジェクトを全て削除
        GameObject[] healthPickups = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject pickup in healthPickups)
        {
            Destroy(pickup);
        }
        // 爆発効果音を再生
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 3段階のエフェクトを0.2秒ずつ表示
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f); // 0.5秒後にエフェクトを消去
            yield return new WaitForSeconds(0.2f);
        }

        Destroy(player, 0.1f); // プレイヤーを消す

        
        // ゲームオーバーUIを表示
        gameOverUI.SetActive(true);
        retryUI.SetActive(true);
        StageSelectUI.SetActive(true);


        if(gameOverUI == true)
        {
            // ボタンとテキストを非表示にする
            retryButton.SetActive(false);
            nextButton.SetActive(false);
            gameClearText.SetActive(false);
        }



        // ゲームオーバーBGMを再生する
        if (bgmController != null)
        {
            bgmController.PlayGameOverBGM();
        }
    }

    // プレイヤーのライフをリセットするメソッド
    public void ResetPlayerHealth()
    {
        hp = 3; // 初期値に戻す
    }

    private IEnumerator Flash()
    {
        while (!inDamage)
        {
            spriteRenderer.color = Color.red; // 点滅色
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    // GAME STARTテキストを表示し、ゲームを停止するコルーチン
    IEnumerator ShowGameStartText()
    {
        gameStartText.SetActive(true); // テキストを表示
        Time.timeScale = 0f; // ゲームを停止
        PlayerController.gameState = "paused"; // ゲームを停止状態に設定
        yield return new WaitForSecondsRealtime(3f);
        gameStartText.SetActive(false); // テキストを非表示
        Time.timeScale = 1f; // ゲームを再開
        PlayerController.gameState = "playing"; // ゲームをプレイ状態に設定
    }
}








