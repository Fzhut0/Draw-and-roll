using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseButtonControl : MonoBehaviour
{


    [SerializeField] Canvas colorCanvas;
    [SerializeField] GameObject lineControl;



    public void StopDraw()
    {
        lineControl.GetComponent<LineDrawer>().enabled = false;
    }

    public void StartDraw()
    {
        lineControl.GetComponent<LineDrawer>().enabled = true;
    }



}
