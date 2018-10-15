using System;
using System.Collections.Generic;
using AdvancedMD.API.Clincial.Extensions.Collections.Tests.IDictionary;
using Xunit;

namespace AdvancedMD.API.Clincial.Extensions.Collections.Tests {
  public class LambdaEqualityComparerTests {


    private class TestObject {

      public Guid Id { get; set; }

      public string Name { get; set; }
    }

    [Fact]
    public void Lambda_Comparer_Throws_Exception_When_Comparing_Null_Values_And_EqualityLambda_Is_Null() {
      Assert.Throws<ArgumentNullException>(() => new LambdaObjectEqualityComparer<TestObject>(null, null));
    }

    [Fact]
    public void Lambda_Comparer_Evaluates_To_True_When_Comparing_Same_Values_And_Hashing_Function_Is_Provided() {

      TestObject t1 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Bob"
      };

      TestObject t2 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Smith"
      };

      var comparer = new LambdaObjectEqualityComparer<TestObject>((x, y) => x.Id == y.Id, x => x.Id.GetHashCode());
      bool same1and2 = comparer.Equals(t1, t2);

      Assert.True(same1and2);
    }

    [Fact]
    public void Lambda_Comparer_Evaluates_To_True_When_Comparing_Same_Values_And_Hashing_Function_Is_Not_Provided() {

      TestObject t1 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Bob"
      };

      TestObject t2 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Smith"
      };

      var comparer = new LambdaObjectEqualityComparer<TestObject>((x, y) => x.Id == y.Id);
      bool same1and2 = comparer.Equals(t1, t2);

      Assert.True(same1and2);
    }

    [Fact]
    public void Lambda_Comparer_Evaluates_To_False_When_Comparing_Different_Values_And_Hashing_Function_Is_Provided() {

      TestObject t1 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Bob"
      };

      TestObject t2 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Smith"
      };

      var comparer = new LambdaObjectEqualityComparer<TestObject>((x, y) => x.Name == y.Name, o => o.Name.GetHashCode());
      bool same1and2 = comparer.Equals(t1, t2);

      Assert.False(same1and2);
    }

    [Fact]
    public void Lambda_Comparer_Evaluates_To_False_When_Comparing_Different_Values_And_Hashing_Function_Is_Not_Provided() {

      TestObject t1 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Bob"
      };

      TestObject t2 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Smith"
      };

      var comparer = new LambdaObjectEqualityComparer<TestObject>((x, y) => x.Name == y.Name);
      bool same1and2 = comparer.Equals(t1, t2);

      Assert.False(same1and2);
    }

    [Fact]
    public void Lambda_Comparer_Evaluates_To_True_When_Comparing_Multiple_Objects_And_Hashing_Function_Is_Not_Provided() {

      TestObject t1 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Bob"
      };

      TestObject t2 = new TestObject {
        Id = new Guid("12345678901234567890123456789012"),
        Name = "Smith"
      };

      TestObject t3 = new TestObject() {
        Id = new Guid("11111111111111111111111111111111"),
        Name = "Bob"
      };

      var comparer = new LambdaObjectEqualityComparer<TestObject>((x, y) => x.Name == y.Name);
      bool same1and2 = comparer.Equals(t1, t2);  //false
      bool same1and3 = comparer.Equals(t1, t3);  //true
      bool same2and3 = comparer.Equals(t2, t3);  //false

      Assert.False(same1and2);
      Assert.True(same1and3);
      Assert.False(same2and3);
    }
  }
}