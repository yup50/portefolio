﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HT_GameController : MonoBehaviour {
	
	public Camera cam;
	public GameObject[] balls;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public HT_HatController hatController;
	
	[SerializeField]
	private GameObject HatComp;
	
	private float maxWidth;
	private bool counting;
	public bool NextRound;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
		restartButton.SetActive(false);
	}

	void FixedUpdate () {
		if (counting) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
		}
	}

	public void StartGame () {
		Instantiate(HatComp, Vector3.zero, Quaternion.identity);
		hatController = GameObject.Find("Hat(Clone)").GetComponent<HT_HatController>();
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		restartButton.SetActive(false);
		hatController.ToggleControl (true);
		timeLeft = 120;
		StartCoroutine (Spawn ());
	}

	public IEnumerator Spawn ()
	{
		yield return new WaitForSeconds (2.0f);
		counting = true;
		while (timeLeft > 0) {
			GameObject ball = balls [Random.Range (0, balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				transform.position.x + Random.Range (-maxWidth, maxWidth), 
				transform.position.y, 
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			GameObject tempBall = Instantiate (ball, spawnPosition, spawnRotation) as GameObject;

			yield return new WaitForSeconds (Random.Range (1f, 2.0f));
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Bomb");
		foreach(GameObject enemy in enemies)
			Destroy(enemy);
		GameObject[] bowl = GameObject.FindGameObjectsWithTag("Ball");
		foreach(GameObject enemy in bowl)
			Destroy(enemy);
		Destroy(GameObject.Find("Hat(Clone)"));
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		if (!NextRound)
		{
			restartButton.SetActive(true);
		}
		else
		{
			startButton.SetActive(true);
		}
	}
}
