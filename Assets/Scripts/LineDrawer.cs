using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



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

    public List<GameObject> lineAmount = new List<GameObject>();

    [SerializeField] int maxLineSize = 50;

    [SerializeField] float maxLineLength = 20;

    [SerializeField] TextMeshProUGUI maxLinesText;

    [SerializeField] int availableLines;

    [SerializeField] GameObject removeCanvas;


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
        CreateGameLine();
        UpdateLinesDisplay();
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


    void CreateGameLine()
    {
        if (lineAmount.Count < maxLines && Input.GetMouseButtonDown(0) && !removeCanvas.activeSelf)
        {
            DrawLine();
        }
        if (Input.GetMouseButton(0) && lineRender.positionCount < maxLineSize)
        {

            Vector2 currentFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distanceToMousePos = Vector2.Distance(fingerPositions[0], currentFingerPos);
            if (distanceToMousePos > maxLineLength) { return; }
            else if (currentFingerPos != fingerPositions[0] && currentFingerPos != fingerPositions[fingerPositions.Count - 1])
            {
                LineUpdate(currentFingerPos);
            }

        }
    }


    void UpdateLinesDisplay()
    {
        availableLines = maxLines - lineAmount.Count;

        maxLinesText.text = availableLines.ToString();
    }
}


