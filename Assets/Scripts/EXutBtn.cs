using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("게임 종료 버튼이 눌렸습니다.");
        Application.Quit();
    }
}



