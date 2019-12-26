using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class PixelSorter
{
    string input = File.ReadAllText("../../../input.txt");
    [Fact]
    public void Part1_Puzzle() 
    {
        Assert.Equal(1792, pixel_sorter.PixelSorter.Multiply(input, 25, 6));
    }
    [Fact]
    public void Part1_SmallTest() 
    {
        var testInput = "123456789012";
        var output = new List<List<List<int>>>()
        {
            new List<List<int>>(){
                new List<int>(){1, 2, 3},
                new List<int>(){4, 5, 6}
            },
            new List<List<int>>(){
                new List<int>(){7, 8, 9},
                new List<int>(){0, 1, 2}
            }
        };
        Assert.Equal(output, pixel_sorter.PixelSorter.InitialSort(testInput, 3, 2));
    }
    [Fact]
    public void Part2_SmallTest() 
    {
        var testInput = "0222112222120000";
        var output = new List<int[]>()
        {
            new int[] {9, 1},
            new int[] {1, 9}
        };
        Assert.Equal(output, pixel_sorter.PixelSorter.FinalImage(testInput, 2, 2));
    }
    [Fact]
    public void Part2_Puzzle() 
    {
        var output = new List<int[]>()
        {
            new int[] {9, 1},
            new int[] {1, 9}
        };
        Assert.Equal(output, pixel_sorter.PixelSorter.FinalImage(input, 25, 6));
    }

}