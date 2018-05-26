using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ゲームの状況
public enum GameState {
	MainMenu,	//　タイトル
	Game,		//　ゲーム中
	Pause,	
	Win,		// 勝った
	Lose		// 負けた
};

public class GameManager : MonoBehaviour {

	public int ammo = 100; // 弾丸の量	。二人のプレイヤーは同じ量を使う

	public GameObject ammoPrefab;
	public GameObject playerPrefab;
	public GameObject playerBulletPrefab_Blue;
	public GameObject playerBulletPrefab_Red;

	public GameState gameState = GameState.Game;	//テスト

	[HideInInspector]public Player p1;
	[HideInInspector]public Player p2;

	void Start () {
		// ＊＊いつもタイトルからゲームをロードしてください＊＊
		//gameState = GameState.MainMenu;



		// テスト
		p1 = GameObject.Find ("Player1").GetComponent<Player> ();
		p2 = GameObject.Find ("Player2").GetComponent<Player> ();
	}

	void Update () {


		// ゲームのチェック
		if (gameState == GameState.Game) {
			if (p1.IsDead () || p2.IsDead ()) {
				ChangeState (GameState.Lose);
			}	
		}
			
	}
		
	/// <summary>
	/// GameStateを変える
	/// </summary>
	/// <param name="newState">次のGameState状況.</param>
	public void ChangeState(GameState newState) {
		gameState = newState;

		// Game
		if (newState == GameState.Game) {
			p1 = GameObject.Find ("Player1").GetComponent<Player> ();
			p2 = GameObject.Find ("Player2").GetComponent<Player> ();

			p1.ControllerEnabled = true;
			p2.ControllerEnabled = true;
		} else if (newState == GameState.Lose) {
			// 負けるスクリーンをロードする
			p1.ControllerEnabled = false;
			p2.ControllerEnabled = false;
		}
		else if (newState == GameState.Win) {
			// 勝利スクリーンをロードする
			p1.ControllerEnabled = false;
			p2.ControllerEnabled = false;
		}

	}
		
}
