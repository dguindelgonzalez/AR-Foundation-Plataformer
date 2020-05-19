using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    #region Private Flieds

    bool collected = false;

    #endregion

    #region Public Properties

    public GameObject Reward;

    #endregion

    #region Private Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !collected)
        {
            Instantiate(Reward, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<PlayerInventory>().AddCoins();
            Destroy(gameObject.transform.root.gameObject);
            collected = true;
        }
    }

    #endregion
}
