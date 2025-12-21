using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject teleportUI;
    public GameObject congratsPanel;

    // 增加這個變數來記錄是否已經觸發過
    private bool hasBeenOpened = false;

    public void OpenBox()
    {
        // 如果已經按過了，就直接跳出，什麼都不做
        if (hasBeenOpened)
        {
            return;
        }

        // 第一次按，執行以下邏輯
        if (congratsPanel != null) congratsPanel.SetActive(true);
        if (teleportUI != null) teleportUI.SetActive(true);

        // 解鎖滑鼠
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 重要：把開關關上，下次點擊就會在上面被 return 掉
        hasBeenOpened = true;
        Debug.Log("寶箱已被開啟，現在變為一次性物件，不再觸發。");
    }
}