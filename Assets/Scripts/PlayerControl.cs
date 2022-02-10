using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject lineControl;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] float timeToLoad = 10f;
    [SerializeField] GameObject timerText;
    [SerializeField] Color removeColor;


    GameObject lineControlObj;

    [SerializeField] float remainingTime;

    Color playerColor;



    private void Update()
    {
        if (lineControl.activeSelf)
        {
            PlayerLoadTimer();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        playerColor = GetComponent<SpriteRenderer>().material.color;
        lineControlObj = GameObject.FindGameObjectWithTag("LineControl");

        if (GetComponentInParent<Rigidbody2D>().bodyType == RigidbodyType2D.Static || collision.collider.GetComponentInParent<LineRenderer>().sharedMaterial.color == removeColor) { return; }


        if (collision.collider.GetComponentInParent<LineRenderer>() && collision.collider.GetComponentInParent<LineRenderer>().sharedMaterial.color != playerColor)
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
        float remainingTime = Mathf.Round(timeToLoad - Time.timeSinceLevelLoad);
        if (remainingTime >= 0)
        {
            timerText.GetComponent<TextMesh>().text = remainingTime.ToString();
        }
        else
        {
            timerText.SetActive(false);
        }

        if (Time.timeSinceLevelLoad >= timeToLoad)
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }



    }


}
