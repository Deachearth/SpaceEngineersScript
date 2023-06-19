namespace 测试使用;

public class Program : MyGridProgram
{
    public Program()
    {
        this.Runtime.UpdateFrequency = UpdateFrequency.Once;
        this.ReadCustomData();
    }

    public void ReadCustomData()
    {
    }

    public void Save()
    {
        this.Storage = string.Empty;
    }

    public void Main( string args, UpdateType fps )
    {
    }
}
