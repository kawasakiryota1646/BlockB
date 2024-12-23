using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public AudioSource click;

    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public GameObject stage1Options; // Stage1のオプションボタンを含むGameObject
    public GameObject stage2Options; // Stage2のオプションボタンを含むGameObject
    public GameObject stage3Options; // Stage3のオプションボタンを含むGameObject


    void Start()
    {
    stage1Options.SetActive(false); // ノーマルステージのボタンを表示
    stage2Options.SetActive(false); // ノーマルステージのボタンを表示
    stage3Options.SetActive(false); // ノーマルステージのボタンを表示
   
    }
    
    public void OnStage1ButtonClick()
    {
        
        if (click != null)
        {
            click.Play();
        }
        stage1Options.SetActive(true); // Stage1のオプションを表示
        stage2Options.SetActive(false); // Stage2のオプションを非表示
        stage3Options.SetActive(false); // Stage3のオプションを非表示

    }

    public void OnStage2ButtonClick()
    {
        if (click != null)
        {
            click.Play();
        }
        stage1Options.SetActive(false); // Stage1のオプションを非表示
        stage2Options.SetActive(true); // Stage2のオプションを表示
        stage3Options.SetActive(false); // Stage3のオプションを非表示
    
    }

    public void OnStage3ButtonClick()
    {
        if (click != null)
        {
            click.Play();
        }
        stage1Options.SetActive(false); // Stage1のオプションを非表示
        stage2Options.SetActive(false); // Stage2のオプションを非表示
        stage3Options.SetActive(true); // Stage3のオプションを表示
  
    }
 

}


