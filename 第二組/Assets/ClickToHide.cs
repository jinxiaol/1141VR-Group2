using UnityEngine;
using UnityEngine.UI;

public class ClickToHide : MonoBehaviour
{
    private float timer = 0f;

    void OnEnable()
    {
        timer = 0f;
        // 確保自己能攔截滑鼠，不讓點擊穿透到後面的按鈕
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().raycastTarget = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 延遲 0.3 秒，防止點擊寶箱時直接觸發關閉
        if (timer > 0.3f && Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
            Debug.Log("恭喜畫面已關閉，現在可以看到底下的傳送 UI 了");
        }
    }
}