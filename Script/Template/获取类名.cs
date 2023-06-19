namespace 获取类名;

public class Program : MyGridProgram
{
    public Program()
    {
        this.Runtime.UpdateFrequency = UpdateFrequency.Once;
    }

    int Version = 0;
    SearchBlock Search = new SearchBlock();
    public void Main( string args, UpdateType fps )
    {
        this.Echo( $"==={Version++}===" );

        this.Search.Search( args, this.GridTerminalSystem );
        if ( this.Search.Result.Count == 0 )
        {
            this.Echo( $"未找到[[{args}]]方块。" );
        }
        else
        {
            this.Search.Result.ForEach( b => this.Echo( $"[[{b.CustomName}]] {b.GetType()}" ) );
        }
    }

    class SearchBlock
    {
        public string Name;
        public Func<IMyTerminalBlock, bool> Collect;
        public List<IMyTerminalBlock> Result { get; private set; }

        public bool Search( string name, IMyGridTerminalSystem grid )
        {
            if ( this.Name.Equals( name, StringComparison.InvariantCultureIgnoreCase ) )
            {
                return false;
            }

            this.Result = new List<IMyTerminalBlock>();
            grid.SearchBlocksOfName( name, this.Result, this.Collect );
            return true;
        }
    }
}
