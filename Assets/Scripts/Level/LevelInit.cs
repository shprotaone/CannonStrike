using UnityEngine;
using TMPro;

public class LevelInit : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private Transform _obstacleParent;

    private LevelPreset _levelPreset;
    private GameObject _obstacle;

    private void Awake()
    {
        if(LevelLoader.instance.LevelPreset != null)
        {
            _levelPreset = LevelLoader.instance.LevelPreset;
            _levelName.text = _levelPreset.levelName;
            _obstacle = _levelPreset.obstacle;

            Instantiate(_obstacle, _obstacleParent);
        }
        else
        {
            print("Loader is null");
        }     
    }

    private void OnDestroy()
    {
        if(LevelLoader.instance != null)
        {
            LevelLoader.instance.ResetPreset();
        }
    }
}
