using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public PlayerHealthBar bar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("asdsa");
            bar.SetHealthBar(10);
        }
    }
}
