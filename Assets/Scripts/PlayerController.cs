using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 0.1f;
    public float jump = 3f;
    
    private Transform initialPosition;
    public float positi;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform;
        positi = initialPosition.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
	    {
            Debug.Log("Derecha");
            this.transform.SetPositionAndRotation(new Vector3(this.transform.localPosition.x + velocity, this.transform.localPosition.y), this.transform.localRotation);
    	}
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
	    {
            Debug.Log("Izquierda");
            this.transform.SetPositionAndRotation(new Vector3(this.transform.localPosition.x - velocity, this.transform.localPosition.y), this.transform.localRotation);
	    }
        
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.localPosition.y >= initialPosition.localPosition.y)
	    {
            Debug.Log("Salto");
            this.transform.SetPositionAndRotation(new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + jump), this.transform.localRotation);
	    }
        
    }
}
