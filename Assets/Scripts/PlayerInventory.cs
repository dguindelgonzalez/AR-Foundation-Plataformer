using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    #region Private Fields

    int coins = 0;

    #endregion

    #region Public Properties

    public Text CoinText;

    #endregion

    #region Unity3D Methods
    private void Start()
    {
        CoinText.text = coins.ToString();
    }
    #endregion

    #region Public Methods

    public void AddCoins()
    {
        coins++;
        CoinText.text = coins.ToString();
        if (coins >= 3)
        {
            GetComponent<PlayerHealth>().EndGame();
        }
        //print(coins);
    }

    #endregion
}
