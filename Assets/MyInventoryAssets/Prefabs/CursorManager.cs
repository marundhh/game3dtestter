using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Luôn hiển thị con trỏ chuột
        Cursor.visible = true;

        // Đặt trạng thái con trỏ chuột ở chế độ không khóa
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        // Đảm bảo rằng các thiết lập luôn được áp dụng
        if (!Cursor.visible || Cursor.lockState != CursorLockMode.None)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
