using System;
using System.Collections.Generic;
using Xunit;

namespace AdvancedMD.API.Clincial.Extensions.Collections.Tests.IDictionary {
  public class DictionaryExtensionMethodsTests {
    private class TestObject {
      public string Name { get; set; }
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Throws_Exception_When_Dictionary_Is_Null_Using_Reference_Types() {
      Dictionary<string, TestObject> dictionary = null;

      Assert.Throws<NullReferenceException>(() => dictionary.ValueOrDefault("test0"));
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Returns_Existing_Object_When_Value_Found_Using_Reference_Types() {
      var testObject1 = new TestObject() { Name = "Object 1" };

      var dictrionary = new Dictionary<string, TestObject> {
        {"test0", testObject1},
      };

      var result = dictrionary.ValueOrDefault("test0");
      Assert.Equal(result, testObject1);
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Returns_Null_When_Dictionary_Is_Empty_Using_Reference_Types() {

      var dictrionary = new Dictionary<string, TestObject>();

      var result = dictrionary.ValueOrDefault("test15");
      Assert.Null(result);
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Returns_Null_When_Value_Not_Found_Using_Reference_Types() {

      var dictrionary = new Dictionary<string, TestObject> {
        {"test0", new TestObject() { Name = "Object 1" }},
      };

      var result = dictrionary.ValueOrDefault("test15");
      Assert.Null(result);
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Throws_Exception_When_Dictionary_Is_Null_Using_Reference_Types() {

      var defaultValue = new TestObject() { Name = "Default Object" };
      Dictionary<string, TestObject> dictionary = null;

      Assert.Throws<NullReferenceException>(() => dictionary.ValueOrDefault("test0", defaultValue));
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Returns_Existing_Object_When_Value_Found_Using_Reference_Types() {
      var testObject1 = new TestObject() { Name = "Object 1" };
      var defaultValue = new TestObject() { Name = "Default Object" };

      var dictrionary = new Dictionary<string, TestObject> {
        {"test0", testObject1},
      };

      var result = dictrionary.ValueOrDefault("test0", defaultValue);
      Assert.Equal(result, testObject1);
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Returns_User_Supplied_Default_When_Dictionary_Is_Empty_Using_Reference_Types() {
      var defaultValue = new TestObject() { Name = "Default Object" };
      var dictrionary = new Dictionary<string, TestObject>();

      var result = dictrionary.ValueOrDefault("test15", defaultValue);
      Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Returns_User_Supplied_Default_When_Value_Not_Found_Using_Reference_Types() {

      var defaultValue = new TestObject() { Name = "Default Object" };

      var dictrionary = new Dictionary<string, TestObject> {
        {"test0", new TestObject() { Name = "Object 1" }},
      };

      var result = dictrionary.ValueOrDefault("test15", defaultValue);

      Assert.Equal(result, defaultValue);
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Throws_Exception_When_Dictionary_Is_Null_Using_Value_Types() {
      var lookupKey = "RANDOMKEY";

      Dictionary<string, int> dictrionary = null;

      Assert.Throws<NullReferenceException>(() => dictrionary.ValueOrDefault(lookupKey));
    }

    [Fact]
    public void Dictionary_Value_Or_System_Default_Returns_Existing_Value_When_Value_Found_Using_Value_Types() {

      var expectedValue = 15;
      var lookupKey = "RANDOMKEY";

      var dictrionary = new Dictionary<string, int> { { lookupKey, expectedValue } };
      var actualValue = dictrionary.ValueOrDefault(lookupKey);

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void Dictionary_Value_Or_Default_Returns_DataType_Default_When_Value_Not_Found_Using_Value_Types() {

      var expectedValue = default(int);
      var testKey = "PRIMARYKEY";
      var testValue = 10000;
      var lookupKey = "RANDOMKEY";

      var dictionary = new Dictionary<string, int> { { testKey, testValue } };
      var actualValue = dictionary.ValueOrDefault(lookupKey);

      Assert.Equal(actualValue, expectedValue);
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Throws_Exception_When_Dictionary_Is_Null_Using_Value_Types() {

      var userDefaultValue = 10;
      var lookupKey = "RANDOMKEY";

      Dictionary<string, int> dictrionary = null;

      Assert.Throws<NullReferenceException>(() => dictrionary.ValueOrDefault(lookupKey, userDefaultValue));
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Returns_Existing_Value_When_Value_Found_Using_Value_Types() {

      int expectedValue = 1;
      int userDefaultValue = 1000;
      var lookupKey = "RANDOMKEY";

      var dictionary = new Dictionary<string, int> { { lookupKey, expectedValue } };
      var actualValue = dictionary.ValueOrDefault(lookupKey, userDefaultValue);

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void Dictionary_Value_Or_User_Default_Returns_User_Supplied_Value_When_Value_Not_Found_Using_Value_Types() {

      var testKey = "TESTKEY";
      var testValue = 1000;

      var userDefaultValue = 681465410;
      var lookupKey = "RANDOMKEY";

      var dictionary = new Dictionary<string, int> { { testKey, testValue } };
      var actualValue = dictionary.ValueOrDefault(lookupKey, userDefaultValue);

      Assert.Equal(userDefaultValue, actualValue);
    }
  }
}