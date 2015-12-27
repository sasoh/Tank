using UnityEngine;
using System.Collections;

public class DummySpawnerScript : MonoBehaviour
{
    public GameObject DummyPrefab;
    public Transform[] SpawnLocations;
    public float SpawnInterval = 1.0f;
    float LastSpawn = 0.0f;

    void Awake()
    {
        Debug.Assert(DummyPrefab != null);
        Debug.Assert(SpawnLocations.Length > 0);
    }

    // Update is called once per frame
    void Update()
    {
        LastSpawn += Time.deltaTime;

        if (LastSpawn >= SpawnInterval)
        {
            LastSpawn = 0.0f;

            Transform randomSpawn = SpawnLocations[Random.Range(0, SpawnLocations.Length)];
            Instantiate(DummyPrefab, randomSpawn.transform.position, Quaternion.identity);
        }
    }
}
