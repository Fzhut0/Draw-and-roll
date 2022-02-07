using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject lineControl;

    GameObject lineControlObj;

    Color lineColor;
    Color playerColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LineColorHandler();
    }


    void LineColorHandler()
    {
        lineColor = linePrefab.GetComponent<LineRenderer>().sharedMaterial.color;
        playerColor = GetComponent<SpriteRenderer>().material.color;
        lineControlObj = GameObject.FindGameObjectWithTag("LineControl");

        if (lineColor != playerColor)
        {
            Time.timeScale = 0f;
            lineControlObj.GetComponent<LineDrawer>().enabled = false;
            lineControl.SetActive(false);
            Debug.Log("wrong color");
        }
        else { return; }

    }


}
