using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineRemover : MonoBehaviour
{
    [SerializeField] Material removeColor;
    [SerializeField] GameObject reverseButtonActive;

    [SerializeField] Material originalMaterial;


    private void Start()
    {
        originalMaterial = GetComponent<LineRenderer>().material;
    }
    private void Update()
    {
        reverseButtonActive = GameObject.FindGameObjectWithTag("Reverse");
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
        Destroy(gameObject);
    }
}
