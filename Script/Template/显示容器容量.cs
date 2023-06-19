namespace 显示容器容量;

public class Program : MyGridProgram
{

    #region 显示容器容量[普通版]

    /*
    uint Update = 0;
    public void Main( string args )
    {
        MyFixedPoint CurrentMass = 0;
        MyFixedPoint CurrentVolume = 0;
        MyFixedPoint MaxVolume = 0;

        var cargos = GetCollectToList<IMyCargoContainer>( this.GridTerminalSystem.GetBlocksOfType ).Where( x => x.IsWorking ).ToList();
        foreach ( var value in cargos )
        {
            if ( !value.HasInventory ) continue;
            for ( var i = 0; i < value.InventoryCount; i++ )
            {
                var inv = value.GetInventory( i );
                CurrentMass += inv.CurrentMass;
                CurrentVolume += inv.CurrentVolume;
                MaxVolume += inv.MaxVolume;
            }
        }

        this.Echo( $"={Update++}=" );
        this.Echo( $"容器数量：{cargos.Count}个" );
        this.Echo( $"当前质量：{(double) CurrentMass:F3}kg" );
        this.Echo( $"当前容量：{CurrentVolume * 1000}L" );
        this.Echo( $"最大容量：{MaxVolume * 1000}L [[{1D * CurrentVolume.RawValue / MaxVolume.RawValue:P}]]" );
    }

    public Program()
    {
        this.Runtime.UpdateFrequency = UpdateFrequency.Update100;
        if ( string.IsNullOrWhiteSpace( this.Me.CustomData ) )
        {
            var ini = new CustomConfig();
            this.Block.Read( ini );
            this.Me.CustomData = ini.ToString();
        }
    }
    */

    #endregion


    #region 显示容器容量[谈对象版]

    static List<T> GetCollectToList<T>( Action<List<T>, Func<T, bool>> action, Func<T, bool> collect = null ) { var list = new List<T>(); action( list, collect ); return list; }
    public void Main( string args, UpdateType fps )
    {
        this.ReadConfig();
        this.Echo( $"={Update++}{ReadConfigError}=" );

        var cargos = this.Block.Stats( this.GridTerminalSystem ).ToList();
        this.Echo( $"容器数量：{this.Block.Count}个" );
        this.Echo( $"当前质量：{(double) this.Block.CurrentMass:F3}kg" );
        this.Echo( $"当前容量：{this.Block.CurrentVolume * 1000}L" );
        this.Echo( $"最大容量：{this.Block.MaxVolume * 1000}L [[{this.Block.VolumePercentage:P}]]" );
    }

    uint Update = 0;
    BlockContainer Block = new BlockContainer();
    string ReadConfigError = string.Empty;

    void ReadConfig()
    {
        this.Block.Reset();
        var ini = new CustomConfig();
        ini.Read( this.Me.CustomData );
        this.Block.Read( ini );
        this.ReadConfigError = ini.ReadConfigError;
    }

    class BlockContainer
    {
        public MyFixedPoint CurrentMass;
        public MyFixedPoint CurrentVolume;
        public MyFixedPoint MaxVolume;
        public int Count = 0;
        public bool HasCargos = true;
        public bool HasAssemblers = false;
        public double VolumePercentage => 1D * this.CurrentVolume.RawValue / this.MaxVolume.RawValue;

        public void Reset()
        {
            this.CurrentMass = 0;
            this.CurrentVolume = 0;
            this.MaxVolume = 0;
            this.Count = 0;
        }

        public IEnumerable<IMyInventory> Stats( IMyGridTerminalSystem grid )
        {
            if ( this.HasCargos ) foreach ( var inv in this.Stats<IMyCargoContainer>( grid ) ) yield return inv;
            if ( this.HasAssemblers ) foreach ( var inv in this.Stats<IMyAssembler>( grid ) ) yield return inv;
        }

        public IEnumerable<IMyInventory> Stats<T>( IMyGridTerminalSystem grid ) where T : class, IMyCubeBlock, IMyEntity
        {
            foreach ( var entity in GetCollectToList<T>( grid.GetBlocksOfType ).Where( x => x.IsWorking ) )
            {
                if ( !entity.HasInventory ) continue;
                this.Count++;
                for ( var i = 0; i < entity.InventoryCount; i++ )
                {
                    var inv = entity.GetInventory( i );
                    this.CurrentMass += inv.CurrentMass;
                    this.CurrentVolume += inv.CurrentVolume;
                    this.MaxVolume += inv.MaxVolume;
                    yield return inv;
                }
            }
        }

        public void Read( CustomConfig ini )
        {
            const string TITLE = "是否统计";
            this.HasCargos = ini.ToBoolean( TITLE, "箱子", true );
            this.HasAssemblers = ini.ToBoolean( TITLE, "工作台", false );
        }
    }
    class CustomConfig : MyIni
    {
        public string ReadConfigError = string.Empty;

        public bool Read( string content )
        {
            MyIniParseResult result;
            this.ReadConfigError = this.TryParse( content, out result ) ? string.Empty : $"[{result.LineNo,2}] {result.Error}";
            return result.Success;
        }

        public bool ToBoolean( string s, string n, bool d = false ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToBoolean(); this.Set( s, n, d ); return d; }
    }

    #endregion

}
