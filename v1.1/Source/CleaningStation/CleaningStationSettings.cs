using HugsLib;
using HugsLib.Settings;
using Verse;

namespace CleaningStation{
	public class CleaningStationSettings : ModBase{
		public override string ModIdentifier{
			get { return "CleaningStation"; }
		}
		
		private static SettingHandle<int> cleanTime;
		private static SettingHandle<float> cleanRadius;
		private static SettingHandle<float> powerConsumption;
		private static SettingHandle<bool> useDynamicPower;
		
		
		public override void DefsLoaded(){
			cleanTime = Settings.GetHandle<int>("cleanTime","CleaningStation_settings_cleanTime_label".Translate(),"CleaningStation_settings_cleanTime_desc".Translate(),1200,Validators.IntRangeValidator(60,3600));
			cleanRadius = Settings.GetHandle<float>("cleanRadius","CleaningStation_settings_cleanRadius_label".Translate(),"CleaningStation_settings_cleanRadius_desc".Translate(),5f,Validators.FloatRangeValidator(1f,50f));
			useDynamicPower = Settings.GetHandle<bool>("useDynamicPower","CleaningStation_settings_useDynamicPower_label".Translate(),"CleaningStation_settings_useDynamicPower_desc".Translate(),false);
			powerConsumption = Settings.GetHandle<float>("powerConsumption","CleaningStation_settings_powerConsumption_label".Translate(),"CleaningStation_settings_powerConsumption_desc".Translate(),10f,Validators.FloatRangeValidator(1f,100f));
			
		}
		
		public static int GetCleanTime(){
			return cleanTime.Value;
		}
		public static float GetCleanRadius(){
			return cleanRadius.Value;
		}
		public static float GetPowerConsumption(){
			return powerConsumption.Value;
		}
		public static bool isDynamicPower(){
			return useDynamicPower.Value;
		}
	}
}