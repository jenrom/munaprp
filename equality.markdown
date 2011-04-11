#Rules for Equality

##Is it a reference type (class)
 * Does it implement IEquatable<T> for itself -use it
 * Does it override Equals - use it
 * Reference equality check

##Is it a value type (struct)
 * Does it override Equals - use it
 * Reflective field by field equality check
