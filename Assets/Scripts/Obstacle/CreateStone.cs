using System.Collections;
using UnityEngine;

public class CreateStone : MonoBehaviour
{
    public GameObject sphere;
    public int createSphere;
    public int delay;

    private void Start()
    {
        StartCoroutine(Spawns());
    }

    private void SpawnSphere()
    {
        Vector3 randomOffset = new Vector3(0,0,Random.Range(-8, 8));

        Vector3 spawnPos = transform.position + randomOffset;

        Instantiate(sphere, spawnPos, Quaternion.identity, transform);
    }

    IEnumerator Spawns()
    {
        while (true)
        {
            SpawnSphere();
            yield return new WaitForSeconds(delay);
        }
    }


}
