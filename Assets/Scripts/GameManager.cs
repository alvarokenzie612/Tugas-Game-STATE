using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour

{
    public int totalKoin;
    private int koinTerkumpul = 0;
    public TMP_Text pesanMenangText;

    void Start()
    {
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        if (koinTerkumpul == totalKoin) Menang();
    }

    void Menang()
    {
        Debug.Log("KAMU MENANG!");
        if (pesanMenangText != null)
        {
            pesanMenangText.gameObject.SetActive(true);
            pesanMenangText.text = "KAMU MENANG!";
        }
    }
}