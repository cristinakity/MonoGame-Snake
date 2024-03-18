using Microsoft.Xna.Framework;
using MonoGame_Snake.Enums;

namespace MonoGame_Snake.Models
{
    public class BodyPart
    {           
        private BodyPartType _typeOfBody;
        public BodyPartType TypeOfBody
        { 
            get { return _typeOfBody; } 
            set { _typeOfBody = value; }
        }       

        private Direction _spriteDirection;
        public Direction SpriteDirection
        {
            get { return _spriteDirection; }
            set { _spriteDirection = value; }
        }

        private Vector2 _currentPosition = new Vector2();
        public Vector2 CurrentPosition
        {
            get { return _currentPosition; }
            set { _currentPosition = value; }
        }

        private bool _spriteCornerIsCCW = true;
        public bool SpriteCornerIsCCW
        {
            get { return _spriteCornerIsCCW; }
            set { _spriteCornerIsCCW = value; }
        }

        public BodyPart(BodyPartType bodyType, Direction bodySpriteDirection, Vector2 currentPosition)
        {
            _typeOfBody = bodyType;
            _spriteDirection = bodySpriteDirection;
            _currentPosition = currentPosition;
        }

    }
}
