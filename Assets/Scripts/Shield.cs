using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static bool _isShielded = false;

    [SerializeField] AudioClip _powerDownSFX;

    AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Laser"))
        {
            _isShielded = false;
            _audioSource.PlayOneShot(_powerDownSFX, _audioSource.volume);
            GameObject.Destroy(other.gameObject);

            this.gameObject.GetComponent<Collider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
