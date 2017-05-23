using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using GenericTest;
using MyCollections;
using NukeMessage;

public class CallHttp : MonoBehaviour {
	
	public static GameObject instance_;
    
    //////
    
	
	ListWithChangedEvent list_;
	EventListener listener_;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Start!!!!");
		
		list_ = new ListWithChangedEvent();
	
	    // Create a class that listens to the list's change event.
		listener_ = new EventListener(list_);
	}
	
	void Awake () {
		DontDestroyOnLoad( transform.gameObject);
	}
	
	private static GameObject CreateInstance()
	{
		GameObject callHttpObject = Instantiate( new GameObject()) as GameObject;
		callHttpObject.AddComponent<CallHttp>();
		callHttpObject.name = "CallHttp";
		instance_ = callHttpObject;
		return callHttpObject;
	}
	
	public static GameObject GetInstance()
	{
		instance_ = GameObject.Find ("CallHttp");
		if (instance_ == null)
			instance_ = CallHttp.CreateInstance();
		
		return instance_;
	}
	
	public IEnumerator CallHTTPService(string url, Type callBackFunction, string input_data, Hashtable header)
	{
		var encoding = new System.Text.UTF8Encoding();
		WWW www = new WWW( url, encoding.GetBytes(input_data), header );
		
		while (!www.isDone)
		{
			yield return null;
		}
		
		if (!www.isDone || !string.IsNullOrEmpty(www.error))
		{
			// To process MsgHandler
			Debug.Log ("Error");
            yield break;
       	}
		else
		{
			string rcv_data = www.text;
			rcv_data.Trim();
			
			Generic_Data data = new Generic_Data();
			data.callBackFunction_ = callBackFunction;
			data.data_ = rcv_data;
			
			list_.Add(data);
		}
	}
	
	public void PackingToJsonFX(string url, Type callBackFunction, ArrayList lstKeyName, ArrayList lstValues) {
		
		// For call WebPage by JsonFX //
		Dictionary<string,string> dic = new Dictionary<string, string>();
		
		for(int i=0; i<lstKeyName.Count; i++)
		{
			Debug.Log (string.Format ("KeyName : {0} // Values : {1}", lstKeyName[i].ToString(), lstValues[i].ToString()));
			dic.Add ( lstKeyName[i].ToString(), lstValues[i].ToString() );
		}
		
		string input_data = JsonWriter.Serialize( dic );
		
		Hashtable header = new Hashtable();
		
		header.Add ("Content-Type", "text/json");
		header.Add ("Content-Length", input_data.Length );
		
		StartCoroutine(CallHTTPService(url, callBackFunction, input_data, header));	
	}
}
