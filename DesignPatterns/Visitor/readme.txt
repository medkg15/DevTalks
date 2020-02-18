The visitor pattern decouples the logic to be performed on specific sub-classes from that object structure.  Essentially, it allows implementing per-type methods without placing those methods directly on the classes involved.  It avoids "smells" like type inspection.

It is useful when multiple different processes / algorithms operate on a class hierarchy.  Visitors can be added without any change to the actual class hierarchy.

It is not as useful if the class hierarchy is likely to change, since all visitors would need to account for new classes.

You can achieve a similar result in C# using method overloading and the dynamic keyword.