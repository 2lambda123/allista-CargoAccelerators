﻿using System;
using System.Reflection;
using AT_Utils;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("CargoAccelerators")]
[assembly: AssemblyDescription("Plugin for the Kerbal Space Program")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("AT Industries")]
[assembly: AssemblyProduct("CargoAccelerators")]
[assembly: AssemblyCopyright("Copyright © Allis Tauri 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
#if NIGHTBUILD
[assembly: AssemblyVersion("0.3.*")]
#else
[assembly: AssemblyVersion("0.3.0.1")]
#endif
[assembly: KSPAssembly("CargoAccelerators", 0, 3)]


namespace CargoAccelerators
{
    public class ModInfo : KSP_AVC_Info
    {
        public ModInfo()
        {
            MinKSPVersion = new Version(1, 12, 3);
            MaxKSPVersion = new Version(1, 12, 3);

            VersionURL =
                "https://raw.githubusercontent.com/allista/CargoAccelerators/master/GameData/CargoAccelerators/CargoAccelerators.version";
            UpgradeURL = "https://spacedock.info/mod/1123/Ground%20Construction";
            ChangeLogURL = "https://github.com/allista/CargoAccelerators/blob/master/ChangeLog.md";
        }
    }
}
