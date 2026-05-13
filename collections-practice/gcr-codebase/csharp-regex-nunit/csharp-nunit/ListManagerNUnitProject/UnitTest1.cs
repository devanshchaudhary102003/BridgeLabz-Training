using NUnit.Framework;
using System.Collections.Generic;

// ======================
// List Manager Class
// ======================
public class ListManager
{
    public void AddElement(List<int> list, int element)
    {
        if (list == null) return;
        list.Add(element);
    }

    public void RemoveElement(List<int> list, int element)
    {
        if (list == null) return;
        list.Remove(element);
    }

    public int GetSize(List<int> list)
    {
        if (list == null) return 0;
        return list.Count;
    }
}

// ======================
// NUnit Tests
// ======================
[TestFixture]
public class ListManagerTests
{
    private ListManager manager;
    private List<int> list;

    [SetUp]
    public void Setup()
    {
        manager = new ListManager();
        list = new List<int>();
    }

    [Test]
    public void AddElement_AddsItemToList()
    {
        manager.AddElement(list, 10);
        Assert.That(list.Contains(10), Is.True);
    }

    [Test]
    public void RemoveElement_RemovesItemFromList()
    {
        list.Add(5);
        list.Add(10);

        manager.RemoveElement(list, 5);
        Assert.That(list.Contains(5), Is.False);
    }

    [Test]
    public void GetSize_ReturnsCorrectCount()
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);

        int size = manager.GetSize(list);
        Assert.That(size, Is.EqualTo(3));
    }

    [Test]
    public void AddElement_NullList_DoesNotThrow()
    {
        Assert.That(() => manager.AddElement(null, 5), Throws.Nothing);
    }

    [Test]
    public void RemoveElement_NullList_DoesNotThrow()
    {
        Assert.That(() => manager.RemoveElement(null, 5), Throws.Nothing);
    }

    [Test]
    public void GetSize_NullList_ReturnsZero()
    {
        int size = manager.GetSize(null);
        Assert.That(size, Is.EqualTo(0));
    }
}
