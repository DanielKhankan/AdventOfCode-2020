using System;
using System.Linq;

namespace AdventOfCode {
    public class Day12 : AdventOfCodeBase {
        public Day12(string fileName) : base(fileName) { }

        private struct Vector2
        {
            readonly int X;
            readonly int Y;

            public Vector2(int x, int y)
            {
                (X, Y) = (x, y);
            }

            public Vector2 Add(Vector2 vec2) => new Vector2(X + vec2.X, Y + vec2.Y);

            public Vector2 Scale(int scale) => new Vector2(X * scale, Y * scale);

            public Vector2 Rotate90() => new Vector2(-Y, X);

            public int Length => Math.Abs(X) + Math.Abs(Y);
        }

        private class Turtle
        {
            public Vector2 Position { get; set; }
            public Vector2 Heading { get; set; }

            public void MoveForward(int units) => Move(Heading.Scale(units));

            public void Move(Vector2 heading) => Position = Position.Add(heading);

            public void Rotate(int degrees)
            {
                var toRotate = degrees;
                while (toRotate > 0)
                {
                    Heading = Heading.Rotate90();
                    toRotate -= 90;
                }
            }
        }

        public long A()
        {
            var input = Input.Select(Parse);

            var turtle = new Turtle {
                Heading = new Vector2(0, 1)
            };

            foreach (var action in input)
            {
                action(turtle);
            }

            return turtle.Position.Length;
        }

        private static Action<Turtle> Parse(string input)
        {
            Action<Turtle> action = null;

            var command = input[0];
            var argument = int.Parse(input.Substring(1));

            action = command switch
            {
                'N' => x => x.Move(new Vector2(argument, 0)),
                'S' => x => x.Move( new Vector2(-argument, 0)),
                'E' => x => x.Move( new Vector2(0, argument)),
                'W' => x => x.Move( new Vector2( 0, -argument)),
                'R' => x => x.Rotate(argument),
                'L' => x => x.Rotate(360 - argument),
                'F' => x => x.MoveForward(argument),
                _ => action
            };

            return action;
        }

        private static Action<Turtle> ParseB(string input)
        {
            Action<Turtle> action = null;

            var command = input[0];
            var argument = int.Parse(input.Substring(1));

            action = command switch
            {
                'N' => x => x.Heading = x.Heading.Add(new Vector2(argument, 0)),
                'S' => x => x.Heading = x.Heading.Add(new Vector2(-argument, 0)),
                'E' => x => x.Heading = x.Heading.Add(new Vector2(0, argument)),
                'W' => x => x.Heading = x.Heading.Add(new Vector2( 0, -argument)),
                'R' => x => x.Rotate(argument),
                'L' => x => x.Rotate(360 - argument),
                'F' => x => x.Position = x.Position.Add(x.Heading.Scale(argument)),
                _ => action
            };

            return action;
        }
        public long B()
        {
            var input = Input.Select(ParseB);

            var turtle = new Turtle {
                Heading = new Vector2(1, 10)
            };

            foreach (var action in input)
            {
                action(turtle);
            }

            return turtle.Position.Length;
        }
    }
}
