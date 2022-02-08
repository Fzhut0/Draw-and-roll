using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject lineControl;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] float timeToLoad = 10f;

    GameObject lineControlObj;

    Color lineColor;
    Color playerColor;



    private void Update()
    {
        PlayerLoadTimer();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        lineColor = linePrefab.GetComponent<LineRenderer>().sharedMaterial.color;
        playerColor = GetComponent<SpriteRenderer>().material.color;
        lineControlObj = GameObject.FindGameObjectWithTag("LineControl");


        if (collision.collider.GetComponentInParent<LineRenderer>().sharedMaterial.color != playerColor)
        {
            LineColorHandler();
        }
        else { return; }
    }


    void LineColorHandler()
    {

        Time.timeScale = 0f;
        lineControlObj.GetComponent<LineDrawer>().enabled = false;
        lineControl.SetActive(false);
        GameObject.FindGameObjectWithTag("UI").SetActive(false);
        gameOverCanvas.SetActive(true);


    }

    void PlayerLoadTimer()
    {



        if (Time.timeSinceLevelLoad > timeToLoad)
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }



    }


}
