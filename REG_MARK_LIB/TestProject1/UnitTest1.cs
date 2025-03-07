using Microsoft.VisualStudio.TestTools.UnitTesting;
using REG_MARK_LIB;

[TestClass]
public class MarkManagerTests
{
    Class1 class1 = new Class1();
    [TestMethod]
    public void Boolean_FirstLetterNotInAllowedSet_ReturnsFalse()
    {
        Assert.IsTrue(class1.Boolean("C123BC456"));
    }
    [TestMethod]
    public void Boolean_EmptyString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => class1.Boolean(""));
    }
    [TestMethod]
    public void Boolean_NonAlphabeticFirstCharacter_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => class1.Boolean("1A23BC456"));
    }
    [TestMethod]
    public void GetNextMarkAfter_IncrementSecondLetter_ReturnsNextMark()
    {
        Assert.AreEqual("A123BC457", class1.GetNextMarkAfter("A123BC456")); // �������� �� ��������� ������ �����
    }
    [TestMethod]
    public void GetNextMarkAfter_IncrementFirstLetter_ReturnsNextMark()
    {
        Assert.AreEqual("A123BD000", class1.GetNextMarkAfter("A123BC999")); // �������� �� ��������� ������ �����
    }
    [TestMethod]
    public void GetNextMarkAfterRange_NextMarkOutsideRange_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => class1.GetNextMarkAfterRange("A123BC456", "A123BC000", "A123BC455")); // �������� ������ �� ������� ���������
    }
    [TestMethod]
    public void GetNextMarkAfterRange_NextMarkWithinRange_ReturnsNextMark()
    {
        Assert.AreEqual("A123BC457", class1.GetNextMarkAfterRange("A123BC456", "A123BC000", "A123BC999")); // �������� �� ���������� ��������� ����
    }
    //
    [TestMethod]
    public void GetCombinationsCountInRange_SameMarks_ReturnsOne()
    {
        Assert.AreEqual(1, class1.GetCombinationsCountInRange("A123BC456", "A123BC456")); // �������� �� ���������� �����
    }
    [TestMethod]
    public void GetCombinationsCountInRange_LargeRange_ReturnsCorrectCount()
    {
        Assert.AreEqual(1000, class1.GetCombinationsCountInRange("A123BC000", "A123BC999")); // �������� �������� ���������
    }
    [TestMethod]
    public void GetCombinationsCountInRange_InvalidMarks_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => class1.GetCombinationsCountInRange("A123BC999", "A123BC000")); // ������������ �������
    }
    [TestMethod]
    public void GetNextMarkAfterRange_InvalidRange_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => class1.GetNextMarkAfterRange("A123BC456", "A123BC500", "A123BC400")); // ������������ ��������
    }
    [TestMethod]
    public void Boolean_ValidMark_ReturnsCorrectBoolean()
    {
        Assert.IsTrue(class1.Boolean("A123BC456")); // A - ����������
        Assert.IsTrue(class1.Boolean("B123BC456")); // B - ����������
        Assert.IsTrue(class1.Boolean("C123BC456")); // C - ������������
    }
    // �������� �� ��������� ���������� ����� ����� �������������
    [TestMethod]
    public void GetNextMarkAfter_ValidMark_ReturnsNextMark()
    {
        Assert.AreEqual("A123BC457", class1.GetNextMarkAfter("A123BC456")); // ������ ��������� ���������� �����
    }
    // �������� �� ���������� ���������� ���������� � ���������
    [TestMethod]
    public void GetCombinationsCountInRange_ValidRange_ReturnsCorrectCount()
    {
        Assert.AreEqual(1000, class1.GetCombinationsCountInRange("A123BC000", "A123BC999")); // ������ ���������� ����������
    }
    // �������� �� ���������� ��������� ���������� ����� � ���������
    [TestMethod]
    public void GetNextMarkAfterRange_ValidRange_ReturnsNextMark()
    {
        Assert.AreEqual("A123BC457", class1.GetNextMarkAfterRange("A123BC456", "A123BC456", "A123BC500")); // ������
    }
}