using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button _restartLevel;
    [SerializeField] Button _nextLevel;

    private void Start()
    {
        _restartLevel.onClick.AddListener(RestartLevel);
        _nextLevel.onClick.AddListener(NextLevel);
    }

    private void OnDestroy()
    {
        _restartLevel.onClick.RemoveListener(RestartLevel);
        _nextLevel.onClick.RemoveListener(NextLevel);
    }

    private void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    private void NextLevel() 
    {
        var NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (NextSceneIndex < SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
        
    }
}
