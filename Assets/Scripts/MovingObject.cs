using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isLog;
    public bool isCar;


    private void Update()
    {
        if (isCar)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (isLog)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
