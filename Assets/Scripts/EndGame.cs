using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Spawner spawner;               
    public ObjectPoolManager poolManager; 

    public GameObject endScreenUI;  
    public Text endScreenText;        

    private bool isEndShown = false;

    public void CheckEndConditions()
    {
        if (isEndShown) return; 

        if (spawner.spawnedObjects.Count <= 1)
        {
            ShowEndScreen("YOU WIN");
        }
        else if (poolManager.PooledObjectsCount == poolManager.poolPositions.Length)
        {
            ShowEndScreen("YOU LOSE");
        }
    }

    private void ShowEndScreen(string message)
    {
        isEndShown = true;
        endScreenUI.SetActive(true);
        endScreenText.text = message;
        Time.timeScale = 0f;
    }

    public void OnButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
