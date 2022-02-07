using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LineDrawer : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject currentLine;

    [SerializeField] LineRenderer lineRender;
    [SerializeField] EdgeCollider2D edgeCollider;

    [SerializeField] List<Vector2> fingerPositions;




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawLine();
        }
        if (Input.GetMouseButton(0))
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


    }

    void LineUpdate(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRender.positionCount++;
        lineRender.SetPosition(lineRender.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();


    }
}


