using System;
using TMPro;
using UnityEngine;

public class PlaySceneUimanager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI levelText;
    int levelId;
    [SerializeField] TextMeshProUGUI heartNumberText;
    int heartNumber;
    [SerializeField] TextMeshProUGUI scroreText;
    int scroreNumber;
    [SerializeField] TextMeshProUGUI timeCountText;

    private float elapsedTime;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start() {
        levelId = PlayerPrefs.GetInt(StringManager.LevelId);
        levelText.text = levelId.ToString();
        heartNumber = PlayerPrefs.GetInt(StringManager.HeartNumber);
        heartNumberText.text = heartNumber.ToString();
        scroreNumber = PlayerPrefs.GetInt(StringManager.Score);
        scroreText.text = scroreNumber.ToString();

        elapsedTime = 0; 
    }

    // Update is called once per frame
    void Update() {
        CountTime();
    }

    ///  Function

    void CountTime() {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timeCountText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PlusScore(int number) {
        scroreNumber += number;
        scroreText.text = scroreNumber.ToString();
        PlayerPrefs.SetInt(StringManager.Score, scroreNumber);
    }
}
