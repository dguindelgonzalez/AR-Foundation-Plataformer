using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    #region Private Fields

    float nextDamage;

    #endregion

    #region Public properties

    public float Damage;
    public float DamageRate;
    public float PushBackForce;

    #endregion

    #region Unity3D Methods

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time;
    }

    #endregion

    #region Private Methods

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.AddDamage(Damage);
            nextDamage = Time.time + DamageRate;
            PushBack(other.transform);
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= PushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    #endregion

}
