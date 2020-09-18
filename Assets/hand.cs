using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "collider")
        {
            Debug.Log("O");
            GameObject.Find("crazyball").SendMessage("animation12");
                
        }
    }
}
