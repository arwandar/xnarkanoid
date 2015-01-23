using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNArkanoid.Entites;

namespace XNArkanoid
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState oldMouseState, mouseState;
        int hauteurEcran, largeurEcran;

        Level level;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Etat initial de la souris
            mouseState = Mouse.GetState();

            this.Window.Title = "XNArkanoid";

            this.hauteurEcran = this.graphics.PreferredBackBufferHeight;
            this.largeurEcran = this.graphics.PreferredBackBufferWidth;

            this.level = new Level(1, largeurEcran, hauteurEcran);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.level.getBarre().setTexture(Content.Load<Texture2D>("images/barre"));
            for (int i = 0; i < this.level.Bricks.GetLength(0); i++)
            {
                for (int j =0; j < this.level.Bricks.GetLength(1); j++)
                {
                    this.level.Bricks[i, j].setTexture(Content.Load<Texture2D>("images/brick_green"));
                }
            }
            this.level.getBall().setTexture(Content.Load<Texture2D>("images/balle"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //prise en compte du mouvement de la souris
            this.oldMouseState = this.mouseState;
            this.mouseState = Mouse.GetState();
            int deplacement = this.oldMouseState.X - this.mouseState.X;
            this.level.Update(deplacement);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FloralWhite);

            spriteBatch.Begin();

            this.level.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
