namespace SpaceEngineers.Tools;

/// <summary>
/// <para>.</para>
/// <para>单位：吨。<see cref="MyFixedPoint"/>           </para>
/// <para>单位：克。<see cref="MyFixedPoint.RawValue"/>  </para>
/// </summary>
class BlockContainer
{
    static List<T> GetCollectToList<T>( Action<List<T>, Func<T, bool>> action, Func<T, bool> collect = null ) { var list = new List<T>(); action( list, collect ); return list; }
    public MyFixedPoint CurrentMass;
    public MyFixedPoint CurrentVolume;
    public MyFixedPoint MaxVolume;
    public bool HasCargos = true;
    public bool HasAssemblers = false;
    public double VolumePercentage => (double) this.CurrentVolume.RawValue / this.MaxVolume.RawValue;

    public IEnumerable<IMyInventory> Stats( IMyGridTerminalSystem grid )
    {
        if ( this.HasCargos ) foreach ( var inv in this.Stats<IMyCargoContainer>( grid ) ) yield return inv;
        if ( this.HasAssemblers ) foreach ( var inv in this.Stats<IMyAssembler>( grid ) ) yield return inv;
    }

    public IEnumerable<IMyInventory> Stats<T>( IMyGridTerminalSystem grid ) where T : class, IMyCubeBlock, IMyEntity
    {
        foreach ( var entity in GetCollectToList<T>( grid.GetBlocksOfType ).Where( x => x.IsWorking ) )
        {
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
