using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalKoin;
    private int koinTerkumpul = 0;

    public GameObject pesanMenangUI;

    void Start()
    {
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length; 
        
        if (pesanMenangUI != null) 
        {
            pesanMenangUI.SetActive(false);
        }
        
        Time.timeScale = 1f;
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        if (koinTerkumpul >= totalKoin) 
        {
            Menang();
        }
    }

    void Menang()
    {
        if (pesanMenangUI != null) 
        {
            pesanMenangUI.SetActive(true);
        }
        
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 22;
        GUI.Label(new Rect(16, 16, 480, 36), "Koin: " + koinTerkumpul + " / " + totalKoin);
    }
}