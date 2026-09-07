using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;
    public int skor = 0;
    public TMP_Text skorText;
    private Vector2 arahGerak;
    public GameManager gameManager;

    void Start()
    {
        UpdateSkorText();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMove(InputValue value)
    {
        arahGerak = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0f);
        transform.position += arah * kecepatan * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            skor+= 1;
            Debug.Log("Skor: " + skor);
            UpdateSkorText();

            if (gameManager != null)
            {
                gameManager.AmbilKoin();
            }
        }
    }

    void UpdateSkorText()
    {
        if (skorText != null)
        {
            skorText.text = "Skor: " + skor;
        }
    }
    
}
