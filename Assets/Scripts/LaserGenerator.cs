using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour
{
    [SerializeField] GameObject VerticalLaser;
    [SerializeField] GameObject HorizontalLaser;
    [SerializeField] int hazardAmount;
    [SerializeField] float spawnDelay;
    [SerializeField] float waveDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLasers());
    }

    IEnumerator SpawnLasers()
    {
        yield return new WaitForSeconds(waveDelay);
        while (true)
        {
            for (int i = 0; i < hazardAmount; i++)
            {
                Vector3 horizontalSpawnPosition = new Vector3(-20, 0.05f, Random.Range(-18, 18));
                Vector3 verticalSpawnPosition = new Vector3(Random.Range(-17f, 17f), 0.05f, 20f);
                Quaternion verticalSpawnRotation = Quaternion.identity;
                Quaternion horizontalSpawnRotation = Quaternion.Euler(0, 90, 0);
                Instantiate(VerticalLaser, verticalSpawnPosition, verticalSpawnRotation);
                Instantiate(HorizontalLaser, horizontalSpawnPosition, horizontalSpawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);
        }
        
    }
}
