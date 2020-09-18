using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DG.Tweening;

public class player : MonoBehaviour {
    Transform players;
    Vector3 shootAngle;
    Camera cam;
    //GameObject bullet;
    //GameObject bullets;
    Transform hand;
    Transform jumphand; 
    const float Speed=10f;
    Vector3 setShootAngle;
    bool canjump = false;

    void Start()
    {
        cam = Camera.main;
        players = this.GetComponent<Transform>();
        //LayerMask floorMask = 1 << 8;
        //bullet = Resources.Load<GameObject>("prefabs/bullet");
        hand = transform.Find("hand");
        Tweener tweener = hand.DOBlendableScaleBy(new Vector3(0, 1.4f, 0), 0.4f);

        tweener.Pause();
        tweener.SetEase(Ease.OutBack);
        tweener.SetAutoKill(false);
        //tweener.OnComplete();//动画结束事件

        Tweener tweener1 = hand.DOBlendableLocalMoveBy(Vector3.up * 0.1f, 0.4f);
        tweener1.Pause();
        tweener1.SetEase(Ease.OutBack);//动画曲线
        tweener1.SetAutoKill(false);
        //tweener.SetLoops(1);//动画循环次数
    }

    void Update()
    {
        
        Turning();
        if (Input.GetMouseButtonDown(0)&&canjump==true)
        {
            hand.DOPlayForward();
        }

        if (Physics2D.Raycast(hand.transform.position, players.up, 2.7f,
               1 << LayerMask.NameToLayer("Collider")))
        {
            canjump = true;
        }

        if(!Physics2D.Raycast(hand.transform.position, players.up, 2.7f,
               1 << LayerMask.NameToLayer("Collider")))
        {
            canjump = false;
        }

    }

    void animation12()
    {
            hand.DOPlayBackwards();
            Tweener tweener1 = players.DOBlendableLocalMoveBy(-players.up * 4f, 0.4f);
    }

    void Turning()
    {
        Vector3 playerposition = cam.WorldToScreenPoint(players.transform.position);
        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = playerposition.z;
        players.transform.up = mouseposition - playerposition;
    }

    public Vector3 ShootAngle
    {
        get
        {
            return shootAngle;
        }

        set
        {
            shootAngle = players.up;
        }
    }

}
