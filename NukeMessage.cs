using UnityEngine;
using System.Collections;
using System;
using Pathfinding.Serialization.JsonFx;

namespace NukeMessage {
	
	public class Generic_Data {
		public Type callBackFunction_;
		public string data_;
	}
	
/*	public enum MsgID {
		MsgID_InValid = 0,
		e_RequestBuyItem_Gold,
		e_RequestRankingData,
		
		e_AnswerBuyItem_Gold = 10000,
		e_MsgID_MAX = 9999999
	}*/
	
	public class RequestBuyItem_Gold {
			
		public int user_srl;
		public int item_id;
	}
	
	class RequestRankingData {
				
		public int user_srl;
	}
	
	class RequestItemList {
				
		public int user_srl;
	}
	
	/// <summary>
	/// Must be to add get; set functions each member variables
	/// </summary>
	public class AnswerBuyItem_Gold
	{
		public int err_no { get; set; } 
		public int ret_gold { get; set; }
		public int item_code { get; set; }
	}
	
	public class AnswerRankingData
	{
		public int err_no_ { get; set; } 
		public int user_srl_ { get; set; }
		//public ArrayList lstData_ { get; set; }
	}
	
	public class AnswerItemList
	{
		public int err_no_ { get; set; } 
		public int user_srl_ { get; set; }
		//public ArrayList lstData_ { get; set; }
	}
}
