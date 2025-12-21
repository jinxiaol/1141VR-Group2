using UnityEngine;

public class TeleportUI : MonoBehaviour
{
    [Header("°òÂ¦³]©w")]
    public GameObject player;
    public GameObject teleportUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowUI();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HideUI();
        }
    }

    public void ShowUI()
    {
        teleportUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideUI()
    {
        teleportUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToLevel(int index)
    {
        Vector3 targetPos = Vector3.zero;
        bool isDark = false;

        if (index == 0)
        {
            targetPos = new Vector3(-290f, 6.37f, -83f);
        }
        else if (index == 1)
        {
            targetPos = new Vector3(601f, -3.5f, 258f);
        }
        else if (index == 2)
        {
            targetPos = new Vector3(601f, -3.5f, -916f);
        }
        else if (index == 3)
        {
            targetPos = new Vector3(601f, -3.5f, -2278f);
            isDark = true;
        }

        player.transform.position = targetPos;

        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.SetDarkness(isDark);
        }

        HideUI();
    }
}