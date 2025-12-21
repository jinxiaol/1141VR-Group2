using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject teleportUI;
    public GameObject congratsPanel;

    private bool hasBeenOpened = false;

    public void OpenBox()
    {
        if (hasBeenOpened)
        {
            return;
        }

        if (congratsPanel != null) congratsPanel.SetActive(true);
        if (teleportUI != null) teleportUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        hasBeenOpened = true;
        Debug.Log("寶箱已被開啟，現在變為一次性物件，不再觸發。");
    }
}