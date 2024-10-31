using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneUimanager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI levelText;
    int levelId;
    [SerializeField] TextMeshProUGUI heartNumberText;
    int heartNumber;
    [SerializeField] TextMeshProUGUI scoreText;
    int scroreNumber;
    [SerializeField] TextMeshProUGUI timeCountText;
    [SerializeField] GameObject[] levelObjects;
    [SerializeField] UiPanelDotween losePanel;
    [SerializeField] TextMeshProUGUI scoreText2;

    private float elapsedTime;
    private int currentLevelIndex = 0;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start() {
        levelId = PlayerPrefs.GetInt(StringManager.LevelId, levelId + 1);
        PlayerPrefs.SetInt(StringManager.LevelId, levelId);
        levelText.text = levelId.ToString();
        heartNumber = PlayerPrefs.GetInt(StringManager.HeartNumber);
        heartNumberText.text = heartNumber.ToString();
        scroreNumber = PlayerPrefs.GetInt(StringManager.Score);
        scoreText.text = scroreNumber.ToString();
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update() {
        CountTime();
        CheckBrickCount();
    }

    /// Function

    void CountTime() {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timeCountText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CheckBrickCount() {
        // Đếm số lượng các vật có tag là "Brick"
        int brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;

        if (brickCount == 0 && currentLevelIndex < levelObjects.Length - 1) {
            // Ẩn levelObjects hiện tại
            levelObjects[currentLevelIndex].SetActive(false);
            // Chuyển sang levelObjects tiếp theo
            currentLevelIndex++;
            levelObjects[currentLevelIndex].SetActive(true);
            levelId += 1;
            levelText.text = levelId.ToString();
            FindObjectOfType<BallScript>().ResetBall();
            if (levelObjects[10].activeSelf)
                losePanel.PanelFadeIn();
        }
    }

    public void PlusScore(int number) {
        scroreNumber += number;
        scoreText.text = scroreNumber.ToString();
        PlayerPrefs.SetInt(StringManager.Score, scroreNumber);
    }

    public void MinusHeartNumber(int number) {
        if (heartNumber > 0) {
            heartNumber -= number;
            heartNumberText.text = heartNumber.ToString();
            PlayerPrefs.SetInt(StringManager.HeartNumber, heartNumber);
        }
    }

    public void ShowLosePanel() {
        losePanel.PanelFadeIn();
        scoreText2.text = PlayerPrefs.GetInt(StringManager.Score).ToString();
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
