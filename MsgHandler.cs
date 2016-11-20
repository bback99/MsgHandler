using UnityEngine;
using System;
using System.Globalization;
using System.Collections;
using System.Reflection;
using Pathfinding.Serialization.JsonFx;

namespace MsgHandler {
	
	using NukeMessage;

	public class MsgHandler {
	
		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
		}
		
		public static void OnRcvMsg(Generic_Data data) {
			
			// 현재 assembly object
            Assembly assem = Assembly.GetExecutingAssembly();
			object obj = assem.CreateInstance("MsgHandler.MsgHandler");
					
			MethodInfo method = assem.GetType("MsgHandler.MsgHandler").GetMethod("OnRcvMsg_" + data.callBackFunction_.Name.ToString ());
			method.Invoke(obj, new object[]{ data.data_ });
		}
		
		
		// NukeMessage Callback Functions
		public void OnRcvMsg_AnswerBuyItem_Gold(string data)
		{
			AnswerBuyItem_Gold ans = JsonReader.Deserialize<AnswerBuyItem_Gold>( data);
			Debug.Log (string.Format ("Error_No : {0}, / Gold : {1} / item_code : {2}", ans.err_no, ans.ret_gold, ans.item_code));
		}
		
		public void OnRcvMsg_AnswerRankingData(string data)
		{
			AnswerRankingData ans = JsonReader.Deserialize<AnswerRankingData>( data);
			//Debug.Log (string.Format ("Error_No : {0}, / List_Size : {1}", ans.err_no_, ans.lstData_.Count));
			Debug.Log (string.Format ("Error_No : {0}, user_srl : {1}", ans.err_no_, ans.user_srl_));
		}
	}
}