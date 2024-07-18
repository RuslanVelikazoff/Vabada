using UnityEngine;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    [SerializeField] 
    private Button graphicButton;
    [SerializeField] 
    private Button controlButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject graphicPanel;
    [SerializeField] 
    private GameObject controlPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button resetButton;

    [Space(13)]
    
    [SerializeField] 
    private Slider soundSlider;
    [SerializeField] 
    private Slider musicSlider;

    private float musicVolume;
    private float soundVolume;

    private void OnEnable()
    {
        musicVolume = AudioManager.Instance.GetMusicVolume();
        soundVolume = AudioManager.Instance.GetSoundVolume();

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
        
        ButtonClickAction();
    }

    private void Update()
    {
        if (musicSlider.value != musicVolume)
        {
            musicVolume = musicSlider.value;
            AudioManager.Instance.SetMusicVolume(musicVolume);
        }

        if (soundSlider.value != soundVolume)
        {
            soundVolume = soundSlider.value;
            AudioManager.Instance.SetSoundVolume(soundVolume);
        }
    }

    private void ButtonClickAction()
    {
        if (graphicButton != null)
        {
            graphicButton.onClick.RemoveAllListeners();
            graphicButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                graphicPanel.SetActive(true);
            });
        }

        if (controlButton != null)
        {
            controlButton.onClick.RemoveAllListeners();
            controlButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                controlPanel.SetActive(true);
            });
        }

        if (resetButton != null)
        {
            resetButton.onClick.RemoveAllListeners();
            resetButton.onClick.AddListener(() =>
            {
                ResetSoundSettings();
            });
        }
    }

    private void ResetSoundSettings()
    {
        AudioManager.Instance.SetMusicVolume(0f);
        AudioManager.Instance.SetSoundVolume(0f);
        
        musicVolume = AudioManager.Instance.GetMusicVolume();
        soundVolume = AudioManager.Instance.GetSoundVolume();

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
    }
}
