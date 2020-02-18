The builder pattern allows an object's attributes to be defined prior to actually creating the instance of the object.
This can be helpful for creating objects with a complex creation process, or for specifying common defaults that can be overriden.
It can also be very helpful for configuring an immutable object without the demand to specify everything at once.

The framework uses these in a few places, e.g. UriBuilder.

The builder has properties/methods representing the initialization data for the final object.  As few or as many of these can be altered as desired.  Finally, the builder can produce the "real" object once all initialization is done.

I've found this very helpful for organizing sensible defaults while still providing the option to fully customize an object.  We'll look at an example where this is used in a unit test, but this can be helpful in 'real' code too.

This can be especially useful for exposing a library facade where its not ideal to require full DI configuration on the client's behalf.