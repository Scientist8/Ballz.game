using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] AudioClip breakSound;

    private int hitsRemaining = 5;
       
    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;

    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    private void Update()
    {
        //lose condition is here
        if (gameObject.transform.position.y <= -4)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 15f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
        {
            UpdateVisualState();
            
        }
        else
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
            TriggerSparklesVFX();
        }
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.75f);
    }
}
