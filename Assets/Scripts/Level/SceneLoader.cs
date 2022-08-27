using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;

    private LevelPreset _preset;

    private void Start()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void LoadLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void RestartLevel()
    {
        LoadLevel(0);
        SetLevelConfiguration(_preset);
    }

    public void SetLevelConfiguration(LevelPreset preset)
    {
        _preset = preset;

        if(_levelLoader != null)
            _levelLoader.SetObstacle(preset);
    }
}
