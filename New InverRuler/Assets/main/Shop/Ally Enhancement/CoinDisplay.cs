using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �V�[�������擾���邽�߂ɕK�v

/// <summary>
/// ���ݏ������Ă���R�C����\������X�N���v�g
/// </summary>
public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public Transform coinTarget; // �R�C���̖ړI�n

    private void Update()
    {
        coinText.text = CoinManager.coinCount.ToString();
    }
    
}

