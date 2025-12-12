
### Rule of Thumb: Choosing `static`, `readonly`, or Plain Arrays

**Step 1.** Do you need each object to have its own separate copy of the array?

* ✅ Yes → **Plain array** (no keywords).

  * Example: Each `Student` object keeps its own `grades[]`.
* ❌ No → Go to Step 2.

**Step 2.** Should the array be shared by the whole class (same data for everyone)?

* ✅ Yes → Use **`static`**.

  * Example: A `CurrencyConverter` shares one `conversionRates[]` for all instances.
* ❌ No → stick with plain.

**Step 3.** Should the array reference be locked to the original row of lockers?

* ✅ Yes → Add **`readonly`**.

  * Example: A `shiftsPerDay[]` array initialized in the constructor should never be reassigned.
* ❌ No → keep it mutable.

**Step 4.** Should the array be both shared by the class **and** locked (constant-like)?

* ✅ Yes → **`static readonly`**.

  * Example: A `ValidItemCodes[]` table that never changes for the lifetime of the program.

---

🗝️ **Shortcut Summary**

* **Plain** → unique & flexible
* **Static** → shared copy
* **Readonly** → fixed reference
* **Static Readonly** → shared constant-like

