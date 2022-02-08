using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject winConditionObj;



    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (playerPrefab)
        {
            collision.collider.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            winConditionObj.GetComponent<WinControl>().currentWinConditionCount++;
        }
    }


}
