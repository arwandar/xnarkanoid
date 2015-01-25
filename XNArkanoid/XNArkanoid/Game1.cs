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

        List<Texture2D> listeTexture;

        Level level;
        Menu menu;

        enum listeEcran { menu, level };
        listeEcran ecran;

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

            this.listeTexture = new List<Texture2D>();

            this.menu = new Menu(this.largeurEcran, this.hauteurEcran);

            this.ecran = listeEcran.menu;

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
            this.addTexture(Content.Load<Texture2D>("images/barre"), "barre", "");
            this.addTexture(Content.Load<Texture2D>("images/brick_green"), "brick", "brickNormale");
            this.addTexture(Content.Load<Texture2D>("images/brick_green"), "brick", "brickIncassable");
            this.addTexture(Content.Load<Texture2D>("images/brick_green"), "brick", "brickBonus");
            this.addTexture(Content.Load<Texture2D>("images/brick_green"), "brick", "brickVies");
            this.addTexture(Content.Load<Texture2D>("images/balle"), "balle", "");
        }

        private void addTexture(Texture2D texture, String tag, String name)
        {
            texture.Tag = tag;
            texture.Name = name;
            this.listeTexture.Add(texture);
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
            

            switch (ecran)
            {
                case listeEcran.menu:
                    typeBtn btnClick = 0;
                    btnClick = typeBtn.btnJouer;
                    switch (btnClick)
                    {
                        case typeBtn.btnJouer:
                            this.level = new Level(1, this.largeurEcran, this.hauteurEcran, this.listeTexture);
                            this.ecran = listeEcran.level;
                            break;
                        case typeBtn.btnExit:
                            break;
                        default:
                            break;
                    }

                    break;
                case listeEcran.level:
                    this.oldMouseState = this.mouseState;
                    this.mouseState = Mouse.GetState();
                    int deplacement = this.oldMouseState.X - this.mouseState.X;
                    this.level.Update(deplacement);
                    break;
                default:
                    this.Exit();
                    break;
            }


            //prise en compte du mouvement de la souris


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

            switch (ecran)
            {
                case listeEcran.menu:
                    this.menu.Draw(spriteBatch);
                    break;
                case listeEcran.level:
                    this.level.Draw(spriteBatch);
                    break;
                default:
                    this.Exit();
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
