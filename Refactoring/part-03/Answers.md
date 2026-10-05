# Part 03 — answers


---

## BlockedUsers

- Time complexity before:   O(blockedIds × requests) => O(n^2) 
- Time (ms) before: 58 ms
- What did you change?   using HashSet instead of List
- Time complexity after:  o(n)
- Time (ms) after:  0 ms

---

## Students


- What was the problem?

`StudentCatalog` created 1,000,000 Student objects and stored them in memory,
even though the program only needed the first 3 students.

- What did you change?

I used `IEnumerable<Student>` and `yield return` to create students lazily.
Now students are created only when they are requested, so when the loop stops 
after 3 students, the remaining students are not created.
