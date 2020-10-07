using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * _movementSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * _movementSpeed);
        }
    }
}
