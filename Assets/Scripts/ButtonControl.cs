using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject lineControler;
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject otherButton;

    bool mouseOver = false;
    [SerializeField] Material startingColor;
    Color currentColor;



    private void Update()
    {
        currentColor = linePrefab.GetComponent<LineRenderer>().sharedMaterial.color;
        if (currentColor == startingColor.color)
        {
            GetComponent<Button>().interactable = true;
        }

        if (mouseOver)
        {
            lineControler.SetActive(false);
            GetComponent<Button>().interactable = true;

        }
        else
        {
            lineControler.SetActive(true);
            if (startingColor.color != otherButton.GetComponent<ButtonControl>().startingColor.color)
            {
                GetComponent<Button>().interactable = false;
            }
        }

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }



}
