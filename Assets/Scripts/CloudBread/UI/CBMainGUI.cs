﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class CBMainGUI : CBBaseUI
{
	// Use this for initialization
	void Start () {
		ContentAreaRect = new Rect (MainAreaRect.width/2 - (contentWidth/2), MainAreaRect.y, contentWidth, MainAreaRect.height);
	}

	public int contentWidth = 700;
	private Rect ContentAreaRect;

	private string PathString = "api/ping";

	// Headers
	/*
	 * 	Accept-Encoding:gzip
		Accept:application/json
		X-ZUMO-VERSION:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		X-ZUMO-FEATURES:AJ
		ZUMO-API-VERSION:2.0.0
		User-Agent:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		Content-Type:application/json
	 *
	 */

	private void HTTPRequestSend (){

	}

	private void HTTPRequestAuthSend(){

	}

	private IEnumerator  WaitForRequest(WWW www) {

		yield return www;

		RequestResultJson = www.text;

		www.Dispose();
	}
		

	public void OnGUI(){
		GUILayout.BeginArea(ContentAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Server Address : ", GUILayout.Width(180));
					ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(500));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Path : ", GUILayout.Width(180));
					PathString = GUILayout.TextField(PathString, GUILayout.Width(500));
				GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ();
						if (GUILayout.Button ("Send", GUILayout.Width (80))) {
							HTTPRequestSend ();
						}
						if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
							HTTPRequestAuthSend ();
						}
					GUILayout.EndHorizontal ();
					GUILayout.Label ("");
					GUILayout.Label ("결 과 : ");
					RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Width(contentWidth), GUILayout.Height(300));
			GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}
