using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 touchPosition;

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            // Di chuyển nền theo vị trí chạm
            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
        }
    }

}
