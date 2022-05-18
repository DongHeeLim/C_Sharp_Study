using System;

namespace _220503_9weeks
{
    class Protoss
    {
        protected int hp;
        protected int shield;

        public int  HP
        {
            get { return hp; }
            set { hp = value; } 
        }
        public int Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        public  Protoss()
        {
            Console.Write("유닛이 생성되었습니다 : ");
        }

        public virtual void attack()
        {
            Console.WriteLine("Can't attack");
        }

    }

    class Zilot : Protoss
    {
        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public Zilot() 
        {
            Console.Write("질럿");
            this.hp = 100;
            this.shield = 80;
            this.damage = 8;
            Console.WriteLine(" [{0}/{1}] ", this.shield, this.hp);
        }

        public override void attack() 
        {
            int totalDamage = 0;
            totalDamage = this.damage * 2;
            Console.WriteLine("Damage : {0}", totalDamage);
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Protoss zilot1 = new Zilot();
            zilot1.attack();
        }
    }
}
