using UnityEngine;

public class DummySpawnerScript : MonoBehaviour
{
    public GameObject DummyPrefab;
    public Transform[] SpawnLocations;
    public float SpawnInterval = 1.0f;
    public int SpawnCount = 0;
    float LastSpawn = 0.0f;
    int Spawned;

    void Awake()
    {
        Debug.Assert(DummyPrefab != null);
        Debug.Assert(SpawnLocations.Length > 0);
        Spawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LastSpawn += Time.deltaTime;

        if (LastSpawn >= SpawnInterval && ((SpawnCount == 0) || (SpawnCount - Spawned > 0)))
        {
            Spawned++;
            if (Spawned > SpawnCount)
            {
                Spawned = SpawnCount;
            }

            LastSpawn = 0.0f;

            Transform randomSpawn = SpawnLocations[Random.Range(0, SpawnLocations.Length)];
            Instantiate(DummyPrefab, randomSpawn.transform.position, Quaternion.identity);
        }
    }
}
