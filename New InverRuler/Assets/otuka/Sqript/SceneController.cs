using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
    public PlayerController playerController;
    public void Load()
    {
        ResetCurrentScene();
        SceneManager.LoadScene(sceneName);
    }

    void ResetCurrentScene()
    {
        
        playerController.ResetPlayerHealth();
        

        // 他のリセット処理もここに追加
    }
}
