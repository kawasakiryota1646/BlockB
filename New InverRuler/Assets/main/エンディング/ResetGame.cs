using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public Button resetButton;
    public CoinManager coinManager;
    void Start()
    {
        resetButton.onClick.AddListener(ResetAllScenes);
    }

    void ResetAllScenes()
    {
        Resett();
        // PlayerPrefsのデータを全て削除
        PlayerPrefs.DeleteAll();

        // 必要に応じて、特定の初期化処理を追加
        // 例: 初期シーンに戻る
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
    public void Resett()
    {
        // ボスを倒したことを記録
        PlayerPrefs.SetInt("BossDefeated", 0);
        CoinManager.coinCount = 0;
        AttckBullet.damage = 5;
    }
    
}
