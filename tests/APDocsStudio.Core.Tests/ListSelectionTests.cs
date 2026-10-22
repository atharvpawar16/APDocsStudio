using NAPS2.Util;

namespace APDocsStudio.Core.Tests;

public class ListSelectionTests
{
    [Fact]
    public void EqualSelectionsHaveSameHashRegardlessOfOrderAndDuplicates()
    {
        var first = ListSelection.Of(1, 2, 3);
        var second = ListSelection.Of(3, 1, 2, 1);
        Assert.Equal(first, second);
        Assert.Equal(first.GetHashCode(), second.GetHashCode());
        Assert.Contains(second, new HashSet<ListSelection<int>> { first });
    }

    [Fact]
    public void EmptySelectionsHaveSameHash()
    {
        Assert.Equal(ListSelection.Empty<int>().GetHashCode(), ListSelection.Empty<int>().GetHashCode());
    }

    [Fact]
    public void ReplaceRangeWithoutMatchDoesNotChangeListOrSelection()
    {
        var actual = new List<int> { 1, 2, 3 };
        var selection = ListSelection.Of(2);
        new ListMutation<int>.ReplaceRange(new() { 9 }, new() { 8 }).Apply(actual, ref selection);
        Assert.Equal(new[] { 1, 2, 3 }, actual);
        Assert.Equal(ListSelection.Of(2), selection);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void ReplaceRangeIgnoresIncompleteMatchAtEnd(int prefixLength)
    {
        var actual = Enumerable.Range(0, prefixLength).Append(9).ToList();
        var expected = actual.ToList();
        var selection = ListSelection.Empty<int>();
        new ListMutation<int>.ReplaceRange(new() { 9, 10 }, new() { 8 }).Apply(actual, ref selection);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReplaceRangeHandlesEmptyList()
    {
        var actual = new List<int>();
        var selection = ListSelection.Empty<int>();
        new ListMutation<int>.ReplaceRange(new() { 9 }, new() { 8 }).Apply(actual, ref selection);
        Assert.Empty(actual);
    }

    [Fact]
    public void ReplaceRangeReplacesFirstCompleteMatch()
    {
        var actual = new List<int> { 0, 1, 2, 1, 2 };
        var selection = ListSelection.Empty<int>();
        new ListMutation<int>.ReplaceRange(new() { 1, 2 }, new() { 8, 9, 10 }).Apply(actual, ref selection);
        Assert.Equal(new[] { 0, 8, 9, 10, 1, 2 }, actual);
    }
}
