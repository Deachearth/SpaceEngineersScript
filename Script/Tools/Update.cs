namespace SpaceEngineers.Tools;


// <see cref="UpdateType.Update1"  />(32)  = 1
// <see cref="UpdateType.Update10" />(64)  = 10
// <see cref="UpdateType.Update100"/>(128) = 100
// <see cref="UpdateType"/>(x) =  2^x
// <see cref="UpdateFrequency"/>(x) = 10^x

struct Update
{
    public int count;
    public int total;

    public string Now => $"{(double) count / total:P}({count}/{total})";

    public Update()
    {
        this.total = 100;
    }

    public bool IsStart( UpdateType update, IMyGridProgramRuntimeInfo my )
    {
        count += (int) Math.Pow( 10, Math.Log( (int) update, 2 ) - 5 );
        if ( count >= total ) { count -= total; return true; }
        my.UpdateFrequency = DataFrequency( total - count );
        return false;
    }

    public static UpdateFrequency DataFrequency( int fps )
    {
        return fps > 100 ? UpdateFrequency.Update100 : (UpdateFrequency) Math.Pow( 2, Math.Floor( Math.Log10( fps ) ) );
    }
}

struct UpdateAction
{
    public Update Frequency;
    public int[] Times;
    public Action[] Action;

    public UpdateAction( int[] times, Action[] actions )
    {
        this.Times = times;
        this.Action = actions;
        this.Frequency.total = LCM( times );
    }

    public void Start( UpdateType update, IMyGridProgramRuntimeInfo my )
    {
        if ( this.Frequency.IsStart( update, my ) )
        {
            for ( var i = 0; i < this.Action.Length; i++ )
            {
                if ( this.Frequency.count % this.Times[ i ] == 0 )
                {
                    this.Action[ i ]();
                }
            }
        }
    }

    public static int LCM( params int[] args )
    {
        if ( args.Length == 1 ) return args[ 0 ];
        var gcd = args[ 0 ]; for ( var i = 1; i < args.Length; i++ ) gcd = GCD( gcd, args[ i ] );
        var total = args[ 0 ]; for ( var i = 1; i < args.Length; i++ ) total *= args[ i ] / gcd;
        return total;
    }

    public static int GCD( int left, int right )
    {
        // greatest common divisor
        if ( left == 0 ) return right;
        if ( right == 0 ) return left;
        if ( (left | right) % 2 == 0 ) return GCD( left >> 1, right >> 1 ) << 1;
        if ( left % 2 == 0 ) return GCD( left >> 1, right );
        if ( right % 2 == 0 ) return GCD( left, right >> 1 );
        return GCD( Math.Abs( left - right ), Math.Min( left, right ) );
    }
}
