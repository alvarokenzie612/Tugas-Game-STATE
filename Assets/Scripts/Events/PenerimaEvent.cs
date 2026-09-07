using UnityEngine;

public class PenerimaEvent : MonoBehaviour
{
    private void OnEnable()
    {
        PemancarEvent.SaatTombolDitekan += Respon;
    }

    private void OnDisable()
    {
        PemancarEvent.SaatTombolDitekan -= Respon;
    }

    private void Respon()
    {
        Debug.Log("Penerima Event: Tombol ditekan");
    }
}
