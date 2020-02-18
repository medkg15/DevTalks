design patterns are ways of organizing code to solve general types of problems.  they're conceptaul templates of solutions - each implementation will vary, but they'll generally consist of the same core concepts.

they should be used with a situation calls for it - not the other way around.  your application isn't made better because you've implemented 12 different design patterns.  rather, the application can be made more understandable and maintainable if it uses commonly-known and accepted design patterns to solve commonly-known and accepted problems.

it can be a struggle to identify what a 'design pattern' really is, especially with comparisons to real world examples.  this will sound like a silly example, but i was starring at the i-84 waiting for the train the other day.  the elevated section is built in sections of maybe 100-200 ft, with a small gap between them - expansion joints.  they make a very repetitous noise as you drive over them down the highway - at least when traffic is actually moving.  the more i thought about it - expansion joints are a pretty good analog of a real-life design pattern.  they're a common _template_ for a recurring problem: different materials can shift over time in different ways.  i had to implement the same pattern when installing a hardwood floor - without space around the perimeter of the room, the wood would expand and contract, causing damage the room over time.

i feel like this is a good analog to software design patterns because:

- its a concept - not a particular implementation.  an overpass expansion joint is made of completely different materials and operates under different conditions from a hardwood flooring gap, but they solve the same generalized problem.
- its a widely known and accepted way of solving the problem.  expansion joints are a reasonably cheap and effective way of dealing with small changes to a "static" material's size over time.  any engineer is going to have a decent understanding of what another engineer is talking about when they use the term expansion joint - even if one works on home designs and another on highway overpasses.
- although it might be possible to solve the problem in other ways, expansion joints have proven to be a cost-effective way of handling the situation, without inventing a new solution.  (perhaps a comparison might be spending $$$$ trying to invent a material that is flexible along its entire length, or is absolutely inflexible to the degree it won't ever move.)  in the end, expansion joints have just proven to be a simplier, cheaper solution.
- expansion joints are not a "end goal" of the system, but rather a means of meeting a challenge.  no one walks into a room and says "this would be way better with an expansion joint running down the middle".  they solve a problem, you don't implement them just to have them.  (they'd sure notice if the floor was buckling after the first winter/summer cycle.)

design patterns typically help produce more maintainable code by adhering to the SOLID principles.  Many of them focus on decoupling code, but in different ways depending on the situation.  they're mostly means of acheving "program to an interface, not an implementation".

Don't be over-eager to create a situation to use a design pattern.  use them where it makes sense, but don't try to implement one when its not necessary.  some of these examples i'll share probably fall into this territory, but they're trying to showcase the idea without adding a bunch of noise around it.  pretty much all of these patterns shouldn't come out until you're having a hard time managing the complexity or being able to test a set of classes.  

Although these patterns are specifically concerning OOP (classes, interfaces, etc.), you will see these overlapping with higher level architectural concepts.  the same ideas that apply to OOP often carry over at a higher level.
	
	-------------------------------------------
	
The observer pattern allows a Publisher to notify Subscribers when something of interest happens.  C#'s Event feature is an implementation of the Observer pattern.

A more "pure" OOP observer pattern typically involves an IObservable and an IObserver.  The IObservers expose a method to be called when something happens.  The IObservable exposes a method to subscribe (and usually unsubscribe).

The observer pattern is great for decoupling "extra" steps from the core process.  For example, if I have an API controller or domain service that performs registrations for new members, I might use the observer pattern to decouple the "things" that happen as a result of a new registration.  These "extras" may or may not be part of the core logic flow - they can be sync or async.

This is very commonly used between code "ownership" boundaries.  For example, a framework might expose observables or events when interesting things happen in the framework.  For example, ASP.NET provided all sorts of lifecycle hooks in this manner - initialization, pre-request, etc.  It is also _very_ common in native GUI frameworks: onclick, etc.

The observer pattern is often found at the architectural level too.  Domain events, event sourcing, event queue, message bus, etc. are all related to the observer pattern, just a level up.  They all serve to decouple the "impacts" of something occurring from the thing that caused it to occur, allowing both to change more freely.

------------------------------------

Mediator is similar to Observer, but achieves further decoupling between publishers and subscribers.  The collaborating objects never "speak" directly to one another - rather, all messaging goes through a shared "mediator".

This can be useful when the collaborating objects can change over time - e.g. magazine publishers start and stop publishing specific magazines.  The mediator can abstract away the details of tracking the current list of publishers / subscribers from the objects on the "other end".

Further, the mediator can implement business logic that doesn't "belong" with either set of collaborating objects.

Mediator is essentially what a message bus is, just at the architectural level.  allows anyone to publish events, and anyone to subscribe.
------------------------------------

The state pattern is helpful for representing a process flow.  It explicitly defines the possible "states" of the process, and the "transitions" between those states.

By explicitly defining states and transitions, it is usually much easier to separate the requirements / intent from the code implementation.  This allows developers and SMEs to better communicate about the intent of the software.

The state pattern can perform checks and operations at each transition, and inspect the current state of the process.  The observer pattern can also be used for external components to observe the process taking place.
------------------------------------

A chain of responsibility consists of a series of classes in a specific order.  Each class implements the same interface, and a call is made to the first class in the chain.  At each step, the class can decide whether or not it should do anything, and then decide whether or not to continue execution with the next class in the chain.

This is extremely useful for representing a series of steps that must be carried out, or having a variety of different tasks.  I find it most helpful when you have a few different types of inputs that all go through roughly the same process, but whose details vary.

In this example, we have an insurance member who needs to be sent a welcome message.  This message will be slightly different based on attributes of that member - whether their plan has a premium cost, whether they're on a special needs plan, etc.

This works very well to decouple the individual steps of the process - they have no awareness of what other steps there are, or whether they executed.  Each just has to worry about its own scenario.

Chain of Responsibility is _not_ great when the steps involved need to coordinate a lot, or there is branching logic.  If multiple steps need to perform the same costly logic (DB lookup, etc.), this can be solved with caching or a context object.  However, this can get messy and increases coupling.
------------------------------------
The builder pattern allows an object's attributes to be defined prior to actually creating the instance of the object.
This can be helpful for creating objects with a complex creation process, or for specifying common defaults that can be overriden.
It can also be very helpful for configuring an immutable object without the demand to specify everything at once.

The framework uses these in a few places, e.g. UriBuilder.

The builder has properties/methods representing the initialization data for the final object.  As few or as many of these can be altered as desired.  Finally, the builder can produce the "real" object once all initialization is done.

I've found this very helpful for organizing sensible defaults while still providing the option to fully customize an object.  We'll look at an example where this is used in a unit test, but this can be helpful in 'real' code too.

This can be especially useful for exposing a library facade where its not ideal to require full DI configuration on the client's behalf.

------------------------------------
The visitor pattern decouples the logic to be performed on specific sub-classes from that object structure.  Essentially, it allows implementing per-type methods without placing those methods directly on the classes involved.  It avoids "smells" like type inspection.

It is useful when multiple different processes / algorithms operate on a class hierarchy.  Visitors can be added without any change to the actual class hierarchy.

It is not as useful if the class hierarchy is likely to change, since all visitors would need to account for new classes.

You can achieve a similar result in C# using method overloading and the dynamic keyword.

------------------------------------

MVC is a pattern beyond the Microsoft ASP.NET implementation that we deal with a lot.  Its a common UI pattern (MVVM being very similar to it).

IMO, Microsoft has done a disservice with many of their MVC examples.  They push for M explicitly meaning DB entities, which is usually a pretty bad idea.

Rather, the model is better described as ViewModels, plus all of the application infrastructure under the hood.  The controller should not be doing logic - its there for basic decision making based on the type and validity of the user request.  It is not intended for controllers to manage the complexity of the app - that is for the (widely defined) Model.

Cross-cutting concerns like authorization, validation, etc. can be implemented with filters, model binders, etc.  again, this stuff doesn't belong in the controller.

------------------------------------

Factory isn't a "real" design pattern, just a class responsible for creating another.  This example shows how a factory can solve a problem "introduced" by DI: when you have some information that is known at build/deploy time (when you assign DI bindings), and other information that is only available at runtime.

Essentially, the static dependencies can be injected into a factory, and the factory has a method which takes the runtime parameters.

Any classes that depend upon what the factory creates depend on the factory instead.



-------------------------------------


- strategy pattern
	encapsulate an algorithm / behavior behind an interface.
	this is essentially just "using interfaces"
	but strategies can be switched out at runtime, or decisions can be made of which strategy to use.
	