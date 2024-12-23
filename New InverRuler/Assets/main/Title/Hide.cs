using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public GameObject image;
    public GameObject text;
    public GameObject Button1;
    public GameObject Button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Load()
    {
        image.SetActive(false);
        Button1.SetActive(false);
        text.SetActive(false);
        Button2.SetActive(false);
    }
}
