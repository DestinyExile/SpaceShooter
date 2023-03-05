using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;

    [SerializeField] ParticleSystem _deathParticles;
    [SerializeField] AudioClip _deathSFX;
    [SerializeField] GameObject _artToDisableOnDeath;

    [SerializeField] Material _playerMaterial;

    Rigidbody _rb = null;
    AudioSource _audioSource = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _playerMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    void MoveShip()
    {
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        _rb.AddForce(moveDirection);
    }

    void TurnShip()
    {
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Die()
    {
        if(_deathParticles != null)
        {
            _deathParticles.Play();
        }
        if (_deathSFX != null)
        {
            _audioSource.PlayOneShot(_deathSFX, _audioSource.volume);
        }
        DisableDeathObjects();
    }

    public void DisableDeathObjects()
    {
        _artToDisableOnDeath.SetActive(false);

        _rb.detectCollisions = false;
        _rb.velocity = Vector3.zero;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
