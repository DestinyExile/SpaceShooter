using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLaser : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Rigidbody _rb = null;
    UIController uIController = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        uIController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();

        if(playerShip != null)
        {
            playerShip.Die();
            uIController.ShowLoseText();
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.back * _moveSpeed;
        _rb.velocity = moveDirection;
    }
}
