using System.Collections.Generic;
using System;

namespace Maze
{
    public class ListExecuteObject
    {
        private IExecute[] _interactivObject;
        private List<IExecute> temp;
        private int _index = -1;
        public int Lenght { get { return _interactivObject.Length; } }

        public object Current => _interactivObject[_index];

        public IExecute this[int curr]
        {
            get => _interactivObject[curr];
            private set => _interactivObject[curr] = value;
            
        }

        public ListExecuteObject(Bonus[] bonuses)
        {
            for (int i = 0; i < bonuses.Length; i++)
            {
                if (bonuses[i] is IExecute intObject)
                    AddExecuteObject(intObject);
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactivObject == null)
            {
                _interactivObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactivObject, Lenght + 1);
            _interactivObject[Lenght - 1] = execute;
        } 
    }
}