using UnityEngine;

public class CameraTouchHandler : MonoBehaviour
{
    public Camera mainCamera;
    public ObjectPoolManager poolManager;
    public Spawner spawner;  

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            HandleTouch(Input.touches[0].position);
        }
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch(Input.mousePosition);
        }
    }

    void HandleTouch(Vector2 screenPos)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject tappedObject = hit.collider.gameObject;

            if (spawner.spawnedObjects.Contains(tappedObject))
            {
                poolManager.AddToPool(tappedObject);

                spawner.spawnedObjects.Remove(tappedObject);
            }
        }
    }
}
