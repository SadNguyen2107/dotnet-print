using System.Text;

namespace Program
{
    public class Geometry
    {
        public enum GeometryType
        {
            Rectangle = 1,
            SquareTriangle = 2,
            IsoscelesTriangle = 3,
            Exit
        }

        public enum SquareTriangleType
        {
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 3,
            BottomRight = 4,
            Exit
        }

        public static Int32 GetInput(String prompt, Predicate<int> isValid)
        {
            int choice = -1;

        // Ask User Input
        AskNumInput:
            Console.WriteLine("====================================");
            Console.Write(prompt);
            bool isNumber = Int32.TryParse(Console.ReadLine(), out choice);
            if (!isNumber || !isValid(choice))
            {
                Console.WriteLine("Invalid Input!");
                Console.WriteLine("====================================");
                goto AskNumInput;
            }

            return choice;
        }
        public static GeometryType GetGeometryType()
        {
            int choice = -1;

            // User Prompt To Enter
            // Use stringBuilder to dynamically resize
            StringBuilder promptBuilder = new StringBuilder();
            promptBuilder.AppendLine("Choose a geometry type to draw:");
            promptBuilder.AppendLine("1. Print the rectangle");
            promptBuilder.AppendLine("2. Print the square triangle");
            promptBuilder.AppendLine("3. Print isosceles triangle");
            promptBuilder.AppendLine("4. Exit");
            promptBuilder.Append("Enter the corresponding number: ");

            // Get Input
            // Check If choice is the Value of the Enum
            choice = GetInput(promptBuilder.ToString(), (int choice) =>
                Enum.IsDefined(typeof(GeometryType), choice)
            );

            return (GeometryType)choice;
        }

        public static void HandleGeometryType(GeometryType geometryType)
        {
            switch (geometryType)
            {
                case GeometryType.Rectangle:
                    PrintRectangle();
                    break;

                case GeometryType.SquareTriangle:
                    PrintSquareTriangle();
                    break;

                case GeometryType.IsoscelesTriangle:
                    PrintIsoscelesTriangle();
                    break;

                case GeometryType.Exit:
                    Environment.Exit(0);    // Exit the Program
                    break;

                default:
                    Console.WriteLine("Nothing To Print!");
                    break;
            }
        }

        // Printing Rectangle
        public static void PrintRectangle()
        {
            // Get Length and Width
            int length = GetInput("Enter Length of The Rectangle: ", (int length) => length > 0);
            int width = GetInput("Enter Width of The Rectangle: ", (int width) => width > 0);

            for (int row_index = 0; row_index < width; row_index++)
            {
                for (int collumn_index = 0; collumn_index < length; collumn_index++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        // Printing Triangle
        public static void PrintSquareTriangle()
        {
            // Ask User Option To Input Which Triangle
            // Use stringBuilder to dynamically resize
            StringBuilder promptBuilder = new StringBuilder();
            promptBuilder.AppendLine("Choose the type of Square Triangle:");
            promptBuilder.AppendLine("1. Square Triangle Top-Left");
            promptBuilder.AppendLine("2. Square Triangle Top-Right");
            promptBuilder.AppendLine("3. Square Triangle Bottom-Left");
            promptBuilder.AppendLine("4. Square Triangle Bottom-Right");
            promptBuilder.Append("Enter the corresponding number: ");

            // Check If choice is the Value of the Enum
            SquareTriangleType squareTriangleType = (SquareTriangleType)GetInput(promptBuilder.ToString(),
                (int choice) => Enum.IsDefined(typeof(SquareTriangleType), choice)
            );

            // Get Length and Width
            int length = GetInput("Enter Length of The Triangle: ", (int length) => length > 0);

            switch (squareTriangleType)
            {
                case SquareTriangleType.TopLeft:
                    PrintTopLeftTriangle(length);
                    break;

                case SquareTriangleType.TopRight:
                    PrintTopRightTriangle(length);
                    break;

                case SquareTriangleType.BottomLeft:
                    PrintBottomLeftTriangle(length);
                    break;

                case SquareTriangleType.BottomRight:
                    PrintBottomRightTriangle(length);
                    break;

                default:
                    Console.WriteLine("Nothing To Print!");
                    break;
            }
        }

        // Print Isosceles Triangle
        public static void PrintIsoscelesTriangle()
        {
            // Get Length and Width
            int height = GetInput("Height must Not Divisible To 2 To create a symmetrical isosceles triangle with a peak at the center\nEnter Height of The Triangle: ", (int height) =>
                height > 0 && height % 2 != 0
            );

            // Calculate Width
            /*
                height % 2 != 0
                    *
                  * * *
                * * * * *
            */
            int width = 2 * height - 1;

            for (int i = 1; i <= height; i++)
            {
                // Calculate the number of spaces before the asterisks
                int spacesBefore = (width - (2 * i - 1)) / 2;

                // Print spaces before asterisks
                for (int s = 1; s <= spacesBefore; s++)
                {
                    Console.Write("  ");
                }

                // Print asterisks
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }
        public static void PrintTopLeftTriangle(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintTopRightTriangle(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                // Print spaces before asterisks
                for (int s = 1; s <= length - i; s++)
                {
                    Console.Write("  ");
                }

                // Print asterisks
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }
        public static void PrintBottomLeftTriangle(int length)
        {
            for (int i = length; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintBottomRightTriangle(int length)
        {
            for (int i = length; i >= 1; i--)
            {
                // Print spaces before asterisks
                for (int s = 1; s <= length - i; s++)
                {
                    Console.Write("  ");
                }

                // Print asterisks
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }
    }
}


