using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStageButton : MonoBehaviour
{
    public GameObject hardStageButton;

    void Start()
    {
        // �{�X��|�������ǂ������m�F
        if (PlayerPrefs.GetInt("BossDefeated", 0) == 1)
        {
            // �{�^����\��
            hardStageButton.SetActive(true);
        }
        else
        {
            // �{�^�����\��
            hardStageButton.SetActive(false);
        }
    }
}
