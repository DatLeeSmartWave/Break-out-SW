using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BallScript : MonoBehaviour {
    public Rigidbody2D rb;
    public float ballForce;
    public GameObject paddelRed;
    public Transform paddelRedPlatform;
    private bool isPointerOverUI;
    public GameObject background;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        isPointerOverUI = IsPointerOverUIElement();
        if (Input.GetMouseButtonUp(0) && PlayerPrefs.GetInt(StringManager.ShootBallId) == 0 &&
            !isPointerOverUI) {
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce(new Vector2(ballForce, ballForce));
            PlayerPrefs.SetInt(StringManager.ShootBallId, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "BottomEdge") {
            //PlayerPrefs.SetInt(StringManager.ShootBallId, 0);
            //transform.position = paddelRedPlatform.position;
            //rb.isKinematic = true;
            //rb.velocity = Vector3.zero;
            ResetBall();
            FindObjectOfType<PlaySceneUimanager>().MinusHeartNumber(1);
            if(PlayerPrefs.GetInt(StringManager.HeartNumber) == 0)
            {
                FindObjectOfType<PlaySceneUimanager>().ShowLosePanel();
            }
        }
    }

    public void ResetBall() {
        transform.SetParent(paddelRed.transform);
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        transform.position = paddelRedPlatform.position;
        PlayerPrefs.SetInt(StringManager.ShootBallId, 0);
    }

    private bool IsPointerOverUIElement() {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Duyệt qua tất cả các kết quả raycast
        foreach (RaycastResult result in results) {
            // Nếu là thành phần background thì bỏ qua
            if (result.gameObject == background.gameObject) {
                continue;
            }
            // Nếu gặp thành phần UI nào khác thì trả về true (chuột đang trên UI)
            if (result.gameObject.GetComponent<Graphic>() != null) {
                return true;
            }
        }

        // Nếu chỉ trên background hoặc không nằm trên thành phần UI nào khác
        return false;
    }
}
