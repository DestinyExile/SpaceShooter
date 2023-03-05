using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _powerupDuration = 3;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate;
    [SerializeField] GameObject _shield;
    [SerializeField] AudioClip _powerUpSFX;

    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;
    AudioSource _poweringUp = null;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();
        _poweringUp = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!(other.CompareTag("Laser")))
        {
            if (_poweredUp == false)
            {
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

        if(Shield._isShielded)
        {
            DeactivatePowerup();

            _poweredUp = false;

            DestroyObject();
        }        
    }

    void ActivatePowerup()
    {
        _shield.gameObject.GetComponent<Collider>().enabled = true;
        _shield.gameObject.GetComponent<MeshRenderer>().enabled = true;
        Shield._isShielded = true;
       _poweringUp.PlayOneShot(_powerUpSFX, _poweringUp.volume);
    }

    void DeactivatePowerup()
    {
        _shield.gameObject.GetComponent<Collider>().enabled = false;
        _shield.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Shield._isShielded = false;
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
