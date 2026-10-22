using NAPS2.Util;

namespace APDocsStudio.Core.Tests;

public class ListMutationTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(100)]
    public void InterleaveAndDeinterleaveRoundTrip(int count)
    {
        var original = Enumerable.Range(0, count).ToList();
        var actual = original.ToList();
        var selection = ListSelection.From(actual);
        new ListMutation<int>.Deinterleave().Apply(actual, ref selection);
        new ListMutation<int>.Interleave().Apply(actual, ref selection);
        Assert.Equal(original, actual);
        Assert.Empty(selection);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(100)]
    public void AlternateInterleaveAndDeinterleaveRoundTrip(int count)
    {
        var original = Enumerable.Range(0, count).ToList();
        var actual = original.ToList();
        var selection = ListSelection.From(actual);
        new ListMutation<int>.AltDeinterleave().Apply(actual, ref selection);
        new ListMutation<int>.AltInterleave().Apply(actual, ref selection);
        Assert.Equal(original, actual);
        Assert.Empty(selection);
    }

    [Fact]
    public void ReverseSelectionLeavesOtherItemsInPlace()
    {
        var actual = new List<int> { 0, 1, 2, 3, 4 };
        var selection = ListSelection.Of(1, 3);
        new ListMutation<int>.ReverseSelection().Apply(actual, ref selection);
        Assert.Equal(new[] { 0, 3, 2, 1, 4 }, actual);
        Assert.Equal(2, selection.Count);
    }

    [Fact]
    public void MoveDownKeepsSelectedGroupOrder()
    {
        var actual = new List<int> { 0, 1, 2, 3, 4 };
        var selection = ListSelection.Of(1, 2);
        new ListMutation<int>.MoveDown().Apply(actual, ref selection);
        Assert.Equal(new[] { 0, 3, 1, 2, 4 }, actual);
    }

    [Fact]
    public void MoveUpKeepsSelectedGroupOrder()
    {
        var actual = new List<int> { 0, 1, 2, 3, 4 };
        var selection = ListSelection.Of(2, 3);
        new ListMutation<int>.MoveUp().Apply(actual, ref selection);
        Assert.Equal(new[] { 0, 2, 3, 1, 4 }, actual);
    }
}
