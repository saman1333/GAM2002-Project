using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControls : MonoBehaviour {

    public PlayerController playerScript;

    private PlayerController playerS;

	// Use this for initialization
	void Start () {
        playerS = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void iJump()
    {
        playerS.JumpMe();
    }

    public void iMoveLeft()
    {
        playerS.moveLeft();
    }

    public void iMoveRight()
    {
        playerS.moveRight();
    }

    public void iShoot()
    {
        playerS.shootBullet();
    }

    public void iHide()
    {
        playerS.hideMe();

    }

    public void iDontHide()
    {
        playerS.dontHideMe();
    }
}
