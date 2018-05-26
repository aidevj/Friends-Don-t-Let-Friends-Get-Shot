using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
public class Player : MonoBehaviour {
	public int playerNumber;		// 0: P1 ; 1: P2
	public float speed = 1f;

	private int ammo; // 弾丸の量	
						// shared ammo

	private string controlAxisX;
	private string controlAxisY;

	void Start () {
		//コントロールをロードする
		switch (playerNumber) {
			case 0:
				controlAxisX = "Horizontal_P1";
				controlAxisY = "Vertical_P1";
				break;
			case 1:
				controlAxisX = "Horizontal_P2";
				controlAxisY = "Vertical_P2";
				break;
		}
	}

	void Update () {
		Move ();
	}

	void Move() {
		transform.Translate (Input.GetAxis (controlAxisX) * speed, Input.GetAxis (controlAxisY), 0);

	}
}
