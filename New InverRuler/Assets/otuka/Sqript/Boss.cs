using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static TEKIHP tekihp; // PlayerControllerスクリプトを参照
    private TEKIHP bossHealth;      //ボスの体力

    void Update()
    {
        
        bossHealth = GetComponentInParent<TEKIHP>(); // 親オブジェクトからBossHealthを取得

        if (bossHealth.currentHealth == 0)
        {
            ChangeScene();
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("エンディング"); // 次のシーン名を指定
    }

    
}

