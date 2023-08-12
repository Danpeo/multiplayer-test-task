using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class MobileInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Fire = "Shoot";
        private const string Jump = "Jump";
        public Vector2 Axis  => SimpleVectorAxis();
        
        public bool IsAttackButtonUp() => 
            SimpleInput.GetButtonUp(Fire);

        public bool IsJumpButtonUp() =>
            SimpleInput.GetButton(Jump);

        private static Vector2 SimpleVectorAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}