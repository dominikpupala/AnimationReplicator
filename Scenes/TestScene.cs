using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Framework.WpfInterop;
using MonoGame.Framework.WpfInterop.Input;

namespace AnimationReplicator.Scenes
{
    class TestScene : WpfGame
    {
        private IGraphicsDeviceService _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private WpfKeyboard _keyboard;
        private WpfMouse _mouse;

        private Texture2D _texture;
        private Vector2 _position;
        private float _rotation;
        private Vector2 _origin;
        private Vector2 _scale;

        protected override void Initialize()
        {
            // must be initialized. required by Content loading and rendering (will add itself to the Services)
            // note that MonoGame requires this to be initialized in the constructor, while WpfInterop requires it to
            // be called inside Initialize (before base.Initialize())
            _graphicsDeviceManager = new WpfGraphicsDeviceService(this);

            // wpf and keyboard need reference to the host control in order to receive input
            // this means every WpfGame control will have it's own keyboard & mouse manager which will only react if the mouse is in the control
            _keyboard = new WpfKeyboard(this);
            _mouse = new WpfMouse(this);

            // must be called after the WpfGraphicsDeviceService instance was created
            base.Initialize();

            // content loading now possible
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphicsDeviceManager.GraphicsDevice);

            string temp = ((ViewModels.MainViewModel)System.Windows.Application.Current.MainWindow.DataContext).TestInput;
            _texture = Texture2D.FromFile(_graphicsDeviceManager.GraphicsDevice, temp);
        }

        protected override void Update(GameTime time)
        {
            _position = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            _rotation = (float)Math.Sin(time.TotalGameTime.TotalSeconds) / 4f;
            _origin = _texture.Bounds.Center.ToVector2();
            _scale = Vector2.One;

            // every update we can now query the keyboard & mouse for our WpfGame
            var mouseState = _mouse.GetState();
            var keyboardState = _keyboard.GetState();
        }

        protected override void Draw(GameTime time)
        {
            _graphicsDeviceManager.GraphicsDevice.Clear(Color.Pink);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, null, Color.White, _rotation, _origin, _scale, SpriteEffects.None, 0f);
            _spriteBatch.End();
        }
    }
}
