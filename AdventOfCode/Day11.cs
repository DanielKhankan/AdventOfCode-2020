using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Day11 : AdventOfCodeBase {
        public Day11(string fileName) : base(fileName) { }

        private class Cell<T> where T : struct
        {
            public T Value { get; set; }

            public List<(int i, int j)> AdjacentCells { get; private set; }

            public Cell(T value, IEnumerable<(int i, int j)> adjacentIndices)
            {
                Value = value;
                AdjacentCells = adjacentIndices.ToList();
            }
        }

        private class Playground<T> where T : struct
        {
            private int XDimension { get; }
            private int YDimension { get; }

            private Cell<T>[,] _cells;

            public Playground(int xDimension, int yDimension, IEnumerable<T> initialValues)
            {
                XDimension = xDimension;
                YDimension = yDimension;
                
                _cells = new Cell<T>[xDimension,yDimension];
                InitializeCells(initialValues);
            }

            private T GetCell(int i, int j)
            {
                if (i < 0 || i > XDimension - 1 || j < 0 || j > YDimension - 1) {
                    return default;
                }

                return _cells[i, j].Value;
            }

            public T this[int i, int j] => GetCell(i, j);

            public bool CellExists(int i, int j) => (i >= 0 && i < XDimension && j >= 0 && j < YDimension);

            private void InitializeCells(IEnumerable<T> initialValues)
            {
                var i = 0;
                var j = 0;
                
                foreach (var value in initialValues)
                {
                    _cells[i, j] = new Cell<T>(value, GetAdjacentCells(i, j));
                    i++;
                    if (i == XDimension)
                    {
                        i = 0;
                        j++;
                    }
                }
            }

            private IEnumerable<(int i, int j)> GetAdjacentCells(int i, int j)
            {
                var adjacentIndices = new List<(int i, int j)>();

                AddIfExists(i - 1, j + 1, x => adjacentIndices.Add(x));
                AddIfExists(i - 1  , j , x => adjacentIndices.Add(x));
                AddIfExists(i - 1, j -1, x => adjacentIndices.Add(x));
                AddIfExists(i   , j - 1, x => adjacentIndices.Add(x));
                AddIfExists(i ,  j + 1, x => adjacentIndices.Add(x));
                AddIfExists(i + 1, j -1, x => adjacentIndices.Add(x));
                AddIfExists(i + 1, j , x => adjacentIndices.Add(x));
                AddIfExists(i + 1, j +1, x => adjacentIndices.Add(x));

                void AddIfExists(int i, int j, Action<(int i, int j)> action)
                {
                    if (CellExists(i, j))
                    {
                        action((i, j));
                    }
                }

                return adjacentIndices;
            }

            public void Iteration(Func<Cell<T>, T> apply)
            {
                var newCells = new Cell<T>[XDimension, YDimension];

                for (var i = 0; i < XDimension; i++) {
                    for (var j = 0; j < YDimension; j++)
                    { 
                        var value = apply(_cells[i, j]);
                        newCells[i, j] = new Cell<T>(value, _cells[i, j].AdjacentCells);
                    }
                }

                _cells = newCells;
            }

            public void Iteration2(Func<Cell<T>,int, int, T> apply)
            {
                var newCells = new Cell<T>[XDimension, YDimension];

                for (var i = 0; i < XDimension; i++) {
                    for (var j = 0; j < YDimension; j++)
                    { 
                        var value = apply(_cells[i, j], i, j);
                        newCells[i, j] = new Cell<T>(value, _cells[i, j].AdjacentCells);
                    }
                }

                _cells = newCells;
            }

            public IEnumerable<T> Values()
            {
                for (var i = 0; i < XDimension; i++)
                {
                    for (var j = 0; j < YDimension; j++)
                    {
                        yield return this[i, j];
                    }
                }
            }
        }

        public long B()
        {
            var input = Input;

            var xDimension = input.First().Length;
            var yDimension = input.Length;

            var playground = new Playground<char>(xDimension, yDimension, input.SelectMany(x => x.AsEnumerable()));

            var changedCells = 0;

            var positionVectors = new (int i, int j)[] {(-1, 0), (-1, -1), ( -1, 1), ( 0, -1), (0, 1), (1, -1), (1, 0), (1, 1)};
            var iteration = 0;
            do
            {
                changedCells = 0;
                playground.Iteration2((cell, i, j) =>
                {
                        //System.Console.WriteLine($"Iteration {iteration++} changed: {changedCells}");
                        var counter = 0;

                        foreach (var vector in positionVectors)
                        {
                            var position = (vector.i + i, vector.j + j);
                            bool notFound = false;
                            while (!notFound && playground.CellExists(position.Item1, position.Item2))
                            {
                                if (playground[position.Item1, position.Item2] == 'L')
                                {
                                    notFound = true;
                                }
                                else if (playground[position.Item1, position.Item2] == '#')
                                {
                                    counter++;
                                    notFound = true;
                                }
                                position = (position.Item1 + vector.i, position.Item2 + vector.j);
                            }
                        }

                        if (cell.Value == 'L' && counter == 0)
                        {
                            changedCells++;
                            return '#';
                        }
                        if (cell.Value == '#' && counter > 4)
                        {
                            changedCells++;
                            return 'L';
                        }

                        return cell.Value;
                    });
            } while (changedCells > 0);

            var counter = 0;
            foreach (var value in playground.Values())
            {
                if (value == '#')
                {
                    counter++;
                }
            }


            return counter;
        }

        public long A()
        {
            var input = Input;

            var xDimension = input.First().Length;
            var yDimension = input.Length;

            var playground = new Playground<char>(xDimension, yDimension, input.SelectMany(x => x.AsEnumerable()));

            var changedCells = 0;

            do
            {
                changedCells = 0;
                playground.Iteration(cell =>
                {
                    if (cell.Value == 'L' && cell.AdjacentCells.Select( index => playground[index.i, index.j]).All( x=> x != '#'))
                    {
                        changedCells++;
                        return '#';
                    }
                    if (cell.Value == '#' && cell.AdjacentCells.Select( index => playground[index.i, index.j]).Count(x => x == '#') > 3)
                    {
                        changedCells++;
                        return 'L';
                    }

                    return cell.Value;
                });
            } while (changedCells > 0);

            return (playground.Values().Where(value => value == '#')).Count();
        }
    }
}
