using UnityEngine;
using System.Collections;
//using MsgSend;
//using NukeMessage;
/*
public class TestGui : MonoBehaviour {
	
	GameObject gameInfoObject;
	MsgSender	sender_;

	// Use this for initialization
	void Start () {
		
		gameInfoObject = GameObject.Find("GameInfo");
		if( gameInfoObject == null)
			gameInfoObject = GameInfo.CreateInstance();	
		
		sender_ = new MsgSender();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ClickedRankingBtn()
	{
		Debug.Log ( "ClickedRankingBtn");
	}
		
	void ClieckedStoreBtn()
	{
		Debug.Log ("ClickedShopBtn");
		
		gameInfoObject.GetComponent<GameInfo>().LoadScene( "shop");
	}
	
	void ClickedShopBackBtn()
	{
		Debug.Log ("ClickedShopBtn");
		
		gameInfoObject.GetComponent<GameInfo>().LoadScene( "main");
	}
	
	void ClickedShopTest1()
	{
		Debug.Log ("ClickedShopTest1");
		
		sender_.Send<RequestBuyItem_Gold>("http://10.22.96.220/shoong/request_buy_item.php", typeof(AnswerBuyItem_Gold), 1, 10001);
	}
	
	void ClickedShopTest2()
	{
		Debug.Log ("ClickedShopTest2");
		
		sender_.Send<RequestRankingData>("http://10.22.96.220/shoong/request_ranking.php", typeof(AnswerRankingData), 1);
	}
	
	void ClickedShopTest3()
	{
		Debug.Log ("ClickedShopTest3");
		
		sender_.Send<RequestItemList>("http://10.22.96.220/shoong/request_ranking.php", typeof(AnswerItemList), 1);
	}
}
 */