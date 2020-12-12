using System;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day12 {
        private struct Vector2
        {
            public double X;
            public double Y;

            public Vector2(double x, double y)
            {
                (X, Y) = (x, y);
            }

            public Vector2 Add(Vector2 vec2) => new Vector2(X + vec2.X, Y + vec2.Y);

            public Vector2 Scale(int scale) => new Vector2(X * scale, Y * scale);

            public Vector2 Rotate90() => new Vector2(-Y, X);

            public double Length => Math.Abs(X) + Math.Abs(Y);
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

        internal static int Day12A()
        {
            var input = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day12.txt")).Select(Parse);

            var turtle = new Turtle {
                Heading = new Vector2(0, 1)
            };

            foreach (var action in input)
            {
                action(turtle);
            }

            return (int)turtle.Position.Length;
        }
        /*
         * Action N means to move north by the given value.
Action S means to move south by the given value.
Action E means to move east by the given value.
Action W means to move west by the given value.
Action L means to turn left the given number of degrees.
Action R means to turn right the given number of degrees.
Action F means to move forward by the given value in the direction the ship is currently facing.
         */

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
                'R' => x =>
                {
                //    x.Heading = x.Heading.Add(x.Position.Scale(-1));
                    x.Rotate(argument);
                 //   x.Heading = x.Heading.Add(x.Position);
                },
                'L' => x => x.Rotate(360 - argument),
                'F' => x =>
                {
                    x.Position = x.Position.Add(x.Heading.Scale(argument));
                },
                _ => action
            };

            return action;
        }
        internal static int Day12B()
        {
            var input = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day12.txt")).Select(ParseB);

            var turtle = new Turtle {
                Heading = new Vector2(1, 10)
            };

            foreach (var action in input)
            {
                action(turtle);
            }

            return (int)turtle.Position.Length;
        }

    }
}
