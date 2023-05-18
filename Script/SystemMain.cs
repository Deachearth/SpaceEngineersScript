using static System.Console;

// 需要更改 Directory.Build.props 文件里面的节点 <Project><PropertyGroup><SEBinPath> 路径
// 路径指定 SpaceEngineers 游戏的文件夹的 Bin64 文件夹下。例如 E:\SteamApps\steamapps\common\SpaceEngineers\Bin64\
namespace Deachearth;

internal class SystemMain
{
    public static void Main( string[] args )
    {
        WriteLine( "Hi!" );

        WriteLine( "Hello, World!" );
    }
}
