using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    [Header("씬 전환 설정")]
    public string sceneName = "Chapter2";  // 이동할 씬 이름
    public float waitTime = 0.5f;          // 전환 전 대기 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player와 충돌했을 때만 동작
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneRoutine());
        }
    }

    IEnumerator LoadSceneRoutine()
    {
        // 필요하면 페이드 아웃, 효과음 넣기 가능
        yield return new WaitForSeconds(waitTime);

        // 지정된 씬 로드
        SceneManager.LoadScene("using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    [Header("씬 전환 설정")]
    public string sceneName = "Chapter2";  // 이동할 씬 이름
    public float waitTime = 0.5f;          // 전환 전 대기 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player와 충돌했을 때만 동작
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneRoutine());
        }
    }

    IEnumerator LoadSceneRoutine()
    {
        // 필요하면 페이드 아웃, 효과음 넣기 가능
        yield return new WaitForSeconds(waitTime);

        // 지정된 씬 로드
        SceneManager.LoadScene(sceneName);
    }
}
");
    }
}
