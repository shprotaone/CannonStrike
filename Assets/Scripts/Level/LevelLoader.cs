using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;

    private LevelPreset _levelPreset;

    public LevelPreset LevelPreset => _levelPreset;

    private void Start()
    {
        if (instance == null) 
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    public void SetObstacle(LevelPreset preset)
    {
        _levelPreset = preset;
    }

    public void ResetPreset()
    {
        _levelPreset = null;
    }
}
