using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using System.Collections.Concurrent;

namespace Collections.Tests {
  public class IEnumerableExtensionsTests {
    public interface ITestObject<in T> {
      void RunMethod(T value);
      void RunMethod(T value, int index);
    }

    [Fact]
    public void Generic_IEnumerable_Non_Indexed_ForEach_Throws_Exceptions_Because_It_Is_Null() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>()));

      IEnumerable<int> sequence = null;

      Assert.Throws<NullReferenceException>(() => sequence.ForEach(element => mock.Object.RunMethod(element)));
      mock.Verify(m => m.RunMethod(It.IsAny<int>()), Moq.Times.Never);
    }

    [Fact]
    public void Generic_IEnumerable_Non_Indexed_ForEach_Did_Not_Execute_Any_Actions_Because_It_Is_Empty() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>()));

      var sequence = new List<int>().AsEnumerable();

      sequence.ForEach(element => mock.Object.RunMethod(element));

      mock.Verify(m => m.RunMethod(It.IsAny<int>()), Moq.Times.Never);
    }

    [Fact]
    public void Generic_IEnumerable_Non_Indexed_ForEach_Executed_Action_For_Every_Element_When_It_Has_1_Elements() {
      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>())).Verifiable();

      var sequence = new List<int>() { 12 }.AsEnumerable();

      sequence.ForEach(element => mock.Object.RunMethod(element));

      mock.Verify(m => m.RunMethod(It.IsAny<int>()), Moq.Times.Once);
    }

    [Fact]
    public void Generic_IEnumerable_Non_Indexed_ForEach_Executed_Action_For_Every_Element_When_It_Has_Many_Elements() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>())).Verifiable();

      var sequence = new List<int>() { 1, 2 }.AsEnumerable();

      sequence.ForEach(element => mock.Object.RunMethod(element));

      mock.Verify(m => m.RunMethod(It.IsAny<int>()), Moq.Times.AtLeast(2));
      mock.Verify(m => m.RunMethod(It.IsAny<int>()), Moq.Times.AtMost(2));
    }

    [Fact]
    public void Generic_IEnumerable_Indexed_ForEach_Throws_Exceptions_Because_It_Is_Null() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

      IEnumerable<int> sequence = null;

      Assert.Throws<NullReferenceException>(() => sequence.ForEach((element, index) => mock.Object.RunMethod(element, index)));
      mock.Verify(m => m.RunMethod(It.IsAny<int>(), It.IsAny<int>()), Moq.Times.Never);
    }

    [Fact]
    public void Generic_IEnumerable_Indexed_ForEach_Did_Not_Execute_Any_Actions_Because_It_Is_Empty() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

      var sequence = new List<int>().AsEnumerable();
      sequence.ForEach((element, index) => mock.Object.RunMethod(element, index));

      mock.Verify(m => m.RunMethod(It.IsAny<int>(), It.IsAny<int>()), Moq.Times.Never);
    }

    [Fact]
    public void Generic_IEnumerable_Indexed_ForEach_Executed_Action_For_Every_Element_When_It_Has_1_Elements() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

      var sequence = new List<int>() { 15 }.AsEnumerable();
      sequence.ForEach((element, index) => mock.Object.RunMethod(element, index));

      mock.Verify(m => m.RunMethod(It.IsAny<int>(), It.IsAny<int>()), Moq.Times.Once);

    }

    [Fact]
    public void Generic_IEnumerable_Indexed_ForEach_Executed_Action_For_Every_Element_When_It_Has_Many_Elements() {

      var mock = new Mock<ITestObject<int>>(MockBehavior.Strict);
      mock.Setup(x => x.RunMethod(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

      var sequence = new List<int>() { 15, 37, 52 }.AsEnumerable();
      sequence.ForEach((element, index) => mock.Object.RunMethod(element, index));

      mock.Verify(m => m.RunMethod(It.IsAny<int>(), It.IsAny<int>()), Moq.Times.AtLeast(3));
      mock.Verify(m => m.RunMethod(It.IsAny<int>(), It.IsAny<int>()), Moq.Times.AtMost(3));

    }

    [Fact]
    public void IndexOf_Based_On_Item_Search_Throws_Exception_When_Sequence_Is_Null() {
      IEnumerable<int> test = null;
      int searchTerm = 5;

      Assert.Throws<NullReferenceException>(() => test.IndexOf(searchTerm));
    }

    [Fact]
    public void IndexOf_Based_On_Item_Search_Returns_Negative_One_When_Sequence_Is_Empty() {
      var test = Enumerable.Empty<int>();

      int searchTerm = 5;
      int expectedIndex = -1;
      int actualIndex = test.IndexOf(searchTerm);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Item_Search_Returns_Negative_One_When_Item_Not_Found() {
      IEnumerable<int> test = Enumerable.Range(1, 4);

      int searchTerm = 5;
      int expectedIndex = -1;
      int actualIndex = test.IndexOf(searchTerm);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Item_Search_Returns_Index_When_Item_Is_Found() {
      var sequence = Enumerable.Range(0, 9);

      int searchTerm = 5;
      int expectedIndex = 5;
      int actualIndex = sequence.IndexOf(searchTerm);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Item_Search_Returns_Index_Of_First_Match_When_Match_Found_And_Repeating_Items() {
      var sequence = Enumerable.Range(0, 9).Union(Enumerable.Range(0, 9));

      int searchTerm = 5;
      int expectedIndex = 5;
      int actualIndex = sequence.IndexOf(searchTerm);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Lambda_Search_Throws_Exception_When_Sequence_Is_Null() {
      IEnumerable<int> test = null;
      Assert.Throws<NullReferenceException>(() => test.IndexOf(x => x < 5));
    }

    [Fact]
    public void IndexOf_Based_On_Lambda_Search_Returns_Negative_One_When_Sequence_Is_Empty() {
      var test = Enumerable.Empty<int>();

      int expectedIndex = -1;
      int actualIndex = test.IndexOf(x => x < 5);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Lambda_Search_Returns_Negative_One_When_Item_Not_Found() {
      IEnumerable<int> test = Enumerable.Range(1, 10);

      int expectedIndex = -1;

      int actualIndex = test.IndexOf(x => x > 50);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Lambda_Search_Returns_Index_Of_First_Match_When_Match_Found() {
      IEnumerable<int> test = Enumerable.Range(1, 10);

      int expectedIndex = 6;

      int actualIndex = test.IndexOf(x => x == 7);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IndexOf_Based_On_Lambda_Search_Returns_Index_Of_First_Match_When_Match_Found_And_Repeating_Items() {
      IEnumerable<int> test = Enumerable.Range(1, 10).Union(Enumerable.Range(1, 10));

      int expectedIndex = 6;

      int actualIndex = test.IndexOf(x => x == 7);

      Assert.Equal(expectedIndex, actualIndex);
    }

    [Fact]
    public void IsEmpty_Throws_Exception_When_Array_Is_Null() {
      string[] testValue = null;

      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Array_Is_Not_Null_But_Empty() {
      string[] testValue = new string[0];
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Array_Is_Not_Null_And_Not_Empty() {
      string[] testValue = new string[1] { "test" };
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }
    
    [Fact]
    public void IsEmpty_Throws_Exception_When_Generic_List_Is_Null() {
      List<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Generic_List_Not_Null_But_Empty() {
      List<string> testValue = new List<string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Generic_List_Not_Null_And_Not_Empty() {
      List<string> testValue = new List<string>() { "test" };
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsEmpty_Throws_Exception_When_Linked_List_Is_Null() {
      LinkedList<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Linked_List_Is_Not_Null_But_Empty() {
      LinkedList<string> testValue = new LinkedList<string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Linked_List_Not_Null_And_Not_Empty() {
      LinkedList<string> testValue = new LinkedList<string>();
      testValue.AddFirst("test");
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }
    
    [Fact]
    public void IsEmpty_Throws_Exception_When_Generic_Queue_Is_Null() {
      Queue<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Generic_Queue_Is_Not_Null_But_Empty() {
      Queue<string> queue = new Queue<string>();
      Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Generic_Queue_Is_Not_Null_And_Not_Empty() {
      Queue<string> queue = new Queue<string>();
      queue.Enqueue("Test");
      Assert.False(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Throws_Exception_When_Generic_Stack_Is_Null() {
      Stack<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Generic_Stack_Is_Not_Null_But_Empty() {
      Stack<string> stack = new Stack<string>();
      Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Generic_Stack_Is_Not_Null_And_Not_Empty() {
      Stack<string> stack = new Stack<string>();
      stack.Push("test");
      Assert.False(stack.IsEmpty());
    }
   
    [Fact]
    public void IsEmpty_Throws_Exception_When_Dictionary_Is_Null() {
      Dictionary<string, string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Dictionary_Is_Not_Null_But_Emtpy() {
      Dictionary<string, string> testValue = new Dictionary<string, string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Dictionary_Is_Not_Null_And_Not_Empty() {
      Dictionary<string, string> testValue = new Dictionary<string, string>();
      testValue.Add("test1", "test1");
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }
   
    [Fact]
    public void IsEmpty_Throws_Exception_When_Generic_HashSet_Is_Null() {
      HashSet<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Generic_HashSet_Is_Not_Null_But_Empty() {
      HashSet<string> testValue = new HashSet<string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Generic_HashSet_Is_Not_Null_And_Not_Empty() {
      HashSet<string> testValue = new HashSet<string>();
      testValue.Add("test");
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }
   
    [Fact]
    public void IsEmpty_Throws_Exception_When_Concurrent_Bag_Is_Null() {
      ConcurrentBag<string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Concurrent_Bag_Is_Not_Null_But_Empty() {
      ConcurrentBag<string> testValue = new ConcurrentBag<string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Concurrent_Bag_Is_Not_Null_And_Not_Empty() {
      ConcurrentBag<string> testValue = new ConcurrentBag<string>();
      testValue.Add("test");
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsEmpty_Throws_Exception_When_Concurrent_Dictionary_Is_Null() {
      ConcurrentDictionary<string, string> testValue = null;
      Assert.Throws<ArgumentNullException>(() => testValue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_Returns_True_When_Concurrent_Dictionary_Is_Not_Null_But_Empty() {
      ConcurrentDictionary<string, string> testValue = new ConcurrentDictionary<string, string>();
      bool result = testValue.IsEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsEmpty_Returns_False_When_Concurrent_Dictionary_Is_Not_Null_And_Not_Empty() {
      ConcurrentDictionary<string, string> testValue = new ConcurrentDictionary<string, string>();
      testValue.TryAdd("test", "Test");
      bool result = testValue.IsEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Array_Is_Null() {
      string[] testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Array_Is_Not_Null_But_Empty() {
      string[] testValue = new string[0];
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Array_Is_Not_Null_And_Not_Empty() {
      string[] testValue = new string[1] { "test" };
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_List_Is_Null() {
      List<string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_List_IS_Not_Null_But_Empty() {
      List<string> testValue = new List<string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Generic_List_Not_Null_And_Not_Empty() {
      List<string> testValue = new List<string>() { "test" };
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Linked_List_Is_Null() {
      LinkedList<string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Linked_List_Is_Not_Null_But_Empty() {
      LinkedList<string> testValue = new LinkedList<string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Linked_List_Not_Null_And_Not_Empty() {
      LinkedList<string> testValue = new LinkedList<string>();
      testValue.AddFirst("test");
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }
    
    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_Queue_Is_Null() {
      Queue<string> queue = null;
      Assert.True(queue.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_Queue_Is_Not_Null_But_Empty() {
      Queue<string> queue = new Queue<string>();
      Assert.True(queue.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Generic_Queue_Is_Not_Null_And_Not_Empty() {
      Queue<string> queue = new Queue<string>();
      queue.Enqueue("Test");
      Assert.False(queue.IsNullOrEmpty());
    }
    
    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_Stack_Is_Null() {
      Stack<string> stack = null;
      Assert.True(stack.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_Stack_Is_Not_Null_But_Empty() {
      Stack<string> stack = new Stack<string>();
      Assert.True(stack.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Generic_Stack_Is_Not_Null_And_Not_Empty() {
      Stack<string> stack = new Stack<string>();
      stack.Push("test");
      Assert.False(stack.IsNullOrEmpty());
    }
   
    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Dictionary_Is_Null() {
      Dictionary<string, string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Dictionary_Is_Not_Null_But_Emtpy() {
      Dictionary<string, string> testValue = new Dictionary<string, string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Dictionary_Is_Not_Null_And_Not_Empty() {
      Dictionary<string, string> testValue = new Dictionary<string, string>();
      testValue.Add("test1", "test1");
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }
   
    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_HashSet_Is_Null() {
      HashSet<string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Generic_HashSet_Is_Not_Null_But_Empty() {
      HashSet<string> testValue = new HashSet<string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Generic_HashSet_Is_Not_Null_And_Not_Empty() {
      HashSet<string> testValue = new HashSet<string>();
      testValue.Add("test");
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Concurrent_Bag_Is_Null() {
      ConcurrentBag<string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Concurrent_Bag_Is_Not_Null_But_Empty() {
      ConcurrentBag<string> testValue = new ConcurrentBag<string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Concurrent_Bag_Is_Not_Null_And_Not_Empty() {
      ConcurrentBag<string> testValue = new ConcurrentBag<string>();
      testValue.Add("test");
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }
   
    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Concurrent_Dictionary_Is_Null() {
      ConcurrentDictionary<string, string> testValue = null;
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_Concurrent_Dictionary_Is_Not_Null_But_Empty() {
      ConcurrentDictionary<string, string> testValue = new ConcurrentDictionary<string, string>();
      bool result = testValue.IsNullOrEmpty();

      Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_Concurrent_Dictionary_Is_Not_Null_And_Not_Empty() {
      ConcurrentDictionary<string, string> testValue = new ConcurrentDictionary<string, string>();
      testValue.TryAdd("test", "Test");
      bool result = testValue.IsNullOrEmpty();

      Assert.False(result);
    }

    [Fact]
    public void Split_Throws_Exception_When_Sequence_Is_Null() {
      IEnumerable<int> sequence = null;
      Assert.Throws<NullReferenceException>(() => sequence.Split(5));
    }

    [Fact]
    public void Split_Returns_Empty_Result_When_Sequence_Is_Empty() {
      var sequence = Enumerable.Empty<int>();

      var expectedResult = new List<List<int>>();
      var actualResult = sequence.Split(5);

      Assert.Equal(expectedResult.Count, actualResult.Count);
    }

    [Fact]
    public void Split_Splits_Properly_When_Elements_Divisible_By_Chunk_Size() {
      var sequence = Enumerable.Range(1, 10);

      var expectedResult = new List<List<int>>() {
        new List<int>() {1, 2, 3, 4, 5},
        new List<int>() {6, 7, 8, 9, 10}
      };
      var actualResult = sequence.Split(5);

      Assert.Equal(expectedResult.Count, actualResult.Count);
      Assert.Equal(expectedResult[0].Count, actualResult[0].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[0], actualResult[0]));
      Assert.Equal(expectedResult[1].Count, actualResult[1].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[1], actualResult[1]));
    }

    [Fact]
    public void Split_Splits_Properly_When_Elements_Not_Divisible_By_Chunk_Size() {
      var sequence = Enumerable.Range(1, 9);

      var expectedResult = new List<List<int>>() {
        new List<int>() {1, 2, 3, 4, 5},
        new List<int>() {6, 7, 8, 9}
      };
      var actualResult = sequence.Split(5);

      Assert.Equal(expectedResult.Count, actualResult.Count);
      Assert.Equal(expectedResult[0].Count, actualResult[0].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[0], actualResult[0]));
      Assert.Equal(expectedResult[1].Count, actualResult[1].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[1], actualResult[1]));
    }

    [Fact]
    public void Split_Splits_Properly_When_Chunk_Count_Is_1() {
      var sequence = Enumerable.Range(1, 3);

      var expectedResult = new List<List<int>>() {
        new List<int>() {1},
        new List<int>() {2},
        new List<int>() {3}
      };
      var actualResult = sequence.Split(1);

      Assert.Equal(expectedResult.Count, actualResult.Count);
      Assert.Equal(expectedResult[0].Count, actualResult[0].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[0], actualResult[0]));
      Assert.Equal(expectedResult[1].Count, actualResult[1].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[1], actualResult[1]));
      Assert.Equal(expectedResult[2].Count, actualResult[2].Count);
      Assert.True(Enumerable.SequenceEqual<int>(expectedResult[2], actualResult[2]));
    }
  }
}
