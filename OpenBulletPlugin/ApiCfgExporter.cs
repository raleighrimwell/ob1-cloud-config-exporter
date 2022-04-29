using PluginFramework;
using PluginFramework.Attributes;
using RuriLib;
using RuriLib.Interfaces;
using RuriLib.Models;
using RuriLib.ViewModels;
using System.IO;
using OpenBullet.ViewModels;
using OpenBullet;

namespace OpenBulletPlugin
{
    public class ApiCfgExporter : IPlugin
    {
        // The name of the plugin shown in the dropdown box
        public string Name => "API CFG Exporter";


        [Button("Export Remote CFGs")]
        public void Execute(IApplication app)
        {
            ConfigManagerViewModel vm = OB.ConfigManager;
            foreach (var config in vm.Configs)
            {
                if (!config.Remote)
                {
                    continue;
                }
                //IOManager.SaveConfig(config.Config, @"Configs/");
                Directory.CreateDirectory(Path.Combine("Configs" + "/APIExported"));
                string newPath = Path.Combine(Directory.GetCurrentDirectory() + @"/Configs/APIExported/" + $"{config.Name}.loli");
                File.WriteAllText(newPath, IOManager.SerializeConfig(config.Config));

            }
            app.Logger.Log("Configs saved to " + Path.Combine(Directory.GetCurrentDirectory() + @"/Configs/APIExported/"), LogLevel.Info, true);
        }
    }
}
