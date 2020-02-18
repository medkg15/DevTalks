A chain of responsibility consists of a series of classes in a specific order.  Each class implements the same interface, and a call is made to the first class in the chain.  At each step, the class can decide whether or not it should do anything, and then decide whether or not to continue execution with the next class in the chain.

This is extremely useful for representing a series of steps that must be carried out, or having a variety of different tasks.  I find it most helpful when you have a few different types of inputs that all go through roughly the same process, but whose details vary.

In this example, we have an insurance member who needs to be sent a welcome message.  This message will be slightly different based on attributes of that member - whether their plan has a premium cost, whether they're on a special needs plan, etc.

This works very well to decouple the individual steps of the process - they have no awareness of what other steps there are, or whether they executed.  Each just has to worry about its own scenario.

Chain of Responsibility is _not_ great when the steps involved need to coordinate a lot, or there is branching logic.  If multiple steps need to perform the same costly logic (DB lookup, etc.), this can be solved with caching or a context object.  However, this can get messy and increases coupling.