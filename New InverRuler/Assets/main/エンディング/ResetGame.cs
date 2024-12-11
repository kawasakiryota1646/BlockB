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
        // PlayerPrefs�̃f�[�^��S�č폜
        PlayerPrefs.DeleteAll();

        // �K�v�ɉ����āA����̏�����������ǉ�
        // ��: �����V�[���ɖ߂�
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
    public void Resett()
    {
        // �{�X��|�������Ƃ��L�^
        PlayerPrefs.SetInt("BossDefeated", 0);
        CoinManager.coinCount = 0;
        AttckBullet.damage = 5;
    }
    
}
