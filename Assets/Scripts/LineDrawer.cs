using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LineDrawer : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject currentLine;

    [SerializeField] LineRenderer lineRender;
    [SerializeField] EdgeCollider2D edgeCollider;

    [SerializeField] List<Vector2> fingerPositions;

    [SerializeField] Material color1;
    [SerializeField] Material color2;

    [SerializeField] int maxLines = 6;

    [SerializeField] List<GameObject> lineAmount = new List<GameObject>();


    private void Awake()
    {
        Time.timeScale = 1f;
        if (!GameObject.FindGameObjectWithTag("UI").activeSelf)
        {
            GameObject.FindGameObjectWithTag("UI").SetActive(true);
        }
    }

    void Update()
    {

        if (lineAmount.Count <= maxLines && Input.GetMouseButtonDown(0))
        {
            DrawLine();
        }
        if (Input.GetMouseButton(0) && lineAmount.Count <= maxLines)
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > Mathf.NegativeInfinity)
            {
                LineUpdate(tempFingerPos);
            }
        }
    }



    void DrawLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRender = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRender.SetPosition(0, fingerPositions[0]);
        lineRender.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        lineAmount.Add(currentLine);


    }

    void LineUpdate(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRender.positionCount++;
        lineRender.SetPosition(lineRender.positionCount - 1, newFingerPos);

        edgeCollider.points = fingerPositions.ToArray();


    }


    public void LineColorChangeRed()
    {
        linePrefab.GetComponent<LineRenderer>().material = color1;
    }

    public void LineColorChangeBlue()
    {
        linePrefab.GetComponent<LineRenderer>().material = color2;
    }



}


