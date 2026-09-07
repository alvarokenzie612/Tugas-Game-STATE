using UnityEngine;
using System;

public class BelajarDelegate : MonoBehaviour
{

    delegate void delegateContoh();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ujiDelegate1();
        ujiDelegate2();
        ujiDelegate3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ujiDelegate1()
    {
        delegateContoh Panggil = PanggilHello;
        Panggil();
    }

    void ujiDelegate2()
    {
        delegateContoh Panggil = PanggilHello;
        Panggil += PanggilNama;
        Panggil();
    }

    void ujiDelegate3()
    {
        Action halo = PanggilHello;
        halo += PanggilNama;
        halo();
    }

    void PanggilHello()
    {
        Debug.Log("Hello");
    }

    void PanggilNama()
    {
        Debug.Log("Nama saya Alvaro");
    }
}
