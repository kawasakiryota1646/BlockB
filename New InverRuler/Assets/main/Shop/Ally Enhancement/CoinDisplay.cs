using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �V�[�������擾���邽�߂ɕK�v

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public Transform coinTarget; // �R�C���̖ړI�n

    private void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Ally Enhancement"||currentSceneName == "Strengthen your ship") // ����̃V�[�������w��
        {
            coinText.text = "0";
            // ����̃V�[���ł͑����A�j���[�V�������X�L�b�v���č��v������\��

            coinText.text = CoinManager.coinCount.ToString();
        }
        else
        {
            // ����ȊO�̃V�[���ł͑����A�j���[�V���������s
            StartCoroutine(AddCoinsWithAnimation(CoinManager.previousCoinCount, CoinManager.coinCount));
        }
    }

  

    private IEnumerator AddCoinsWithAnimation(int startCoins, int endCoins)
    {
        int displayedCoins = startCoins;
        while (displayedCoins < endCoins)
        {
            displayedCoins++;
            coinText.text = displayedCoins.ToString();
            yield return new WaitForSeconds(0.09f); // �A�j���[�V�����̑��x�𒲐�
        }
    }

 
}

