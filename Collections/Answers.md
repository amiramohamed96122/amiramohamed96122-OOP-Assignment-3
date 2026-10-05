 ### Task 2.1 --- Research: IReadOnlyDictionary & SortedDictionary

  ## IReadOnlyDictionary

    IReadOnlyDictionary<TKey, TValue> is an interface that lets you read key-value data without modifying it. You can access values, check keys, and loop through the collection, but you cannot add, remove, or change items through the interface.

  ## IReadOnlyDictionary vs Dictionary

    **  A Dictionary<TKey, TValue> allows both reading and modifying the data. **

- code example

{
Dictionary<int, string> students = new();
students.Add(1, "Amira");
students[1] = "Aisha";
students.Remove(1);
}

 # With IReadOnlyDictionary:

IReadOnlyDictionary<int, string> students = new Dictionary<int, string>
{
    { 1, "Amira" }
};

You can read:

Console.WriteLine(students[1]);

but you cannot modify it through students.

# Why would a public method return IReadOnlyDictionary?

 ** A public method can return IReadOnlyDictionary when the caller only needs to see the data, not change it. ** 

This is useful because it protects the collection from unwanted changes and makes the method's intention clear.

public IReadOnlyDictionary<int, string> GetStudents()
{
    return students;
}

The method is basically saying: "Here is the data, but you should only read it."



### SortedDictionary

SortedDictionary<TKey, TValue> is a dictionary that keeps its items sorted by their keys.

For example:

SortedDictionary<int, string> students = new()
{
    { 3, "Aya" },
    { 1, "Amira" },
    { 2, "Aisha" }
};

When you loop through it, the keys appear as:

1 - Amira
2 - Aisha
3 - Aya
SortedDictionary vs Dictionary

The main difference is ordering and lookup performance:

              Dictionary	   SortedDictionary

Ordering	Not sorted by key	Sorted by key
Lookup	    Average O(1)          	O(log n)
Best for	Fast key lookup	     Sorted data + key lookup

A normal Dictionary uses hashing, so looking up a key is usually O(1) on average.

A SortedDictionary is based on a sorted tree structure, so finding a key takes O(log n).

When would I choose SortedDictionary?

I would choose SortedDictionary when I need the data to always be sorted by key and I also need to search for keys.

For example, if I store student IDs and names and want to display students automatically in ID order, SortedDictionary would be useful.



###  Task 2.2  Pick the Collection
 **S1** Find a student by national ID — thousands of  times a day : `Dictionary`  
           It provides very fast lookup by key, so it is a good choice for finding a student by national ID repeatedly.   

**S2** Keep the tags of a course. The same tag must never be stored twice.  :  `HashSet`  
        It automatically prevents duplicate values


 **S3** Keep a student's grades in the order they were entered.
        The same grade can appear more than once.                       :  `List` 
             It keeps the order in which grades were added and 
             allows duplicate values.                                                  

 **S4** A public method returns the course price list. Callers can 
         read prices but must not add or change any.       :        `IReadOnlyDictionary` 

        It allows callers to read prices by key while preventing them from modifying the collection through the returned interface. 

 **S5** A timetable keyed by session start time. Sessions are added 
        at any moment, and it must always print in time order.     :  `SortedDictionary`    
                  It automatically keeps the sessions sorted by their start-time
                   keys even when new sessions are added.                       

 **S6** A method returns results that the caller only loops 
        over once and may stop early.                         :`IEnumerable`         
             It is suitable for sequential iteration and allows
             the caller to stop before processing all the results.                    


