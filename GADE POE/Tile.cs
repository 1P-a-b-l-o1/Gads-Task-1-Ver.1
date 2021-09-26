using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_POE
{
    class Tile
    {
        protected int X;
        public int getX { set { X = value; } get { return X; } }

        protected int Y;
        public int getY { set { Y = value; } get { return Y; } }

        public Char symbol;

        public Char getSymbol { set { symbol = value; } get { return symbol; } }

        public enum TileType { Hero, Enemy, Gold, Weapon }

        public void getTileType(TileType input) {

            switch (input)
            {
                case TileType.Hero:
                    //Code
                    break;
                case TileType.Enemy:
                    //Code
                    break;
                case TileType.Gold:
                    //Code
                    break;
                case TileType.Weapon:
                    //Code
                    break;
            }

        }

        public Tile(int x, int y, char symbol) 
        {
            getX = x;
            getY = y;
            getSymbol = symbol;
        
        }
    }

    class Obstacle : Tile
    {

    }

    class EmptyTile : Obstacle
    {

    }

    class Character : Tile
    {

        protected int HP;

        public int getHP { set { HP = value; } get { return HP; } }

        protected int MaxHP;

        public int getMaxHP { set { MaxHP = value; } get { return MaxHP; } }

        protected int Damage;

        public int getDamage { set { Damage = value; } get { return Damage; } }

        public string[] CharVision = { "north", "south", "east", "west" };

        public enum MovementEnum { noMovement, UP, DOWN, LEFT, RIGHT };

        protected Character(int X, int Y, Char Symbol) : base(X, Y, Symbol)
        {
           
        }

        public virtual void Attack(Character Target)
        {
            int damage = getDamage;
            Target.HP = Target.HP - damage;


        }

        public bool isDead(bool Check)
        {
            if (HP <= 0)
            {
                Check = true;
            }
            else if (HP > 0) 
            {
                Check = false;
            }
            return Check;
        }

        public virtual bool checkRange(Character target)
        {
            if (DistanceTo(target) <= target.weaponType)
            {
                return true;

            } else
            {
                return false;

            }
        }

        private int DistanceTo(Character target)
        {
            int Distance = 0;
            Distance = (target.X + this.X) / 2 + (target.Y + this.Y) / 2;
            
            return Distance;
        }

        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.UP:
                    this.Y = this.Y + 1;
                    break;
                case MovementEnum.LEFT:
                    this.X = this.X - 1;
                    break;
                case MovementEnum.RIGHT:
                    this.X = this.X + 1;
                    break;
                case MovementEnum.DOWN:
                    this.Y = this.Y - 1;
                    break;
                case MovementEnum.noMovement:
                    break;
            }
        }

        public abstract MovementEnum ReturnMove()
        {
            //???????????? 
        }

        public override string ToString()
        {
            return base.ToString();
        }
        

    }

    class Enemy : Character
    {
        protected int ran;

        public int getRan { set { ran = value; } get { return ran; } }

        public Enemy(int x, int y, char symbol, int health, int damage) : base(x, y, symbol) 
        {
            this.HP = health;
            this.Damage = damage; 
        }
        public override string ToString()
        {
            return "Enemy at [" + this.X + "," + this.Y + "] (" + this.Damage + " DMG)";
        }






    }
    class Goblin : Enemy
    {
        public Goblin(int eX, int eY)
        {
            this.X = eX;
            this.Y = eY;

        }
            




    }
   
}

