﻿namespace UniModules.UniGame.UniBuild.Editor.ClientBuild.Commands.PreBuildCommands
{
    using System;
    using global::UniGame.UniBuild.Editor.ClientBuild.Interfaces;
    using Interfaces;
    using UnityEditor;
    using UnityEditor.Build;

#if ODIN_INSPECTOR
     using Sirenix.OdinInspector;
#endif

#if TRI_INSPECTOR
    using TriInspector;
#endif
    
    [Serializable]
    public class ApplyAndroidSettingsCommand : UnitySerializablePreBuildCommand
    {
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineProperty] 
        [HideLabel]
#endif
        public UniAndroidSettings AndroidSettings = new UniAndroidSettings();

        public override void Execute(IUniBuilderConfiguration buildParameters) => Execute();

#if ODIN_INSPECTOR || TRI_INSPECTOR
        [Button]
#endif
        public void Execute()
        {
#if UNITY_2021_1_OR_NEWER
            EditorUserBuildSettings.androidCreateSymbols = AndroidSettings.AndroidDebugSymbolsMode;
#endif
            EditorUserBuildSettings.connectProfiler = AndroidSettings.AutoConnetcProfiler;
            EditorUserBuildSettings.androidBuildSubtarget = AndroidSettings.TextureCompression;
            EditorUserBuildSettings.androidBuildType = AndroidSettings.AndroidBuildType;
            EditorUserBuildSettings.buildAppBundle = AndroidSettings.BuildAppBundle;
            EditorUserBuildSettings.allowDebugging = AndroidSettings.AllowDebugging;
            EditorUserBuildSettings.exportAsGoogleAndroidProject = AndroidSettings.ExportAsGoogleAndroidProject;
            EditorUserBuildSettings.development = AndroidSettings.IsDevelopment;
            
            PlayerSettings.Android.targetArchitectures = AndroidSettings.AndroidArchitecture;
            PlayerSettings.Android.forceSDCardPermission = AndroidSettings.ForceSDCardPermission;
            PlayerSettings.Android.forceInternetPermission = AndroidSettings.ForceInternetPermission;
            PlayerSettings.Android.splitApplicationBinary = AndroidSettings.SplitApplicationBinary;
#if !UNITY_2023_1_OR_NEWER
            EditorUserBuildSettings.androidETC2Fallback = AndroidSettings.SplitApplicationBinary;
            PlayerSettings.Android.useAPKExpansionFiles = AndroidSettings.UseAPKExpansionFiles;
            
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, AndroidSettings.ApiCompatibilityLevel);
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, AndroidSettings.ScriptingBackend);
            PlayerSettings.SetIl2CppCompilerConfiguration(BuildTargetGroup.Android,AndroidSettings.CppCompilerConfiguration);
#else
            PlayerSettings.SetApiCompatibilityLevel(NamedBuildTarget.Android, AndroidSettings.ApiCompatibilityLevel);
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, AndroidSettings.ScriptingBackend);
            PlayerSettings.SetIl2CppCompilerConfiguration(NamedBuildTarget.Android,AndroidSettings.CppCompilerConfiguration);
#endif
            
        }
    }
}