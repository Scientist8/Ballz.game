using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallReturn : MonoBehaviour
{
    private BallLauncher ballLauncher;

    private void Awake()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);

        if (tag == "Block")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}