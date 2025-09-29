using UnityEngine;

public class DetectChat : MonoBehaviour
{
    [Header("ÀÌ Detect°¡ Ä×À¸¸é ÇÏ´Â ÆÐ³Î")]
    public GameObject panelToShow;

    private void Start()
    {       
        panelToShow.SetActive(false); // ½ÃÀÛÇÒ ¶© ²¨µÒ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && panelToShow != null)
        {
            panelToShow.SetActive(true);
            Debug.Log("OnTriggerEnter2D");
        }
    }
}
