﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUserAttributes : MonoBehaviour {


    public Text levelText;
    public Text goldText;
    public Text gemText;
    //add friends later
    //public GameObject friends;
    // Use this for initialization
    void Start () {
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        goldText = GameObject.Find("goldText").GetComponent<Text>();
        gemText = GameObject.Find("gemText").GetComponent<Text>();
        string[] separators = {":"};
        string loginURL = "http://test1.xu4qu3w2zy.us-east-1.elasticbeanstalk.com/player.php";

        WWWForm form = new WWWForm();
        form.AddField("username", PlayerPrefs.GetString("username"));
        Debug.Log(PlayerPrefs.GetString("username"));
        form.AddField("playerAttributes", "true");
        WWW w = new WWW(loginURL, form);
        while(!w.isDone) { }
        string result = w.text;
        Debug.Log(result);
        string[] words = result.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(words[0] + " " + words[1] +  " " + words[2]);
        levelText.text = words[0];
        goldText.text = words[1];
        gemText.text = words[2];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
