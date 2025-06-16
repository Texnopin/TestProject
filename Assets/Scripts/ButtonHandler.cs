using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Spawner spawner;

    public void OnButtonClick()
    {
        int currentCount = spawner.spawnedObjects.Count;
        spawner.SpawnFixedCount(currentCount);
    }
}
