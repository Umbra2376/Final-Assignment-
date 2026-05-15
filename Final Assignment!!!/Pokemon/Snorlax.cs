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
        private Texture2D _texture, _hyperTexture, _impactTexture;
        private Rectangle _location, _hyper_Location, _impact_Location;
        private bool _using_Headbutt, _using_Body_Press, _using_Hyper_Beam, _using_Defense_Curl, _draw_Hyper_Beam;
        private string _move1, _move2, _move3, _move4, _move_type, _name;
        private int _speed, _health, _defense, _attack, _sDefense, _move1_PP, _move2_PP, _move3_PP, _move4_PP;
        private float _battle_time, _frame_time, _hyper_interval;
        public Snorlax(Texture2D texture, Texture2D hyperTexture, Texture2D impactTexture, Rectangle location)
        {
            _texture = texture;
            _hyperTexture = hyperTexture;
            _impactTexture = impactTexture;
            _location = location;
            _move1 = "Headbutt";
            _move2 = "Body Press";
            _move3 = "Hyper Beam";
            _move4 = "Defense Curl";
            _move_type = "Normal";
            _name = "SNORLAX";
            _move1_PP = 15;
            _move2_PP = 10;
            _move3_PP = 5;
            _move4_PP = 30;
            _hyper_interval = 0.03f;
            Random stats = new Random();
            _speed = stats.Next(20, 41);
            _health = stats.Next(150, 171);
            _defense = stats.Next(50, 81);
            _attack = stats.Next(100, 121);
            _sDefense = stats.Next(100, 121);
            _hyper_Location = new Rectangle(300, 300, 300, 300);
            _impact_Location = new Rectangle(610, 90, 300, 300);
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
                if ( _frame_time <= 0.5f)
                {
                    _location.Y -= 20;
                }
                else if ( _frame_time <= 0.7f)
                {
                    _location.X = 610;
                }
                else if (_frame_time <= 1f)
                {
                    _location.Y += 20;
                }
                else if (_frame_time <= 1.3)
                {
                    _location.X = 150;
                    _location.Y = 283;
                    _battle_time = 0;
                    _frame_time = 0;
                    _using_Body_Press = false;
                }
            }
            if (_using_Hyper_Beam == true)
            {
                _battle_time += (float)gametime.ElapsedGameTime.TotalSeconds;
                _frame_time += (float)gametime.ElapsedGameTime.TotalSeconds;
                if (_frame_time >= _hyper_interval)
                {
                    _hyper_Location.X += 30;
                    _hyper_Location.Y -= 20;
                    _frame_time -= _hyper_interval;
                }
                if (_battle_time >= 0.4)
                {
                    _frame_time = 1;
                    if (_frame_time >= 3 && _battle_time >= 4)
                    {
                        _using_Hyper_Beam = false;
                        _frame_time = 0;
                        _battle_time = 0;
                        _hyper_Location.X = 520;
                        _hyper_Location.Y = 300;
                    }
                }
            }
        }
        public bool BodyPress
        {
            get { return _using_Body_Press; }
            set { _using_Body_Press = value; }
        }
        public bool Headbutt
        {
            get { return _using_Headbutt; }
            set { _using_Headbutt = value; }
        }
        public bool HyperBeam
        {
            get { return _using_Hyper_Beam; }
            set { _using_Hyper_Beam = value; }
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
        public int Move1PP
        {
            get { return _move1_PP; }
            set { _move1_PP = value; }
        }
        public int Move2PP
        {
            get { return _move2_PP; }
            set { _move2_PP = value; }
        }
        public int Move3PP
        {
            get { return _move3_PP; }
            set { _move3_PP = value; }
        }
        public int Move4PP
        {
            get { return _move4_PP; }
            set { _move4_PP = value; }
        }
        public string Name
        {
            get { return _name;  }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
            if (_using_Hyper_Beam)
            {
                if (_frame_time <= 0)
                {
                    spriteBatch.Draw(_hyperTexture, _hyper_Location, Color.White);
                }
                if (_battle_time >= 1)
                {
                    spriteBatch.Draw(_impactTexture, _impact_Location, Color.White);
                }
                
            }
        }

    }
}
