﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AprajitaRetailsDataBase.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"D:\\VISUAL STUDIO 2017\\PROJECT" +
            "S\\APRAJITARETAILS\\APRAJITARETAILMONITOR\\BIN\\DEBUG\\APRAJITARETAILS.MDF\";Integrate" +
            "d Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False")]
        public string D__VISUAL_STUDIO_2017_PROJECTS_APRAJITARETAILS_APRAJITARETAILMONITOR_BIN_DEBUG_APRAJITARETAILS_MDFConnectionString {
            get {
                return ((string)(this["D__VISUAL_STUDIO_2017_PROJECTS_APRAJITARETAILS_APRAJITARETAILMONITOR_BIN_DEBUG_AP" +
                    "RAJITARETAILS_MDFConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLExpress;AttachDbFilename=|DataDirectory|\\VoygerDatabase.mdf;Inte" +
            "grated Security=True;Connect Timeout=30;User Instance=True")]
        public string VoygerDatabaseConnectionString {
            get {
                return ((string)(this["VoygerDatabaseConnectionString"]));
            }
        }
    }
}
