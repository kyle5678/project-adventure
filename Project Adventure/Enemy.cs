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
        public int health = 0;
        public int maxHealth = 0;
        public int maxAttack = 0;
        public int minAttack = 0;
        public int attackValue
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(minAttack, maxAttack + 1);
            }

            set { }
        }

        public void Attack()
        {
            Data.Health -= attackValue;
        }
    }
}
