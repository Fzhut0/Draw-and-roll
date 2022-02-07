using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject lineControler;
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject otherButton1;
    [SerializeField] GameObject otherButton2;
    [SerializeField] GameObject reverseButton;

    bool mouseOver = false;
    [SerializeField] Material startingColor;
    Color currentColor;



    private void Update()
    {
        ColorButtonHandler();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }

    void ColorButtonHandler()
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
            if (startingColor.color != otherButton1.GetComponent<ButtonControl>().startingColor.color)
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }


}
