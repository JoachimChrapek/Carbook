
using TmpConsoleApp;

TestMethod();

void TestMethod()
{
    Console.WriteLine("Test");

    Calculator calculator = new();
    TestRecord testRecord = new TestRecord(3, "asd", calculator);
    TestRecord testRecord2 = new TestRecord(3, "asd", calculator);
    
    Console.WriteLine(testRecord == testRecord2);

    TestClass testClass = new TestClass(3, "asd");
    TestClass2 testClass2 = new TestClass2 {
        Number = 3,
        Desc = "asd"
    };
    
    TestRecordStruct testRecordStruct = new TestRecordStruct(3, "asd");

    Console.WriteLine("Test");
}

IEnumerable<TestClass> GetClasess(int count)
{
    for (int i = 0; i < count; i++)
    {
        yield return new TestClass(i, i.ToString());
    }
}

public record TestRecord(int Number, string Desc, Calculator Calculator);

public record struct TestRecordStruct(int Number, string Desc);

public class TestClass(int Number, string Desc);

public class TestClass2
{
    public required int Number { get; init; }
    public required string Desc { get; init; }
}