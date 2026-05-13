using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVorbis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Snorlax
    {
        private Texture2D _texture;
        private Rectangle _location;
        private bool _using_Headbutt, _using_Body_Press, _using_Hyper_Beam, _using_Defense_Curl;
        private string _move1, _move2, _move3, _move4, _move_type, _move1_PP, _move2_PP, _move3_PP, _move4_PP;
        private int _speed, _health, _defense, _attack, _sDefense;
        private float _battle_time, _frame_time;
        public Snorlax(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            _move1 = "Headbutt";
            _move2 = "Body Press";
            _move3 = "Hyper Beam";
            _move4 = "Defense Curl";
            _move_type = "Normal";
            _move1_PP = "15";
            _move2_PP = "10";
            _move3_PP = "5";
            _move4_PP = "30";
            Random stats = new Random();
            _speed = stats.Next(20, 41);
            _health = stats.Next(150, 171);
            _defense = stats.Next(50, 81);
            _attack = stats.Next(100, 121);
            _sDefense = stats.Next(100, 121);
            _using_Headbutt = false;
            _using_Body_Press = false;
            _using_Defense_Curl = false;
            _using_Hyper_Beam = false;
        }

        public void Update(GameTime gametime)
        {
            if (_using_Headbutt == true)
            {
                _battle_time += (float)gametime.ElapsedGameTime.TotalSeconds;
                _frame_time += (float)gametime.ElapsedGameTime.TotalSeconds;
                if (_frame_time <= 0.5f)
                {
                    _location.X += 15;
                    _location.Y -= 10;
                }
                else if (_frame_time <= 1f)
                {
                    _location.X -= 15;
                    _location.Y += 10;
                }
                else if (_battle_time >= 3f)
                {
                    _location.X = 150;
                    _location.Y = 283;
                    _battle_time = 0;
                    _frame_time = 0;
                    _using_Headbutt = false;
                }
            }
            if (_using_Body_Press == true)
            {
                _battle_time += (float)gametime.ElapsedGameTime.TotalSeconds;
                _frame_time += (float)gametime.ElapsedGameTime.TotalSeconds;
            }
        }
        public bool Headbutt
        {
            get { return _using_Headbutt; }
            set { _using_Headbutt = value; }
        }
        public int Health
        {
            get { return _health; }
        }
        public string Move1
        {
            get { return _move1; }
        }
        public string Move2
        {
            get { return _move2; }
        }
        public string Move3
        {
            get { return _move3; }
        }
        public string Move4
        {
            get { return _move4; }
        }
        public string MoveType
        {
            get { return _move_type; }
        }
        public string Move1PP
        {
            get { return _move1_PP; }
        }
        public string Move2PP
        {
            get { return _move2_PP; }
        }
        public string Move3PP
        {
            get { return _move3_PP; }
        }
        public string Move4PP
        {
            get { return _move4_PP; }
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

    }
}
