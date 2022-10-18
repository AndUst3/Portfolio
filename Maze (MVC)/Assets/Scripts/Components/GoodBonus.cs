using System;

namespace Maze
{
    public class GoodBonus : Bonus
    {
        private int _points;

        public event Action<int> AddPoint = delegate (int i) { };

        public GoodBonus(ObjectView view) : base(view)
        {
            Init();
            view.Collide += Action;
        }

        public override void Init()
        {
            base.Init();
            _points = 1;
        }

        private void Action(Player contactView)
        {
            Interaction();
        }

        protected override void Interaction()
        {
            AddPoint?.Invoke(_points);
            IsInteractable = false;
        }
    }
}
