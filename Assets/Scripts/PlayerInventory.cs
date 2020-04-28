using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Private Fields

    int coins = 0;

    #endregion

    #region Public Properties


    #endregion

    #region Public Methods
    
    public void AddCoins()
    {
        coins++;
        print(coins);
    }

    #endregion
}
