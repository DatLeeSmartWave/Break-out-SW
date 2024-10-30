using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public Rigidbody2D rb;
    public float ballForce;
    public GameObject paddelRed;
    public Transform paddelRedPlatform;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonUp(0) && PlayerPrefs.GetInt(StringManager.ShootBallId) == 0) {
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce(new Vector2(ballForce, ballForce));
            PlayerPrefs.SetInt(StringManager.ShootBallId, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "BottomEdge") {
            transform.SetParent(paddelRed.transform);
            PlayerPrefs.SetInt(StringManager.ShootBallId, 0);
            transform.position = paddelRedPlatform.position;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
    }
}
