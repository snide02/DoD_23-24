using DoD_23_24.Source.Gameplay.World.Nobleman;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoD_23_24;
public class Main : Game
{
    private GraphicsDeviceManager _graphics;

    //World world;
    baseMusicGame world;

    public Main()
    {
        this._graphics = new GraphicsDeviceManager(this);
        this._graphics.PreferredBackBufferWidth = Globals.WIDTH;
        this._graphics.PreferredBackBufferHeight = Globals.HEIGHT;
        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        Globals.graphics = this.GraphicsDevice;
        Globals.window = this.Window;

        //world = new World();
        world = new baseMusicGame();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        world.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: world.GetPlayer().GetTranslation());

        world.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}