using UnityEngine;

public class ESCMenuToggle : MonoBehaviour
{
    public GameObject canvasESC; // Canvas_ESC 오브젝트 연결

    void Start()
    {
        canvasESC.SetActive(false); // 시작 시 숨김
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = canvasESC.activeSelf;
            canvasESC.SetActive(!isActive);

            // 게임 일시정지 (선택사항)
            Time.timeScale = isActive ? 1f : 0f;
        }
    }
}
