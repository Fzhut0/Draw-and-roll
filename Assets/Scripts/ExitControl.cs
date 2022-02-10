using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject winConditionObj;
    [SerializeField] AudioClip winAudio;

    AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerPrefab)
        {
            collision.collider.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Destroy(collision.collider.gameObject);
            audioSrc.PlayOneShot(winAudio);
            winConditionObj.GetComponent<WinControl>().currentWinConditionCount++;
        }
    }


}
