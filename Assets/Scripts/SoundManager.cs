using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource soundEffect;
    public AudioClip ballSound;
    public AudioClip destroyBrickSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    // Start is called before the first frame update
    void Start() {
        SetUpMusicStatus();
    }

    // Update is called once per frame
    void Update() {

    }

    void SetUpMusicStatus() {
        if (PlayerPrefs.GetInt(StringManager.SoundId) == 1)
            soundEffect.volume = 1;
        else
            soundEffect.volume = 0;
        Debug.Log(PlayerPrefs.GetInt(StringManager.SoundId));
    }

    public void TurnOffSound() {
        soundEffect.volume = 0;
    }

    public void TurnOnSound() {
        soundEffect.volume = 1;
    }

    public void PlayBallSound() {
        soundEffect.PlayOneShot(ballSound);
    }

    public void PlayDestroyBrickSound() {
        soundEffect.PlayOneShot(destroyBrickSound);
    }

    public void PlayWinSound() {
        soundEffect.PlayOneShot(winSound);
    }

    public void PlayLoseSound() {
        soundEffect.PlayOneShot(loseSound);
    }

    public void PlayDestroyBrick() {
        soundEffect.PlayOneShot(destroyBrickSound);
    }
}
