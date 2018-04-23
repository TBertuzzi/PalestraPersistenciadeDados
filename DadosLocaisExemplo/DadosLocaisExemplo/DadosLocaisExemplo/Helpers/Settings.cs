// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DadosLocaisExemplo.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
        private static ISettings AppSettings => CrossSettings.Current;


        public static string Login
        {
            get => AppSettings.GetValueOrDefault(nameof(Login), "");

            set => AppSettings.AddOrUpdateValue(nameof(Login), value);

        }

    }
}