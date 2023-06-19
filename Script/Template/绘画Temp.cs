namespace 绘画Temp;

public class Program : MyGridProgram
{

    IMyTextSurface _drawingSurface;
    RectangleF _viewport;

    // Script constructor
    public Program()
    {
        // Me is the programmable block which is running this script.
        // Retrieve the Large Display, which is the first surface
        this._drawingSurface = this.Me.GetSurface( 0 );

        // Set the continuous update frequency of this script
        this.Runtime.UpdateFrequency = UpdateFrequency.Update100;

        // Calculate the viewport offset by centering the surface size onto the texture size
        this._viewport = new RectangleF( ( this._drawingSurface.TextureSize - this._drawingSurface.SurfaceSize ) / 2F, this._drawingSurface.SurfaceSize );
    }

    // Main Entry Point
    public void Main ( string a, UpdateType u )
    {
        // Begin a new frame
        var frame = this._drawingSurface.DrawFrame();

        // All sprites must be added to the frame here
        this.DrawSprites( ref frame );

        // We are done with the frame, send all the sprites to the text panel
        frame.Dispose();
    }

    // Drawing Sprites
    public void DrawSprites ( ref MySpriteDrawFrame frame )
    {
        // Set up the initial position - and remember to add our viewport offset
        var position = new Vector2( 0, 20 ) + this._viewport.Position;

        // Create our first line
        var sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = this._viewport.ToString(),
            Position = position,
            RotationOrScale = 0.8f /* 80 % of the font's default size */,
            Color = Color.Red,
            Alignment = TextAlignment.CENTER /* Center the text on the position */,
            FontId = "White"
        };
        // Add the sprite to the frame
        frame.Add( sprite );

        // Move our position 20 pixels down in the viewport for the next line
        position += new Vector2( 0, 20 );

        // Create our second line, we'll just reuse our previous sprite variable - this is not necessary, just
        // a simplification in this case.
        sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = this._drawingSurface.TextureSize.ToString(),
            Position = position,
            RotationOrScale = 0.8f,
            Color = Color.Blue,
            Alignment = TextAlignment.CENTER,
            FontId = "White"
        };
        // Add the sprite to the frame
        frame.Add( sprite );

        // Move our position 20 pixels down in the viewport for the next line
        position += new Vector2( 0, 20 );

        // Create our second line, we'll just reuse our previous sprite variable - this is not necessary, just
        // a simplification in this case.
        sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = this._drawingSurface.SurfaceSize.ToString(),
            Position = position,
            RotationOrScale = 0.8f,
            Color = Color.Blue,
            Alignment = TextAlignment.CENTER,
            FontId = "White"
        };
        // Add the sprite to the frame
        frame.Add( sprite );
    }

    // Drawing Sprites
    public void DrawSprites2 ( ref MySpriteDrawFrame frame )
    {
        // Create background sprite
        var sprite = new MySprite()
        {
            Type = SpriteType.TEXTURE,
            Data = "Grid",
            Position = this._viewport.Center,
            Size = this._viewport.Size,
            Color = Color.White.Alpha( 0.66f ),
            Alignment = TextAlignment.CENTER
        };
        // Add the sprite to the frame
        frame.Add( sprite );

        // Set up the initial position - and remember to add our viewport offset
        var position = new Vector2( 256, 20 ) + _viewport.Position;

        // Create our first line
        sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = "Line 1",
            Position = position,
            RotationOrScale = 0.8f /* 80 % of the font's default size */,
            Color = Color.Red,
            Alignment = TextAlignment.CENTER /* Center the text on the position */,
            FontId = "White"
        };
        // Add the sprite to the frame
        frame.Add( sprite );

        // Move our position 20 pixels down in the viewport for the next line
        position += new Vector2( 0, 20 );

        // Create our second line, we'll just reuse our previous sprite variable - this is not necessary, just
        // a simplification in this case.
        sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = "Line 2",
            Position = position,
            RotationOrScale = 0.8f,
            Color = Color.Blue,
            Alignment = TextAlignment.CENTER,
            FontId = "White"
        };
        // Add the sprite to the frame
        frame.Add( sprite );
    }
}

