using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    
    void Update()
    {
        MoveUp();
    }

    void MoveUp ()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y >= 14.0f)
        {
            if (this.gameObject.transform.parent != null)
            {
            Destroy(this.gameObject.transform.parent.gameObject);
            }
            else
            {
            Destroy(gameObject);
            }
        }
    }
}
