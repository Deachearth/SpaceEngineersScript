global using System;
global using System.Linq;
global using System.Collections;
global using System.Collections.Generic;
global using System.Timers;
global using System.Text;
global using Sandbox.Game.EntityComponents;
global using Sandbox.Game.Gui;
global using Sandbox.Game.Localization;
global using Sandbox.ModAPI.Ingame;
global using Sandbox.ModAPI.Interfaces;
global using SpaceEngineers.Game.ModAPI.Ingame;
global using VRage;
global using VRage.Collections;
global using VRage.Game;
global using VRage.Game.Components;
global using VRage.Game.GUI.TextPanel;
global using VRage.Game.ModAPI.Ingame;
global using VRage.Game.ModAPI.Ingame.Utilities;
global using VRage.Game.ObjectBuilders.Definitions;
global using VRage.ObjectBuilders;
global using VRageMath;

namespace DefaultProgram;

// 需要更改 Directory.Build.props 文件里面的节点 <Project><PropertyGroup><SEBinPath> 路径
// 路径指定 SpaceEngineers 游戏的文件夹的 Bin64 文件夹下。例如 E:\SteamApps\steamapps\common\SpaceEngineers\Bin64\
internal class Program : MyGridProgram
{
    public Program()
    {
        // 构造函数，每次脚本运行时会被首先调用一次。用它来初始化脚本。
        //  构造函数是可选项，
        // 如不需要可以删除。
        // 
        // 建议这里设定 RuntimeInfo.UpdateFrequency，
        // 这样脚本就不需要定时器方块也能自动运行了。

        this.Runtime.UpdateFrequency = UpdateFrequency.Once;
    }

    public void Save()
    {
        // 当程序需要保存时，会发出提醒。使用这种方法可以将状态保存
        // 至内存或其他路径。此为备选项，
        // 如果不需要，可以删除。

        this.Storage = string.Empty;
    }

    public void Main( string argument, UpdateType updateSource )
    {
        // 脚本的主入口点，每次调用可编程模块运行操作的一个调用。
        // 该入口点本身是必需的。UpdateSource参数指明更新的来源。
        // 需要使用此方法，但上述参数如果不需要，可以删除。
    }
}
