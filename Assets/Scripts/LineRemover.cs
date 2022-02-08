using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LineRemover : MonoBehaviour
{
    [SerializeField] Material removeColor;
    [SerializeField] GameObject reverseButtonActive;
    [SerializeField] GameObject removeControler;

    [SerializeField] Material originalMaterial;
    [SerializeField] GameObject lineDrawer;

    private void Start()
    {
        originalMaterial = GetComponent<LineRenderer>().material;
    }
    private void Update()
    {
        removeControler = GameObject.FindGameObjectWithTag("ReverseCount");
        reverseButtonActive = GameObject.FindGameObjectWithTag("Reverse");
        lineDrawer = GameObject.FindGameObjectWithTag("LineControl");

    }



    private void OnMouseOver()
    {
        if (reverseButtonActive == null) { return; }
        if (reverseButtonActive.activeSelf)
        {
            GetComponent<LineRenderer>().material = removeColor;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<LineRenderer>().material = originalMaterial;
    }

    private void OnMouseDown()
    {
        if (reverseButtonActive == null) { return; }
        if (removeControler.GetComponent<ReverseButtonControl>().undoCount > 0 && reverseButtonActive.activeSelf)
        {
            lineDrawer.GetComponent<LineDrawer>().lineAmount.Remove(gameObject);
            Destroy(gameObject);
            removeControler.GetComponent<ReverseButtonControl>().undoCount--;
            removeControler.GetComponent<ReverseButtonControl>().UpdateDisplay();
        }
    }



}
