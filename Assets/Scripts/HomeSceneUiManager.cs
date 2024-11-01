using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeSceneUiManager : MonoBehaviour {
    [SerializeField] private Sprite[] settingButtonStatus;
    [SerializeField] private Image soundOnButton;
    [SerializeField] private Image soundOffButton;
    [SerializeField] private Image musicOnButton;
    [SerializeField] private Image musicOffButton;
    [SerializeField] private TextMeshProUGUI heartNumberText;
    [SerializeField] UiPanelDotween noticePanel;
    int soundId;
    int musicId;
    int heartNumber;

    private void Awake() {
        Application.targetFrameRate = 60;
        SetUpSoundEffectIcon();
    }

    // Start is called before the first frame update
    void Start() {
        heartNumber = PlayerPrefs.GetInt(StringManager.HeartNumber);
        heartNumberText.text = heartNumber.ToString();
    }

    ///  Button Zone

    public void SoundOnButton() {
        if (soundOnButton.sprite == settingButtonStatus[0]) {
            soundOnButton.sprite = settingButtonStatus[1];
            soundOffButton.sprite = settingButtonStatus[0];
            PlayerPrefs.SetInt(StringManager.SoundId, 1);
            FindObjectOfType<SoundManager>().TurnOnSound();
        }
    }

    public void SoundOffButton() {
        if (soundOffButton.sprite == settingButtonStatus[0]) {
            soundOnButton.sprite = settingButtonStatus[0];
            soundOffButton.sprite = settingButtonStatus[1];
            PlayerPrefs.SetInt(StringManager.SoundId, 0);
            FindObjectOfType<SoundManager>().TurnOffSound();
        }
    }

    public void MusicOnButton() {
        if (musicOnButton.sprite == settingButtonStatus[0]) {
            musicOnButton.sprite = settingButtonStatus[1];
            musicOffButton.sprite = settingButtonStatus[0];
            PlayerPrefs.SetInt(StringManager.MusicId, 1);
            FindObjectOfType<MusicManager>().TurnOnMusic();
        }
    }

    public void MusicOffButton() {
        if (musicOffButton.sprite == settingButtonStatus[0]) {
            musicOnButton.sprite = settingButtonStatus[0];
            musicOffButton.sprite = settingButtonStatus[1];
            PlayerPrefs.SetInt(StringManager.MusicId, 0);
            FindObjectOfType<MusicManager>().TurnOffMusic();
        }
    }

    public void BuyHeartButton(int number) {
        heartNumber += number;
        PlayerPrefs.SetInt(StringManager.HeartNumber, heartNumber);
        heartNumberText.text = heartNumber.ToString();
    }

    public void LoadScene(string sceneName) {
        if (PlayerPrefs.GetInt(StringManager.HeartNumber) > 0)
            SceneManager.LoadScene(sceneName);
        else
            noticePanel.PanelFadeIn();
    }

    /// Fuction Zone  

    void SetUpSoundEffectIcon() {
        soundId = PlayerPrefs.GetInt(StringManager.SoundId, 1);
        PlayerPrefs.SetInt(StringManager.MusicId, soundId);
        musicId = PlayerPrefs.GetInt(StringManager.MusicId, 1);
        PlayerPrefs.SetInt(StringManager.SoundId, musicId);
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
