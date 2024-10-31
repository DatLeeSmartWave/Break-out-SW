using UnityEngine;

public class Brick : MonoBehaviour {
    [SerializeField] int healthPoint;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            healthPoint--;
            if (healthPoint <= 0) {
                FindObjectOfType<PlaySceneUimanager>().PlusScore(100);
                gameObject.SetActive(false);
            }
        }
    }
}
