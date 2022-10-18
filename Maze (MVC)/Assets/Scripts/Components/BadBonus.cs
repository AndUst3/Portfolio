using System;

namespace Maze
{
    public class BadBonus : Bonus
    {
        private int _damage;

        public event Action<int> OnDamage = delegate (int i) { };

        public BadBonus(ObjectView view) : base(view)
        {
            Init();
            view.Collide += Action;
        }

        public override void Init()
        {
            base.Init();
            _damage = 20;
        }

        private void Action(Player contactView)
        {
            Interaction();
        }

        protected override void Interaction()
        {
            OnDamage?.Invoke(_damage);
            IsInteractable = false;
        }
    }
}
