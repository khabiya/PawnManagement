

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PawnManagement.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PawnManagement.accdb")]
    public string PawnManagementConnectionString => (string) this[nameof (PawnManagementConnectionString)];

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Debug\\PawnManagement.accdb")]
    public string PawnManagementConnectionString1 => (string) this[nameof (PawnManagementConnectionString1)];

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\VisualstudioPojects\\PawnStar\\Debug\\pawnmanagement.accdb")]
    public string pawnmanagementConnectionString2 => (string) this[nameof (pawnmanagementConnectionString2)];
  }
}
