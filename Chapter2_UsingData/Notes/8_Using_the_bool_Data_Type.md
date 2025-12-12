

# Detailed Notes — Using the `bool` Data Type

[← Back to README](./README.md)

 
 ### What is `bool`?

* A `bool` variable can hold only one of two values: `true` or `false`.

* Declared with the keyword `bool`:

  ```csharp
  bool isItMonday = false;
  bool areYouTired = true;
  ```

* Compared to an `int` (which can hold millions of values), a `bool` is limited but crucial for **logic and decision-making**.

---

### Naming Convention

* No strict rules, but conventions help readability:

  * Begin names with verbs like **is** or **are** → `isComplete`, `areYouTired`.
  * Or use question-like words like **can** or **has** → `canDrive`, `hasLicense`.
* Makes it clear these represent *true/false* states.

---

### Why the Name "Boolean"?

* Named after **George Boole**, the founder of symbolic logic (1815–1864).
* The C# keyword is lowercase `bool`.
* When writing about Boolean concepts in text, capitalize it (e.g., Boolean logic).

---

### Comparison Operators

Expressions that compare values return `true` or `false`.

| Operator | Description              | True Example | False Example |
| -------- | ------------------------ | ------------ | ------------- |
| `<`      | Less than                | 3 < 8        | 8 < 3         |
| `>`      | Greater than             | 4 > 2        | 2 > 4         |
| `==`     | Equal to                 | 7 == 7       | 3 == 9        |
| `<=`     | Less than or equal to    | 5 <= 5       | 8 <= 6        |
| `>=`     | Greater than or equal to | 7 >= 3       | 1 >= 2        |
| `!=`     | Not equal to             | 5 != 6       | 3 != 3        |

---

### Important Notes

* For equality: use **`==`**, not `=`.

  * `=` is assignment.
  * `==` is comparison.

Example:

```csharp
isDiscountProvided = custStatus == 1;
```

* First `==` compares `custStatus` to 1.
* Result (`true` or `false`) is assigned to `isDiscountProvided` using `=`.

---

### Mistakes to Avoid

* Don’t confuse `=` with `==`.
* For multi-character operators (`==`, `!=`, `<=`, `>=`), don’t put spaces between the characters.

---

# Cheat Sheet — `bool` and Comparisons

* **Values:** `true`, `false`

* **Operators:**

  * `==` equal to
  * `!=` not equal to
  * `<` less than
  * `>` greater than
  * `<=` less than or equal to
  * `>=` greater than or equal to

* **Usage example:**

  ```csharp
  bool isAdult = age >= 18;  // true if age is 18 or more
  ```

---
