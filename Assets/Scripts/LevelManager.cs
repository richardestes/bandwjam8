using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _currentLevelIndex;
    private void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        print(_currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        SceneManager.LoadScene(_currentLevelIndex);
        //SceneManager.LoadSceneAsync(_currentLevelIndex);
    }
}
