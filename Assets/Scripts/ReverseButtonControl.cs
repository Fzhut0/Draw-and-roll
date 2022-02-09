using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReverseButtonControl : MonoBehaviour
{


    [SerializeField] Canvas colorCanvas;
    [SerializeField] GameObject lineControl;

    public int undoCount;
    [SerializeField] TextMeshProUGUI undoCountText;


    private void Awake()
    {

        UpdateDisplay();
    }

    public void StopDraw()
    {
        lineControl.GetComponent<LineDrawer>().enabled = false;
    }

    public void StartDraw()
    {
        lineControl.GetComponent<LineDrawer>().enabled = true;
    }

    public void UpdateDisplay()
    {
        undoCountText.text = "You can erase " + undoCount + " more lines";
        if (undoCount == 0)
        {
            undoCountText.text = "You can't erase more lines!";
        }
    }


}
