namespace SpaceEngineers.Tools;

public class Helper : MyGridProgram
{
    static bool GetTrue<T>() => true;
    static MyFixedPoint RawValue( long rawValue ) => new MyFixedPoint() { RawValue = rawValue };
    static List<T> GetCollectToList<T>( Action<List<T>, Func<T, bool>> action, Func<T, bool> collect = null ) { var list = new List<T>(); action( list, collect ); return list; }
    static IEnumerable<TSource> Foreach<TSource>( IEnumerable<TSource> source, Action<TSource> action = null ) { foreach ( var value in source ) { action?.Invoke( value ); yield return value; } }
}
