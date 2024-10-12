# ARCHITECTURE
## Cart
A Cart is a user's cart. Always! A standalone cart without a user doesn't make sense.
So a Cart always has a user but a User does not always possess a Cart! (a
[parent-child relationship](https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one#required-one-to-one))
