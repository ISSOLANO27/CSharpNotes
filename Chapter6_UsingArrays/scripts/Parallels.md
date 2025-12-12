

### 1. Order matters in parallel arrays

If `validValues` and `prices` are parallel arrays, the order must line up.

* The first item number in `validValues` matches the first price in `prices`.
* The second item number matches the second price, and so on.

Example:

```csharp
int[] validValues = {101, 108, 201};
double[] prices   = {0.89, 1.23, 3.50};
```

* `validValues[1] = 108` → matches with `prices[1] = 1.23`.

---

### 2. One loop finds both

The same `for` loop that checks if the user’s item number matches a valid item can also grab the corresponding price, because the subscripts (indexes) are synchronized.

---

### 3. How the loop works

* Start: `x = 0` (the index).
* Boolean `isValidItem = false` (assume invalid until proven otherwise).
* While `x < validValues.Length`:

  * Check if `itemOrdered == validValues[x]`.
  * If a match is found:

    * Set `isValidItem = true`.
    * Assign `itemPrice = prices[x]`.

The loop then knows not only whether the item exists, but also what its price is.

---

### 4. Why this is powerful

You don’t need separate searches or messy `if` ladders. One loop does it all: validates the item and pulls the price.

---

### Simplified recap

Parallel arrays must stay in sync by order. The loop checks each `validValues` entry; if a match is found, the same index unlocks the correct price in the `prices` array, setting `isValidItem = true` and capturing `itemPrice`.

---

Do you want me to write a **full code demo** (like Figure 6-3 the book mentions) where the user types an item number and the program outputs either “Sorry – item not found” or the correct price?
