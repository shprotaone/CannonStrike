using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private const string soundsName = "Master";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _turnOnSprite;
    [SerializeField] private Sprite _turnOffSprite;
    
    private bool _soundIsOn;
    
    public void SwitchSound()
    {
        if (_soundIsOn)
        {
            _audioMixer.SetFloat(soundsName, -80f);
            
            _button.image.sprite = _turnOffSprite;
            _soundIsOn = false;
        }
        else
        {
            _audioMixer.SetFloat(soundsName, 1f);

            _button.image.sprite = _turnOnSprite;
            _soundIsOn = true;
        }
    }
}
