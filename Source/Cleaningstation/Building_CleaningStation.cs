using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using HugsLib;
using UnityEngine;



namespace CleaningStation
{
	/// <summary>
	/// Basic functionality for the CleaningStation to work.
	/// </summary>
	public class Building_CleaningStation : Building
	{
		
		public CompPowerTrader compPowerTrader;
		
		
		public IEnumerable<IntVec3> cleanableCells
		{
			get
			{
				return GenRadial.RadialCellsAround(base.Position,CleaningStationSettings.GetCleanRadius(), true);
			}
		}
		
		
		public override void SpawnSetup(Map map,bool respawningAfterLoad)
		{
			base.SpawnSetup(map,respawningAfterLoad);
			this.compPowerTrader = base.GetComp<CompPowerTrader>();
			
			HugsLibController.Instance.DistributedTicker.RegisterTickability(CleanTick,CleaningStationSettings.GetCleanTime(),this);
		}
		
		
		public void CleanTick()
		{
			if(CleaningStationSettings.isDynamicPower())
			{
				float powerFactor = -1f*(500f/(500f+(float)cleanableCells.Count()));
				compPowerTrader.PowerOutput =Mathf.Round(CleaningStationSettings.GetPowerConsumption()*cleanableCells.Count()*powerFactor);
				
			}
			
			if(compPowerTrader.PowerOn)
			{				
				foreach(IntVec3 cleanMe in cleanableCells)
				{
					FilthMaker.RemoveAllFilth(cleanMe,this.Map);
				}
			}		
		}
		
	}
}