﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Private Fields

    float currentHealth;
    AudioSource playerAS;
    Color flashColour = new Color(255f, 255f, 255f, 0.5f);
    float indicatorSpeed = 5f;
    bool damaged;

    #endregion

    #region Public Properties

    public string EndText = "Has Ganado!";
    public Image DeathScreen;
    public CanvasGroup EndGC;
    public Text EndGameUIText;
    public Image DamageIndicator;
    public CanvasGroup EndGameCanvas;
    public float FullHealth;
    public AudioClip PlayerDamaged;

    #endregion

    #region Unity3D Methods

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = FullHealth;
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            DamageIndicator.color = flashColour;
        }
        else
        {
            DamageIndicator.color = Color.Lerp(DamageIndicator.color, Color.clear, indicatorSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    #endregion

    #region Public Methods

    public void AddDamage(float damage)
    {
        if (damage <= 0)
            return;

        currentHealth -= damage;
        playerAS.PlayOneShot(PlayerDamaged);
        damaged = true;

        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    public void MakeDead()
    {
        EndText = "Has Perdido!";
        EndGame();
        DeathScreen.color = Color.white;
        Destroy(gameObject);
    }

    public void EndGame()
    {
        EndGameUIText.text = EndText;
        EndGC.alpha = 1;
        print(EndText);
    }

    #endregion
}
