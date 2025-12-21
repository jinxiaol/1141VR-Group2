using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject teleportUI;

    public void OpenBox()
    {
        Debug.Log("®¥³ß³qÃö¡I");

        teleportUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}