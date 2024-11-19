using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipWithMultipleElements : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string tooltipText1;
    [SerializeField] private string tooltipText2;
    [SerializeField] private Text tooltipUI1;
    [SerializeField] private Text tooltipUI2;
    [SerializeField] private Image tooltipImage1;
    [SerializeField] private Image tooltipImage2;
    [SerializeField] private GameObject[] elementsToHide;

    private void Start()
    {
        // èâä˙èÛë‘Ç≈îÒï\é¶Ç…ê›íË
        tooltipUI1.gameObject.SetActive(false);
        tooltipUI2.gameObject.SetActive(false);
        tooltipImage1.gameObject.SetActive(false);
        tooltipImage2.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipUI1.text = tooltipText1;
        tooltipUI2.text = tooltipText2;
        tooltipUI1.gameObject.SetActive(true);
        tooltipUI2.gameObject.SetActive(true);
        tooltipImage1.gameObject.SetActive(true);
        tooltipImage2.gameObject.SetActive(true);
        SetElementsActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipUI1.gameObject.SetActive(false);
        tooltipUI2.gameObject.SetActive(false);
        tooltipImage1.gameObject.SetActive(false);
        tooltipImage2.gameObject.SetActive(false);
        SetElementsActive(true);
    }

    private void SetElementsActive(bool isActive)
    {
        foreach (GameObject element in elementsToHide)
        {
            element.SetActive(isActive);
        }
    }
}


