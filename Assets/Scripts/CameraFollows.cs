using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    #region Private Fields

    Vector3 offset;

	#endregion

    #region Public Properties

    public Transform Target;
    public float Smoothing = 5f;

	#endregion

    #region Unity3D Methods

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, Smoothing * Time.deltaTime);
    }

	#endregion
}
