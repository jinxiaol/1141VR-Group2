using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [Header("NPC 設定")]
    public string npcName;
    [TextArea(3, 10)]
    public string dialogueContent;

    [Header("頭頂 UI 連結")]
    public GameObject headCanvas;
    public Text uiText;

    private Transform mainCameraTransform;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;

        if (headCanvas != null)
        {
            headCanvas.SetActive(false);
        }
    }

    void LateUpdate()
    {
        if (headCanvas != null && headCanvas.activeSelf)
        {
            headCanvas.transform.LookAt(headCanvas.transform.position + mainCameraTransform.rotation * Vector3.forward,
                                      mainCameraTransform.rotation * Vector3.up);
        }
    }

    public void ShowDialogue()
    {
        if (headCanvas != null && uiText != null)
        {
            headCanvas.SetActive(true);
            uiText.text = dialogueContent;

            CancelInvoke("HideDialogue");
            Invoke("HideDialogue", 5f);
        }
        else
        {
            Debug.LogError(gameObject.name + " 的 NPCController 尚未在 Inspector 中連結 UI 物件！");
        }
    }

    void HideDialogue()
    {
        if (headCanvas != null)
        {
            headCanvas.SetActive(false);
        }
    }
}