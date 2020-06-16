using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Enemy
    {
        public string Name = "";

        public int Health
        {
            get
            {
                if (_health < 0)
                    return 0;
                else
                    return _health;
            }
            set
            {
                _health = value;
            }
        }
        private int _health = 0;
        public int MaxHealth = 0;

        public int MaxAtkStrength = 0;
        public int MinAtkStrength = 0;
        public int AttackStrength
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(MinAtkStrength, MaxAtkStrength + 1);
            }

            set { }
        }

        public int MaxAtkTimes = 1;
        public int MinAtkTimes = 1;
        public int AttackTimes
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(MinAtkTimes, MaxAtkTimes + 1);
            }

            set { }
        }

        public Item Reward = null;

        public void Attack()
        {
            int Damage;
            int Hits = AttackTimes;

            if (Hits == 1)
            {
                Damage = AttackStrength;
                Data.Health -= Damage;
                Game.Message($"You have been attacked! The {Name} dealt {Damage} damage! You have {Data.Health}/{Data.maxHealth} left!");
            }

            else
            {
                for (int i = 0; i < Hits; i++)
                {
                    Damage = AttackStrength;
                    Data.Health -= Damage;
                    Game.Message($"The {Name} dealt {Damage} damage on attack #{i + 1}! {Data.Health}/{Data.maxHealth} left!");
                }
                Game.Message($"Hit {Hits} times by {Name}.");
            }
        }

        public void Die()
        {
            if (Health == 0)
            {
                Game.Message($"The {Name} has been vanquished!");

                if (Reward != null)
                {
                    Game.Message($"The {Name} dropped something. What is it?");
                    Game.Manage(Reward);
                }

                Data.Foes.Remove(this);
            }
        }
    }
}
