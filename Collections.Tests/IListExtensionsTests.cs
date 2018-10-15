using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests {
  public class IListExtensionsTests {
    [Fact]
    public void LastElementIndex_Throws_Exception_When_List_Is_Null() {

      List<int> list = null;
      Assert.Throws<NullReferenceException>(() => list.LastElementIndex());

    }

    [Fact]
    public void LastElementIndex_Returns_Negative_Value_When_List_Is_Empty() {

      var list = new List<int>();

      var expectedIndex = -1;
      var actionIndex = list.LastElementIndex();

      Assert.Equal(expectedIndex, actionIndex);

    }

    [Fact]
    public void LastElementIndex_Returns_Zero_When_List_Has_One_Item() {

      var list = new List<int>() { 2342342 };

      var expectedIndex = 0;
      var actionIndex = list.LastElementIndex();

      Assert.Equal(expectedIndex, actionIndex);

    }

    [Fact]
    public void LastElementIndex_Returns_Element_Count_Minus_One_When_List_Has_Many_Items() {

      var list = new List<int>();

      var random = new Random((int)DateTime.Now.Ticks);
      var count = random.Next(2, 50);

      for(int i = 0; i < count; i++) {
        list.Add(random.Next(51, 100));
      }

      var expectedIndex = count - 1;
      var actionIndex = list.LastElementIndex();

      Assert.Equal(expectedIndex, actionIndex);

    }

    [Fact]
    public void Move_Element_Down_By_Value_Throws_NullReferenceException_When_List_Is_Null() {

      long testValue = 12;

      List<long> list = null;

      Assert.Throws<NullReferenceException>(() => list.MoveDownByValue(testValue));

    }

    [Fact]
    public void Move_Element_Down_By_Value_Throws_InvalidOperationException_When_List_Is_Empty() {
      long testValue = 12;

      var list = new List<long>();

      Assert.Throws<InvalidOperationException>(() => list.MoveDownByValue(testValue));
    }

    [Fact]
    public void Move_Element_Down_By_Value_Throws_InvalidOperationException_When_Element_Is_Not_In_List() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;
      long testValue = 12;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<InvalidOperationException>(() => list.MoveDownByValue(testValue));
    }

    [Fact]
    public void Move_Element_Down_By_Value_Throws_IndexOutOfRangeException_When_Element_Type_Is_Integer_And_Element_Value_Greater_Than_List_Count() {

      var list = new List<int>();
      Assert.Throws<IndexOutOfRangeException>(() => list.MoveDownByValue(12));

    }

    [Fact]
    public void Move_Element_Down_By_Value_Does_Nothing_When_List_Has_Only_The_Single_Element_In_It() {

      long listValue = 12;
      var list = new List<long>() { listValue };

      list.MoveDownByValue(listValue);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Down_By_Value_Decreases_The_Elements_Index_When_List_Has_Multiple_Elements() {

      long listValue1 = 12;
      long listValue2 = 37;
      var list = new List<long>() { listValue1, listValue2 };

      list.MoveDownByValue(listValue1);

      var expectedIndex = 1;
      var actualIndex = list.IndexOf(listValue1);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Down_By_Index_Throws_NullReferenceException_When_List_Is_Null() {

      int elementIndex = 4;

      List<long> list = null;

      Assert.Throws<NullReferenceException>(() => list.MoveDownByIndex(elementIndex));

    }

    [Fact]
    public void Move_Element_Down_By_Index_Throws_IndexOutOfRangeException_When_List_Is_Empty() {
      int elementIndex = 4;

      var list = new List<long>();

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveDownByIndex(elementIndex));
    }

    [Fact]
    public void Move_Element_Down_By_Index_Throws_IndexOutOfRangeException_When_Element_Is_Not_In_List() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;

      int testIndex = 9;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveDownByIndex(testIndex));
    }

    [Fact]
    public void Move_Element_Down_By_Index_Throws_IndexOutOfRangeException_When_Index_Exceeds_Last_Element_Index() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;

      int testIndex = 9;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveDownByIndex(testIndex));
    }

    [Fact]
    public void Move_Element_Down_By_Index_Does_Nothing_When_List_Has_Only_The_Single_Element_In_It() {

      long listValue = 12;
      int indexValue = 0;

      var list = new List<long>() { listValue };

      list.MoveDownByIndex(indexValue);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Down_By_Index_Decreases_The_Elements_Index_When_List_Has_Multiple_Elements() {

      long listValue1 = 12;
      long listValue2 = 37;

      int elementIndex = 0;

      var list = new List<long>() { listValue1, listValue2 };

      list.MoveDownByIndex(elementIndex);

      var expectedIndex = 1;
      var actualIndex = list.IndexOf(listValue1);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Up_By_Value_Throws_NullReferenceException_When_List_Is_Null() {

      long testValue = 12;

      List<long> list = null;

      Assert.Throws<NullReferenceException>(() => list.MoveUpByValue(testValue));

    }

    [Fact]
    public void Move_Element_Up_By_Value_Throws_InvalidOperationException_When_List_Is_Empty() {
      long testValue = 12;

      var list = new List<long>();

      Assert.Throws<InvalidOperationException>(() => list.MoveUpByValue(testValue));
    }

    [Fact]
    public void Move_Element_Up_By_Value_Throws_InvalidOperationException_When_Element_Is_Not_In_List() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;
      long testValue = 12;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<InvalidOperationException>(() => list.MoveUpByValue(testValue));
    }

    [Fact]
    public void Move_Element_Up_By_Value_Throws_IndexOutOfRangeException_When_Element_Type_Is_Integer_And_Element_Value_Greater_Than_List_Count() {

      var list = new List<int>();
      Assert.Throws<IndexOutOfRangeException>(() => list.MoveUpByValue(12));

    }

    [Fact]
    public void Move_Element_Up_By_Value_Does_Nothing_When_List_Has_Only_The_Single_Element_In_It() {

      long listValue = 12;
      var list = new List<long>() { listValue };

      list.MoveUpByValue(listValue);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Up_By_Value_Decreases_The_Elements_Index_When_List_Has_Multiple_Elements() {

      long listValue1 = 12;
      long listValue2 = 37;
      var list = new List<long>() { listValue1, listValue2 };

      list.MoveUpByValue(listValue2);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue2);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Up_By_Index_Throws_NullReferenceException_When_List_Is_Null() {

      int elementIndex = 4;

      List<long> list = null;

      Assert.Throws<NullReferenceException>(() => list.MoveUpByIndex(elementIndex));

    }

    [Fact]
    public void Move_Element_Up_By_Index_Throws_IndexOutOfRangeException_When_List_Is_Empty() {
      int elementIndex = 4;

      var list = new List<long>();

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveUpByIndex(elementIndex));
    }

    [Fact]
    public void Move_Element_Up_By_Index_Throws_IndexOutOfRangeException_When_Element_Is_Not_In_List() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;

      int testIndex = 9;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveUpByIndex(testIndex));
    }

    [Fact]
    public void Move_Element_Up_By_Index_Throws_IndexOutOfRangeException_When_Index_Exceeds_Last_Element_Index() {

      long listValue1 = 15;
      long listValue2 = 9;
      long listValue3 = 37;

      int testIndex = 9;

      var list = new List<long>() { listValue1, listValue2, listValue3 };

      Assert.Throws<IndexOutOfRangeException>(() => list.MoveUpByIndex(testIndex));
    }

    [Fact]
    public void Move_Element_Up_By_Index_Does_Nothing_When_List_Has_Only_The_Single_Element_In_It() {

      long listValue = 12;
      int indexValue = 0;

      var list = new List<long>() { listValue };

      list.MoveUpByIndex(indexValue);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Move_Element_Up_By_Index_Decreases_The_Elements_Index_When_List_Has_Multiple_Elements() {

      long listValue1 = 12;
      long listValue2 = 37;

      int elementIndex = 1;

      var list = new List<long>() { listValue1, listValue2 };

      list.MoveUpByIndex(elementIndex);

      var expectedIndex = 0;
      var actualIndex = list.IndexOf(listValue2);

      Assert.Equal(expectedIndex, actualIndex);

    }

    [Fact]
    public void Remove_Throws_NullReferenceException_When_List_Is_Null() {
      List<int> list = null;
      Assert.Throws<NullReferenceException>(() => list.Remove(x => x > 5));
    }

    [Fact]
    public void Remove_Does_Nothing_When_List_Is_Empty() {
      var list = new List<int>();

      list.Remove(x => x > 5);

      int expectedCount = 0;
      int actualCount = list.Count;

      Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void Remove_Does_Nothing_When_List_Not_Empty_And_Predicate_Does_Not_Match_Any_Elements() {

      var listValue1 = 22;
      var listValue2 = 23;
      var listValue3 = 24;
      var listValue4 = 25;

      var list = new List<int>() { listValue1, listValue2, listValue3, listValue4 };

      list.Remove(x => x >= 1 && x <= 10);

      int expectedCount = 4;
      int actualCount = list.Count;

      Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void Remove_Removes_Items_From_List_Not_Empty_And_Predicate_Matches_Any_Elements() {

      var listValue1 = 22;
      var listValue2 = 23;
      var listValue3 = 24;
      var listValue4 = 25;

      var list = new List<int>() { listValue1, listValue2, listValue3, listValue4 };

      list.Remove(x => x == 22 || x == 23);

      int expectedCount = 2;
      int actualCount = list.Count;

      int expectedListValue1Index = -1;
      int actualListValue1Index = list.IndexOf(listValue1);

      int expectedListValue2Index = -1;
      int actualListValue2Index = list.IndexOf(listValue2);

      Assert.Equal(expectedCount, actualCount);
      Assert.Equal(expectedListValue1Index, actualListValue1Index);
      Assert.Equal(expectedListValue2Index, actualListValue2Index);
    }

    [Fact]
    public void Remove_Throws_ArgumentNullException_When_List_Not_Empty_And_Predicate_Is_Null() {

      var listValue1 = 22;
      var listValue2 = 23;
      var listValue3 = 24;
      var listValue4 = 25;

      var list = new List<int>() { listValue1, listValue2, listValue3, listValue4 };

      Assert.Throws<ArgumentNullException>(() => list.Remove(null));
    }

    [Fact]
    public void Swap_Throws_NullReferenceException_When_List_Is_Null() {
      List<long> list = null;
      Assert.Throws<NullReferenceException>(() => list.SwapByIndex(7, 2));
    }

    [Fact]
    public void Swap_Throws_InvalidOperationException_When_List_Is_Empty() {
      var list = new List<long>();
      Assert.Throws<InvalidOperationException>(() => list.SwapByIndex(7, 2));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_From_Index_Lower_Than_Zero() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = -7;
      int toIndex = 5;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_From_Index_Greater_Than_List_Count() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = 77;
      int toIndex = 5;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_To_Index_Lower_Than_Zero() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = 1;
      int toIndex = -99;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_To_Index_Greater_Than_List_Count() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = 1;
      int toIndex = 3215;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_FromIndex_Lower_Than_Zero_And_To_Index_Lower_Than_Zero() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = -1;
      int toIndex = -99;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Throws_IndexOutOfRangeException_When_FromIndex_Greater_Than_List_Count_And_To_Index_Greater_Than_List_Count() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = 55;
      int toIndex = 73;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      Assert.Throws<IndexOutOfRangeException>(() => list.SwapByIndex(fromIndex, toIndex));
    }

    [Fact]
    public void Swap_Rearanges_Two_Items_When_List_Has_Multiple_Items_And_Item_Indexes_Are_In_Range_Of_Zero_To_List_Count_Minus_One() {

      long listValue1 = 1;
      long listValue2 = 2;
      long listValue3 = 4;
      long listValue4 = 17;

      int fromIndex = 1;
      int toIndex = 2;

      var list = new List<long>() { listValue1, listValue2, listValue3, listValue4 };
      list.SwapByIndex(fromIndex, toIndex);

      int expectedListValue2Index = 2;
      int actualListValue2Index = list.IndexOf(listValue2);

      int expectedListValue3Index = 1;
      int actualListValue3Index = list.IndexOf(listValue3);

      Assert.Equal(expectedListValue2Index, actualListValue2Index);
      Assert.Equal(expectedListValue3Index, actualListValue3Index);
    }
  }
}