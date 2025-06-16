using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public Transform[] poolPositions = new Transform[7];
    private List<GameObject> pooledObjects = new List<GameObject>();

    public EndGame endGame;

    public int PooledObjectsCount => pooledObjects.Count;

    public void AddToPool(GameObject obj)
    {
        if (pooledObjects.Count >= poolPositions.Length)
        {
            Debug.LogWarning("Пул заполнен!");
            return;
        }

        pooledObjects.Add(obj);
        int idx = pooledObjects.Count - 1;
        obj.transform.position = poolPositions[idx].position;
        obj.transform.rotation = poolPositions[idx].rotation;

        var rb = obj.GetComponent<Rigidbody>();
        if (rb != null) rb.velocity = Vector3.zero;

        CheckAndRemoveTriplets();

        endGame.CheckEndConditions();
    }

    private void CheckAndRemoveTriplets()
    {
        Dictionary<int, List<GameObject>> groups = new Dictionary<int, List<GameObject>>();

        foreach (var obj in pooledObjects)
        {
            Figure figure = obj.GetComponent<Figure>();
            if (figure == null) continue;

            int id = figure.UniqueId;

            if (!groups.ContainsKey(id))
                groups[id] = new List<GameObject>();

            groups[id].Add(obj);
        }

        bool removedAny = false;

        foreach (var kvp in groups)
        {
            if (kvp.Value.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject toRemove = kvp.Value[i];
                    pooledObjects.Remove(toRemove);
                    Destroy(toRemove);
                }
                removedAny = true;
            }
        }

        if (removedAny)
        {
            UpdatePoolPositions();
        }
    }

    private void UpdatePoolPositions()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].transform.position = poolPositions[i].position;
            pooledObjects[i].transform.rotation = poolPositions[i].rotation;
        }
    }
}
