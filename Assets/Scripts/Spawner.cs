using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AnimalCharacteristic[] animals;
    public ColorCharacteristic[] colors;
    public MeshCharacteristic[] meshes;

    public GameObject prefabToSpawn; 
    public float spawnInterval = 2f;

    public List<GameObject> spawnedObjects = new List<GameObject>();

    private List<ObjectCharacteristics> spawnQueue = new List<ObjectCharacteristics>();
    private int spawnIndex = 0;

    private void Start()
    {
        PrepareSpawnQueue();
        StartCoroutine(SpawnRoutine());
    }

    private void PrepareSpawnQueue()
    {
        spawnQueue.Clear();

        for (int i = 0; i < 30; i++)
        {
            var characteristics = GenerateRandomCharacteristics();
            for (int j = 0; j < 3; j++)
            {
                spawnQueue.Add(characteristics);
            }
        }

        ShuffleList(spawnQueue);
    }

    private IEnumerator SpawnRoutine()
    {
        while (spawnIndex < spawnQueue.Count)
        {
            SpawnFigureWithCharacteristics(spawnQueue[spawnIndex]);
            spawnIndex++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

   
    public void SpawnFixedCount(int count)
    {
        StopAllCoroutines();
        ClearField();
        spawnIndex = 0;
        StartCoroutine(SpawnFixedCountRoutine(count));
    }

    private IEnumerator SpawnFixedCountRoutine(int count)
    {
        int spawned = 0;
        while (spawned < count && spawnIndex < spawnQueue.Count)
        {
            SpawnFigureWithCharacteristics(spawnQueue[spawnIndex]);
            spawnIndex++;
            spawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ClearField()
    {
        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
        spawnIndex = 0;
    }

    private ObjectCharacteristics GenerateRandomCharacteristics()
    {
        var animal = animals[Random.Range(0, animals.Length)];
        var color = colors[Random.Range(0, colors.Length)];
        var mesh = meshes[Random.Range(0, meshes.Length)];
        return new ObjectCharacteristics(animal, color, mesh);
    }

    private void SpawnFigureWithCharacteristics(ObjectCharacteristics characteristics)
    {
        GameObject obj = Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);

        Figure figure = obj.GetComponent<Figure>();
        if (figure != null)
        {
            figure.SetCharacteristics(characteristics.Animal, characteristics.Color, characteristics.Mesh);
        }

        spawnedObjects.Add(obj);
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }

    private class ObjectCharacteristics
    {
        public AnimalCharacteristic Animal;
        public ColorCharacteristic Color;
        public MeshCharacteristic Mesh;

        public ObjectCharacteristics(AnimalCharacteristic animal, ColorCharacteristic color, MeshCharacteristic mesh)
        {
            Animal = animal;
            Color = color;
            Mesh = mesh;
        }
    }
}
