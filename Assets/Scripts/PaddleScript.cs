using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PaddleScript : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 touchPosition;
    private bool isPointerOverUI;
    public GameObject background;

    void Update() {
        isPointerOverUI = IsPointerOverUIElement();
        if (Input.touchCount > 0 &&
            !isPointerOverUI) {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            // Di chuyển nền theo vị trí chạm
            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
        }
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
