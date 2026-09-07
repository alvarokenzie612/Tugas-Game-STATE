using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp = 100;
    public float ms = 2f;

    protected Transform player;

    [Header("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 6f;
    [SerializeField] private float jarakSerang = 1.5f;
    [SerializeField] private float jedaSerang = 1f;

    //state sekarang
    private StateZombie currentState = StateZombie.IDLE;
    private float waktuSerangTerakhir;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {

        PeriksaTransisi();

         switch (currentState)
         {
             case StateZombie.IDLE : PerilakuIdle(); break;
             case StateZombie.PATROL : PerilakuPatrol(); break;
             case StateZombie.CHASE : PerilakuChase(); break;
             case StateZombie.ATTACK : PerilakuAttack();break;
         }
    }

    public void Kejar()
    {
        if(player == null) return;
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy Menyerang");
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= jarakSerang)
            currentState = StateZombie.ATTACK; //sangat dekat = serang
        else if (jarak <= jarakDeteksi)
            currentState = StateZombie.CHASE; //terlihat = kejar
        else
            currentState = StateZombie.PATROL; //jauh = keliling
    }

    void PerilakuIdle()
    {
          Debug.Log("Enemy sedang IDLE");
    }

    void PerilakuPatrol()
    {
        Debug.Log("Zombie sedang Patroli");
    }
    void PerilakuChase()
    {
        Kejar();
        Debug.Log("Zombie sedang mengejar player");
    }

    void PerilakuAttack()
    {
        Debug.Log("Zombie sedang menyerang player");
    }

    public void TakeDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} kena damage {jumlah}, Hp sisa : {hp}");
        if(hp <= 0)
        {
            Mati();
        }
    }

    private void Mati()
    {
        Debug.Log($"{gameObject.name} mati!");
        Destroy(gameObject);
    }
}