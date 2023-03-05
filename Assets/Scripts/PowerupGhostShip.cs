using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGhostShip : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _powerupDuration = 3;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate;
    [SerializeField] AudioClip _powerUpSFX;

    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;
    AudioSource _audioSource = null;

    [SerializeField] Material _playerMaterial = null;
    Collider _playerCollider = null;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!(other.CompareTag("Laser")))
        {
            _playerCollider = other;

            if (_poweredUp == false)
            {
                _audioSource.PlayOneShot(_powerUpSFX, _audioSource.volume);
                StartCoroutine(PowerupSequence());
            }
        }
    }

    IEnumerator PowerupSequence()
    {
        _poweredUp = true;
        
        ActivatePowerup();
        DisableObject();

        yield return new WaitForSeconds(_powerupDuration);

        DeactivatePowerup();

        _poweredUp = false;

        DestroyObject();
    }

    void ActivatePowerup()
    {
        if (_playerMaterial != null && _playerCollider != null)
        {
            _playerMaterial.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
            _playerCollider.enabled = false;
        }
    }

    void DeactivatePowerup()
    {
        _playerMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _playerCollider.enabled = true;
    }

    public void DisableObject()
    {
        _colliderToDeactivate.enabled = false;
        _visualsToDeactivate.SetActive(false);

    }

    public void DestroyObject()
    {
        GameObject.Destroy(this.gameObject);
    }
}
