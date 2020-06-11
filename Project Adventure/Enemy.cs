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

        public int MaxAttack = 0;
        public int MinAttack = 0;

        public int AttackValue
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(MinAttack, MaxAttack + 1);
            }

            set { }
        }

        public void Attack()
        {
            int Damage = AttackValue;
            Data.Health -= Damage;
            Game.Message($"You have been attacked! The {Name} dealt {Damage} damage! You have {Data.Health}/{Data.maxHealth} left!");
        }

        public void Die()
        {
            if (Health == 0)
            {
                Game.Message($"The {Name} has been vanquished!");
                Data.Foes.Remove(this);
            }
        }
    }
}
