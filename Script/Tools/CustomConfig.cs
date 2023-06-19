namespace SpaceEngineers.Tools;

class CustomConfig : MyIni
{
    public string ReadConfigError = string.Empty;

    public bool Read( string content )
    {
        MyIniParseResult result;
        this.ReadConfigError = this.TryParse( content, out result ) ? string.Empty : $"[{result.LineNo,2}] {result.Error}";
        return result.Success;
    }

    public int ToInt32( string s, string n, int d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToInt32(); this.Set( s, n, d ); return d; }
    public bool ToBoolean( string s, string n, bool d = false ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToBoolean(); this.Set( s, n, d ); return d; }
    public string ToString( string s, string n, string d = null ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToString(); this.Set( s, n, d ); return d; }
    public byte ToByte( string s, string n, byte d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToByte(); this.Set( s, n, d ); return d; }
    public char ToChar( string s, string n, char d = '\0' ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToChar(); this.Set( s, n, d ); return d; }
    public decimal ToDecimal( string s, string n, decimal d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToDecimal(); this.Set( s, n, d ); return d; }
    public double ToDouble( string s, string n, double d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToDouble(); this.Set( s, n, d ); return d; }
    public short ToInt16( string s, string n, short d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToInt16(); this.Set( s, n, d ); return d; }
    public long ToInt64( string s, string n, long d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToInt64(); this.Set( s, n, d ); return d; }
    public sbyte ToSByte( string s, string n, sbyte d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToSByte(); this.Set( s, n, d ); return d; }
    public float ToSingle( string s, string n, float d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToSingle(); this.Set( s, n, d ); return d; }
    public ushort ToUInt16( string s, string n, ushort d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToUInt16(); this.Set( s, n, d ); return d; }
    public uint ToUInt32( string s, string n, uint d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToUInt32(); this.Set( s, n, d ); return d; }
    public uint ToUInt32( string s, string n, int b, uint d = 0 ) { if ( this.ContainsKey( s, n ) ) return Convert.ToUInt32( this.ToString( s, n ), b ); this.Set( s, n, $"0x{d:X8}" ); return d; }
    public ulong ToUInt64( string s, string n, ulong d = 0 ) { if ( this.ContainsKey( s, n ) ) return this.Get( s, n ).ToUInt64(); this.Set( s, n, d ); return d; }
    public void Delete( string s ) { var l = new List<MyIniKey>(); this.GetKeys( s, l ); l.ForEach( this.Delete ); }
}
