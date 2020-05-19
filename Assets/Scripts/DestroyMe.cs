using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    #region Public Properties

    public float AliveTime;

    #endregion

    #region Unity3D Methods

    void Start()
    {
        Destroy(gameObject, AliveTime);
    }

    #endregion
}
