/*
 * Created by SharpDevelop.
 * User: Tobias
 * Date: 03.08.2018
 * Time: 10:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using Verse;

namespace CleaningStation
{
	/// <summary>
	/// Description of PlaceWorker_CleaningStation.
	/// </summary>
	public class PlaceWorker_CleaningStation : PlaceWorker
	{
		public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol)
		{
			Map currentMap = Find.CurrentMap;
			GenDraw.DrawRadiusRing(center, CleaningStationSettings.GetCleanRadius());
		}
	}
}
