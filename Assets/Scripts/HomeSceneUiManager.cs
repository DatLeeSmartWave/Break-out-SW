using UnityEngine;
using UnityEngine.UI;

public class HomeSceneUiManager : MonoBehaviour
{
    [SerializeField] private Sprite[] settingButtonStatus;
    [SerializeField] private Image soundOnButton;
    [SerializeField] private Image soundOffButton;
    [SerializeField] private Image musicOnButton;
    [SerializeField] private Image musicOffButton;
    int soundId;
    int musicId;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpSoundEffectIcon();
    }

    ///  Button Zone

    public void SoundOnButton() {
        if (soundOnButton.sprite == settingButtonStatus[0]) {
            soundOnButton.sprite = settingButtonStatus[1];
            soundOffButton.sprite = settingButtonStatus[0];
            PlayerPrefs.SetInt(StringManager.SoundId, 1);
        }
    }

    public void SoundOffButton() {
        if (soundOffButton.sprite == settingButtonStatus[0]) {
            soundOnButton.sprite = settingButtonStatus[0];
            soundOffButton.sprite = settingButtonStatus[1];
            PlayerPrefs.SetInt(StringManager.SoundId, 0);
        }
    }

    public void MusicOnButton() {
        if (musicOnButton.sprite == settingButtonStatus[0]) {
            musicOnButton.sprite = settingButtonStatus[1];
            musicOffButton.sprite = settingButtonStatus[0];
            PlayerPrefs.SetInt(StringManager.MusicId, 1);
        }
    }

    public void MusicOffButton() {
        if (musicOffButton.sprite == settingButtonStatus[0]) {
            musicOnButton.sprite = settingButtonStatus[0];
            musicOffButton.sprite = settingButtonStatus[1];
            PlayerPrefs.SetInt(StringManager.MusicId, 0);
        }
    }

    /// Fuction Zone  

    void SetUpSoundEffectIcon() {
        soundId = PlayerPrefs.GetInt(StringManager.SoundId,1);
        PlayerPrefs.SetInt(StringManager.MusicId,soundId);
        musicId = PlayerPrefs.GetInt(StringManager.MusicId,1);
        PlayerPrefs.SetInt(StringManager.SoundId,musicId);
        if (PlayerPrefs.GetInt(StringManager.SoundId) == 1) {
            soundOnButton.sprite = settingButtonStatus[1];
            soundOffButton.sprite = settingButtonStatus[0];
        } else {
            soundOnButton.sprite = settingButtonStatus[0];
            soundOffButton.sprite = settingButtonStatus[1];
        }

        if (PlayerPrefs.GetInt(StringManager.MusicId) == 1) {
            musicOnButton.sprite = settingButtonStatus[1];
            musicOffButton.sprite = settingButtonStatus[0];
        } else {
            musicOnButton.sprite = settingButtonStatus[0];
            musicOffButton.sprite = settingButtonStatus[1];
        }
    }
}
