using System;
using System.Collections.Generic;
using System.Linq;

namespace pixel_sorter
{
    public static class PixelSorter
    {
        public static List<List<List<int>>> InitialSort(string input, int width, int height)
        {
            var image = new List<List<List<int>>>();
            var layer = new List<List<int>>();
            var row = new List<int>();
            var inputArray = input.ToCharArray();
            foreach (var number in inputArray)
            {
                
                if (!int.TryParse(number.ToString(), out int num)) break;
                if (layer.Count < height)
                {
                    if (row.Count < width)
                    {
                        row.Add(num);
                    }
                    else 
                    {
                        layer.Add(row);
                        row = new List<int>(){num};
                    }    
                }
                else 
                {
                    image.Add(layer);
                    if (row.Count == width)
                    {
                        layer = new List<List<int>>(){row};
                        row = new List<int>(){num};
                    }
                    else 
                    {
                        row.Add(num);
                        layer = new List<List<int>>();
                    }
                    
                }
                
            }
            layer.Add(row);
            image.Add(layer);
            return image;
        }
        public static int Sort(List<List<int>> layer, int number)
        {
            int sorted = 0;
            foreach (var row in layer)
            {
                var newRow = row.Where(x => x == number).ToList();
                sorted += newRow.Count;
            }
            return sorted;
        }
        public static int Multiply(string input, int width, int height)
        {
            var image = InitialSort(input, width, height);
            var zeroList = new List<int>();
            foreach (var layer in image)
            {
                var zeros = Sort(layer, 0);
                zeroList.Add(zeros);
            }
            var mostZeros = zeroList.Min();
            var mostZeroLayer = zeroList.IndexOf(mostZeros);
            var ones = Sort(image[mostZeroLayer], 1);
            var twos = Sort(image[mostZeroLayer], 2);
            return ones * twos;
        }
        public static List<int[]> FinalImage(string input, int width, int height)
        {
            var image = InitialSort(input, width, height);
            var finalImage = new List<int[]>();
            var counter = 0;
            while (counter < height)
            {
                finalImage.Add(new int[width]);
                counter++;
            }
            finalImage.ForEach(line => 
            {
                var numCount = 0;
                foreach (var number in line)
                {
                    line[numCount] = 9;
                    numCount++;
                }
            });
            var rowCounter = 0;
            var numCounter = 0;
            image.ForEach(layer => 
            {
                layer.ForEach(row => 
                { 
                    row.ForEach(num => 
                    {
                        if (finalImage[rowCounter][numCounter] == 9)
                        {
                            if (num != 2) finalImage[rowCounter][numCounter] = num;
                        } 
                        numCounter++;
                    });
                    rowCounter++;
                    numCounter = 0;
                });
                rowCounter = 0;
            });
            finalImage.ForEach(row => 
            {
                foreach (var num in row)
                {
                    System.Diagnostics.Debug.Write(num);
                }
                System.Diagnostics.Debug.Write(Environment.NewLine);
            });
            return finalImage;
        }
       
    }
}