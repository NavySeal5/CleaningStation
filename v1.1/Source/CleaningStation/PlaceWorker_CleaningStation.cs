using UnityEngine;
using Verse;

namespace CleaningStation{
	public class PlaceWorker_CleaningStation : PlaceWorker
	{
		public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol,Thing thing=null)
		{
			Map currentMap = Find.CurrentMap;
			GenDraw.DrawRadiusRing(center, CleaningStationSettings.GetCleanRadius());
		}
	}
}