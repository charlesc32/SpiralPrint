using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var input = new Dictionary<int, List<List<string>>>();
        int count = 0;
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                input.Add(count, ParseInputLine(line));
                count++;
            }

        foreach (var square in input.Values)
        {
            Console.WriteLine(PrintSpiral(square));
        }
    }

    private static string PrintSpiral(List<List<string>> square)
    {
        string output = string.Empty;

        var numRows = square.Count - 1;
        var numColumns = square[0].Count - 1;

        var directions = new List<string>() { "right", "down", "left", "up" };
        var currentDirection = 0;

        var rightStart = 0;
        var rightEnd = numColumns;

        var downStart = 0;
        var downEnd = numRows;

        var leftStart = numColumns;
        var leftEnd = 0;

        var upStart = numRows;
        var upEnd = 0;

        var stillProcessing = false;
        do
        {
            stillProcessing = false;
            switch (directions[currentDirection])
            {
                case "right":
                    for (int j = rightStart; j <= rightEnd; j++)
                    {
                        output += " " + square[upEnd][j];
                        stillProcessing = true;
                    }
                    upEnd++;
                    downStart++;
                    break;
                case "down":
                    for (int j = downStart; j <= downEnd; j++)
                    {
                        output += " " + square[j][rightEnd];
                        stillProcessing = true;
                    }
                    rightEnd--;
                    leftStart--;
                    break;
                case "left":
                    for (int j = leftStart; j >= leftEnd; j--)
                    {
                        output += " " + square[downEnd][j];
                        stillProcessing = true;
                    }
                    downEnd--;
                    upStart--;
                    break;
                case "up":
                    for (int j = upStart; j >= upEnd; j--)
                    {
                        output += " " + square[j][leftEnd];
                        stillProcessing = true;
                    }
                    leftEnd++;
                    rightStart++;
                    break;
            }
            currentDirection = (currentDirection == 3) ? 0 : currentDirection + 1;
        } while (stillProcessing);

        return output.Trim();
    }

    private static List<List<string>> ParseInputLine(string line)
    {
        var newInput = new List<List<string>>();

        var splitInput = line.Split(';');
        var numRows = Convert.ToInt32(splitInput[0]);
        var numColumns = Convert.ToInt32(splitInput[1]);
        var values = splitInput[2].Split(' ');

        int lastIndex = 0;

        for (int i = 0; i < numRows; i++)
        {
            var row = new List<string>();
            for (int j = lastIndex; j < lastIndex + numColumns; j++)
            {
                row.Add(values[j]);
            }
            lastIndex = lastIndex + numColumns;
            newInput.Add(row);
        }

        return newInput;
    }
}