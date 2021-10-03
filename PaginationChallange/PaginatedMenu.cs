using System;
using PaginationChallange.Extensions;
using static System.Console;

namespace PaginationChallange
{
    public class PaginatedMenu<T>
    {
        private readonly T[] _collection;
        private readonly int _pageLimit;
        private int _currentIndex;

        public PaginatedMenu(int pageLimit, T[] collection)
        {
            if (pageLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageLimit),
                    "Page size must be positive and greater than 0");

            _pageLimit = pageLimit;
            _collection = collection;
        }

        public void Show()
        {
            void PrintInstructions()
            {
                WriteLine();
                WriteLine("[Right] arrow to go to next page, [Left] arrow to go back, or [Enter] to exit...");
            }

            PrintPeople(Direction.None);
            PrintInstructions();

            while (true)
            {
                var inputConsoleKey = ReadKey();
                Clear();

                switch (inputConsoleKey.Key)
                {
                    case ConsoleKey.Enter:
                        return;
                    case ConsoleKey.RightArrow:
                        PrintPeople(Direction.Forwards);
                        break;
                    case ConsoleKey.LeftArrow:
                        PrintPeople(Direction.Backwards);
                        break;
                    default:
                        PrintPeople(Direction.None);
                        break;
                }

                PrintInstructions();
            }
        }

        private void PrintPeople(Direction direction)
        {
            var section = new Range(_currentIndex, _currentIndex + _pageLimit);

            switch (direction)
            {
                case Direction.Forwards:
                    if (_collection.ValidRange(_currentIndex + _pageLimit, _currentIndex + _pageLimit * 2))
                    {
                        section = new Range(_currentIndex + _pageLimit, _currentIndex + _pageLimit * 2);
                        _currentIndex += _pageLimit;
                    }
                    else if (_collection.ValidRange(_currentIndex + _pageLimit, _collection.Length))
                    {
                        section = new Range(_currentIndex + _pageLimit, _collection.Length);
                        _currentIndex += _pageLimit;
                    }

                    break;
                case Direction.Backwards:
                    if (_collection.ValidRange(_currentIndex - _pageLimit, _currentIndex))
                    {
                        section = new Range(_currentIndex - _pageLimit, _currentIndex);
                        _currentIndex -= _pageLimit;
                    }
                    else
                    {
                        section = new Range(0, _pageLimit);
                        _currentIndex = 0;
                    }

                    break;
            }

            var pagePeople = _collection[section];

            foreach (var person in pagePeople) WriteLine(person);
        }

        private enum Direction
        {
            None,
            Forwards,
            Backwards
        }
    }
}