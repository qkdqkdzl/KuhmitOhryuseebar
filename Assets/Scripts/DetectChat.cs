using UnityEngine;

public class DetectChat : MonoBehaviour
{
    public GameObject[] panels; // Panel_NPC1 ~ Panel_NPC5
    private int currentPanelIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Hero가 detect1~7에 닿았는지 확인
        if (other.CompareTag("Player") && currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
            currentPanelIndex++;
        }

    }
}
