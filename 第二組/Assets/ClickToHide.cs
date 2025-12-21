using UnityEngine;
using UnityEngine.UI;

public class ClickToHide : MonoBehaviour
{
    private float timer = 0f;

    void OnEnable()
    {
        timer = 0f;
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().raycastTarget = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.3f && Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
            Debug.Log("恭喜畫面已關閉，現在可以看到底下的傳送 UI 了");
        }
    }
}