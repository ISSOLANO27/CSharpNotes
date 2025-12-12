

# Detailed Notes — Working with Enumerations in C\#

[← Back to README](./README.md)

 
 ## What is an Enumeration?

* An **enumeration** (`enum`) is a set of **named constants** grouped under one type.
* Syntax:

  ```csharp
  enum DayOfWeek
  {
      SUNDAY, MONDAY, TUESDAY, WEDNESDAY,
      THURSDAY, FRIDAY, SATURDAY
  }
  ```
* By default:

  * The first item (`SUNDAY`) = `0`.
  * The next items increase by `1` (so `MONDAY` = `1`, `TUESDAY` = `2`, etc.).

---

## Declaring Variables of an Enum Type

You can use the enum as if it were a **data type**.

```csharp
DayOfWeek payrollDay;
payrollDay = DayOfWeek.TUESDAY;
```

* **Step 1:** `DayOfWeek` is treated as the type.
* **Step 2:** `payrollDay` is the variable you’re creating.
* **Step 3:** You assign one of the **constants from the enum** (`DayOfWeek.TUESDAY`).

### > Q1: What’s going on here?

Yes, exactly: the enum (`DayOfWeek`) is acting like a **custom data type**.
You’re pulling one of its constants (`TUESDAY`) and storing it in the variable `payrollDay`.

This means:

* `payrollDay` can only store **valid values from the enum**.
* It’s not just any integer—it’s specifically tied to the set of `DayOfWeek` values.

---

## Why Enumerations Make Code Type-Safe

* Without enums, you might represent days with **integers** or **strings**:

  ```csharp
  int day = 3;        // What does 3 mean? Hard to tell
  string day = "Tue"; // Easy to mistype or use invalid text
  ```

* With enums:

  ```csharp
  DayOfWeek day = DayOfWeek.TUESDAY; // Clear and restricted
  ```

* **Type-safe** means:

  * You cannot assign invalid values (`day = 99;` is illegal).
  * Only predefined values (`SUNDAY` through `SATURDAY`) are allowed.

### > Q2: How could values be misused without enums?

* Using `int` for days:

  ```csharp
  int day = 55; // Nonsense value, but compiler won’t stop you
  ```
* Using `string` for days:

  ```csharp
  string day = "Tuesdy"; // Typo, allowed but incorrect
  ```
* Enums prevent both problems by restricting values to the defined set.

---

## Assigning Custom Values

* You can override default values:

  ```csharp
  enum DayOfWeek
  {
      SUNDAY = 1, MONDAY, TUESDAY, WEDNESDAY,
      THURSDAY, FRIDAY, SATURDAY
  }
  ```

  * Here, `SUNDAY` = 1, so `MONDAY` = 2, `TUESDAY` = 3, etc.

* You can also assign specific values to each member:

  ```csharp
  enum SpeedLimit
  {
      SCHOOL_ZONE = 20,
      CITY_STREET = 30,
      HIGHWAY = 55
  }
  ```

---

## Converting Enums

* Convert enum → int:

  ```csharp
  int shipDay = (int)DayOfWeek.THURSDAY; // 4
  ```
* Convert int → enum:

  ```csharp
  DayOfWeek deliverDay = (DayOfWeek)5; // FRIDAY
  ```

---

## Advantages of Enums

1. **Type-safety**: prevents invalid assignments.
2. **Self-documenting**: `DayOfWeek.WEDNESDAY` is clearer than `3`.
3. **IntelliSense support**: in Visual Studio, lists valid enum members.
4. **Better than “magic numbers”**: makes code easier to read and maintain.

---

# Cheat Sheet — Enums

* **Define**: `enum DayOfWeek { SUNDAY, MONDAY, TUESDAY … }`
* **Default values**: start at 0, auto-increment by 1.
* **Custom values**: `enum DayOfWeek { SUNDAY = 1, MONDAY = 2 }`
* **Use as type**:

  ```csharp
  DayOfWeek today = DayOfWeek.TUESDAY;
  ```
* **Convert**:

  * `(int)DayOfWeek.THURSDAY` → 4
  * `(DayOfWeek)5` → FRIDAY
* **Benefits**:

  * Restricts valid values (type-safe).
  * More readable than numbers or strings.
  * Self-documenting and easy to maintain.

