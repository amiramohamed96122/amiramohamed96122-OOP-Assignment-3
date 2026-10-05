# Answers

## Step 2

### What is the same?

StudentStore and CourseStore have the same four methods:

- Add
- GetById
- GetAll
- Remove

Both stores use a List to store their objects.
Both GetById methods search for an item by its Id.
Both Remove methods remove an item by its Id.

### What is different?

StudentStore stores Student objects, while CourseStore stores Course objects.

Student has:
- Id
- Name

Course has:
- Id
- Title
- Price

## Step 3

### Compiler error

'T' does not contain a definition for 'Id'
and no accessible extension method 'Id' accepting a first argument of type 'T' could be found.

### Explanation

The compiler does not know that T has an Id property.

T can represent any type, and not every type has an Id property.

For example, string does not have an Id property.

Therefore, the compiler cannot allow us to write item.Id.

## Step 7

### Why must Store<string> not compile?

Store<T> has the constraint:

where T : IHasId

This means that T must implement IHasId.

Student and Course implement IHasId, so they can be used with Store<T>.

String does not implement IHasId, so Store<string> must not compile.

## Final Question

The common name for this kind of class is a Generic Repository.
