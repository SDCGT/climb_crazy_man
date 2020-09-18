using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class physics : MonoBehaviour {
    GameObject bullets;
    const float Speed = 50f;
    Vector3 angle;
    GameObject crazyball1;
    player player1;
    // Use this for initialization
    void Start () {
        bullets = this.gameObject;
        crazyball1 = GameObject.Find("crazyball");
        player1 = crazyball1.GetComponent<player>();
        player1.ShootAngle = new Vector3(1, 0, 0);
        angle = player1.ShootAngle;
    }
	
	// Update is called once per frame
	void Update () {
        bullets.transform.Translate(angle * Speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name=="BG")
        {
            Destroy(bullets);
        }
    }
}
