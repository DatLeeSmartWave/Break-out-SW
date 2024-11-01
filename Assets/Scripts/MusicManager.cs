using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioSource musicEffect;
    // Start is called before the first frame update
    void Start() {
        SetUpMusicStatus();
    }

    // Update is called once per frame
    void Update() {

    }

    void SetUpMusicStatus() {
        if (PlayerPrefs.GetInt(StringManager.MusicId) == 1)
            musicEffect.volume = 1;
        else
            musicEffect.volume = 0;
        Debug.Log(PlayerPrefs.GetInt(StringManager.MusicId));

    }

    public void TurnOffMusic() {
        musicEffect.volume = 0;
    }

    public void TurnOnMusic() {
        musicEffect.volume = 1;
    }
}
