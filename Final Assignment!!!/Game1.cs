using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pokemon;
using System;

namespace Final_Assignment___
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        KeyboardState currentState, oldState;
        SpriteFont menuFont, healthFont;
        Rectangle window, menuLocation, moveInfoLocation, battleLocation, arrowSize, enemyLocation, charHealthBar, enemyHealthBar, charHealthImg, enemyHealthImg, charIconSize, enemyIconSize;
        Snorlax snorlax;
        Arcanine arcanine;
        Texture2D snorlaxTexture, AOtexture, AWtexture, menu, healthbar, healthIcon, battleImg, arrow, arcanineWild, nameIcon, hyperBeam, hyperBeamImpact, defenseCurl;
        Vector2 moveType, moveName1, moveName2, moveName3, moveName4, typeText, PPText, movePP, charNameText, enemyNameText, totalHealthText, healthAmountText;
        int healthAmount, totalHealth;
        enum Pokemon
        {
            snorlax, ninetails, exeggutor, arcanine, flygon, sceptile, electivire
        }
        enum Enemy
        {
            arcanine, ninetails, exeggutor, flygon, sceptile, electivire
        }
        enum SnorlaxText
        {
            bodyPress, headbutt, hyperBeam, defenseCurl, none
        }
        private Pokemon currentPokemon;
        private Enemy currentEnemy;
        private SnorlaxText snorlaxText;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            window = new Rectangle(0, 0, 1000, 800);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            menuLocation = new Rectangle(0, 550, 600, 250);
            moveInfoLocation = new Rectangle(600, 550, 400, 250);
            battleLocation = new Rectangle(0, 0, 1000, 550);
            typeText = new Vector2(660, 600);
            moveName1 = new Vector2(70, 600);
            moveName2 = new Vector2(70, 680);
            moveName3 = new Vector2(340, 600);
            moveName4 = new Vector2(340, 680);
            moveType = new Vector2(780, 600);
            PPText = new Vector2(660, 670);
            movePP = new Vector2(740, 670);
            charNameText = new Vector2(615, 370);
            totalHealthText = new Vector2(830, 460);
            healthAmountText = new Vector2(777, 460);
            arrowSize = new Rectangle(20, 600, 50, 60);
            charHealthImg = new Rectangle(570, 390, 370, 100);
            charIconSize = new Rectangle(530, 340, 460, 200);
            charHealthBar = new Rectangle(670, 428, 235, 30);
            enemyIconSize = new Rectangle(20, 20, 460, 150);
            enemyHealthImg = new Rectangle(70, 50, 370, 100);
            enemyHealthBar = new Rectangle(170, 88, 235, 30);
            enemyNameText = new Vector2(100, 40);
            snorlax = new Snorlax(snorlaxTexture, hyperBeam, hyperBeamImpact, defenseCurl, new Rectangle(120, 283, 400, 400));
            arcanine = new Arcanine(AWtexture, AOtexture, new Rectangle(), new Rectangle());
            enemyLocation = new Rectangle(610, 90, 300, 300);

            healthAmount = snorlax.Health;
            totalHealth = snorlax.Health;

            currentPokemon = Pokemon.snorlax;
            snorlaxText = SnorlaxText.none;
            currentEnemy = Enemy.arcanine;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            snorlaxTexture = Content.Load<Texture2D>("snorlax");
            AWtexture = Content.Load<Texture2D>("arcanine");
            healthbar = Content.Load<Texture2D>("tile");
            healthIcon = Content.Load<Texture2D>("healthBar");
            menu = Content.Load<Texture2D>("starterMoveset");
            menuFont = Content.Load<SpriteFont>("pokeFont");
            healthFont = Content.Load<SpriteFont>("healthFont");
            battleImg = Content.Load<Texture2D>("grassBattlefield");
            arrow = Content.Load<Texture2D>("select");
            nameIcon = Content.Load<Texture2D>("nameIcon");
            hyperBeam = Content.Load<Texture2D>("hyperBeam");
            hyperBeamImpact = Content.Load<Texture2D>("hyperBeamImpact");
            defenseCurl = Content.Load<Texture2D>("defenseCurl");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentState = Keyboard.GetState();
            if (arrowSize.X == 20 && arrowSize.Y == 600 && currentState.IsKeyDown(Keys.Down))
                arrowSize.Y = 680;
            else if (arrowSize.X == 20 && arrowSize.Y == 600 && currentState.IsKeyDown(Keys.Right))
                arrowSize.X = 290;
            else if (arrowSize.X == 20 && arrowSize.Y == 680 && currentState.IsKeyDown(Keys.Up))
                arrowSize.Y = 600;
            else if (arrowSize.X == 20 && arrowSize.Y == 680 && currentState.IsKeyDown(Keys.Right))
                arrowSize.X = 290;
            else if (arrowSize.X == 290 && arrowSize.Y == 600 && currentState.IsKeyDown(Keys.Down))
                arrowSize.Y = 680;
            else if (arrowSize.X == 290 && arrowSize.Y == 600 && currentState.IsKeyDown(Keys.Left))
                arrowSize.X = 20;
            else if (arrowSize.X == 290 && arrowSize.Y == 680 && currentState.IsKeyDown(Keys.Up))
                arrowSize.Y = 600;
            else if (arrowSize.X == 290 && arrowSize.Y == 680 && currentState.IsKeyDown(Keys.Left))
                arrowSize.X = 20;
            if (currentPokemon == Pokemon.snorlax)
            {
                if (arrowSize.X == 20 && arrowSize.Y == 600)
                {
                    if (currentState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
                    {
                        snorlax.Move1PP -= 1;
                        snorlax.CurrentMove = Snorlax.Move.headbutt;
                        snorlaxText = SnorlaxText.headbutt;
                    }
                }
                if (arrowSize.X == 20 && arrowSize.Y == 680)
                {
                    if (currentState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
                    {
                        snorlax.Move2PP -= 1;
                        snorlax.CurrentMove = Snorlax.Move.bodyPress;
                        snorlaxText = SnorlaxText.bodyPress;
                    }
                }
                if (arrowSize.X == 290 && arrowSize.Y == 600)
                {
                    if (currentState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
                    {
                        snorlax.Move3PP -= 1;
                        snorlax.CurrentMove = Snorlax.Move.hyperBeam;
                        snorlaxText = SnorlaxText.hyperBeam;
                    }
                }
                if (arrowSize.X == 290 && arrowSize.Y == 680)
                {
                    if (currentState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
                    {
                        snorlax.Move4PP -= 1;
                        snorlax.CurrentMove = Snorlax.Move.defenseCurl;
                        snorlaxText = SnorlaxText.defenseCurl;
                    }
                }
            }
            snorlax.Update(gameTime);
            oldState = currentState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(battleImg, battleLocation, Color.White);
            _spriteBatch.Draw(arcanineWild, enemyLocation, Color.White);
            if (currentPokemon == Pokemon.snorlax)
            {
                snorlax.Draw(_spriteBatch);
                _spriteBatch.Draw(menu, menuLocation, Color.White);
                _spriteBatch.Draw(menu, moveInfoLocation, Color.White);
                _spriteBatch.DrawString(menuFont, snorlax.Move1, moveName1, Color.Black);
                _spriteBatch.DrawString(menuFont, snorlax.Move2, moveName2, Color.Black);
                _spriteBatch.DrawString(menuFont, snorlax.Move3, moveName3, Color.Black);
                _spriteBatch.DrawString(menuFont, snorlax.Move4, moveName4, Color.Black);
                _spriteBatch.DrawString(menuFont, "Type/", typeText, Color.Black);
                _spriteBatch.DrawString(menuFont, snorlax.MoveType, moveType, Color.Black);
                if (arrowSize.X == 20 && arrowSize.Y == 600)
                {
                    _spriteBatch.DrawString(menuFont, "PP         /15", PPText, Color.Black);
                    _spriteBatch.DrawString(menuFont, Convert.ToString(snorlax.Move1PP), movePP, Color.Black);
                }
                if (arrowSize.X == 20 && arrowSize.Y == 680)
                {
                    _spriteBatch.DrawString(menuFont, "PP         /10", PPText, Color.Black);
                    _spriteBatch.DrawString(menuFont, Convert.ToString(snorlax.Move2PP), movePP, Color.Black);
                }
                if (arrowSize.X == 290 && arrowSize.Y == 600)
                {
                    _spriteBatch.DrawString(menuFont, "PP         /5", PPText, Color.Black);
                    _spriteBatch.DrawString(menuFont, Convert.ToString(snorlax.Move3PP), movePP, Color.Black);
                }
                if (arrowSize.X == 290 && arrowSize.Y == 680)
                {
                    _spriteBatch.DrawString(menuFont, "PP         /30", PPText, Color.Black);
                    _spriteBatch.DrawString(menuFont, Convert.ToString(snorlax.Move4PP), movePP, Color.Black);
                }   
            }
            _spriteBatch.Draw(arrow, arrowSize, Color.Black);
            _spriteBatch.Draw(nameIcon, charIconSize, Color.White);
            _spriteBatch.Draw(healthbar, charHealthBar, Color.LimeGreen);
            _spriteBatch.Draw(healthIcon, charHealthImg, Color.White);
            _spriteBatch.DrawString(healthFont, snorlax.Name, charNameText, Color.Black);
            _spriteBatch.DrawString(healthFont, "/" + Convert.ToString(totalHealth), totalHealthText, Color.Black);
            _spriteBatch.DrawString(healthFont, Convert.ToString(healthAmount), healthAmountText, Color.Black);
            _spriteBatch.Draw(nameIcon, enemyIconSize, Color.White);
            _spriteBatch.Draw(healthbar, enemyHealthBar, Color.LimeGreen);
            _spriteBatch.Draw(healthIcon, enemyHealthImg, Color.White);
            _spriteBatch.DrawString(healthFont, "ARCANINE", enemyNameText, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
