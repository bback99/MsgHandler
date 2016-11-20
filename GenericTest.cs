using UnityEngine;
using System;
using System.Collections;
using NukeMessage;

using Pathfinding.Serialization.JsonFx;	

namespace MyCollections
{
	public delegate void ChangedEventHandler(object sender, Generic_Data data);

	public class ListWithChangedEvent: ArrayList 
	{
		// An event that clients can use to be notified whenever the
		// elements of the list change.
		public event ChangedEventHandler Changed;

		// Invoke the Changed event; called whenever list changes
		protected virtual void OnChanged(Generic_Data data) 
		{
			if (Changed != null) Changed(this, data);
		}

		// Override some of the methods that can change the list;
		// invoke event after each
		public override int Add(object value) 
		{
			int i = base.Add(value);

			OnChanged((Generic_Data)value);
			return i;
		}

		public override void Clear() 
		{
			base.Clear();
			OnChanged(new Generic_Data());
		}

		public override object this[int index] 
		{
			set 
			{
				base[index] = value;
				OnChanged(new Generic_Data());
			}
		}
	}
}

namespace GenericTest 
{
	using MyCollections;
	using MsgHandler;
	
	class EventListener 
	{
		private ListWithChangedEvent List;
	
		public EventListener(ListWithChangedEvent list) 
		{
			List = list;
			// Add "ListChanged" to the Changed event on "List".
			List.Changed += new ChangedEventHandler(ListChanged);
		}
	
		// This will be called whenever the list changes.
		private void ListChanged(object sender, Generic_Data data) 
		{ 
			MsgHandler.OnRcvMsg(data);
		}
	
		public void Detach() 
		{
			// Detach the event and delete the list
			List.Changed -= new ChangedEventHandler(ListChanged);
			List = null;
		}
	}
}