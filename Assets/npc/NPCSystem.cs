using DialogueEditor;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;
    public NPCConversation con;

    private void Start()
    {
        // Ẩn chuột khi game bắt đầu
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Gọi khi một Collider khác đi vào vùng Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
            Debug.Log("Người chơi đã vào vùng hội thoại.");
        }
    }

    // Gọi khi một Collider khác rời khỏi vùng Trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = false;
            Debug.Log("Người chơi đã rời khỏi vùng hội thoại.");
        }
    }

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Bắt đầu hội thoại");
            StartConversation();
        }
    }

    private void StartConversation()
    {
        // Hiện chuột và cho phép tương tác
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Bắt đầu hội thoại
        ConversationManager.Instance.StartConversation(con);

        
    }

    private void EndConversation()
    {
        Debug.Log("Kết thúc hội thoại");

        // Ẩn chuột và khóa lại
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
