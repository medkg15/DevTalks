The observer pattern allows a Publisher to notify Subscribers when something of interest happens.  C#'s Event feature is an implementation of the Observer pattern.

A more "pure" OOP observer pattern typically involves an IObservable and an IObserver.  The IObservers expose a method to be called when something happens.  The IObservable exposes a method to subscribe (and usually unsubscribe).

The observer pattern is great for decoupling "extra" steps from the core process.  For example, if I have an API controller or domain service that performs registrations for new members, I might use the observer pattern to decouple the "things" that happen as a result of a new registration.  These "extras" may or may not be part of the core logic flow - they can be sync or async.

This is very commonly used between code "ownership" boundaries.  For example, a framework might expose observables or events when interesting things happen in the framework.  For example, ASP.NET provided all sorts of lifecycle hooks in this manner - initialization, pre-request, etc.  It is also _very_ common in native GUI frameworks: onclick, etc.

The observer pattern is often found at the architectural level too.  Domain events, event sourcing, event queue, message bus, etc. are all related to the observer pattern, just a level up.  They all serve to decouple the "impacts" of something occurring from the thing that caused it to occur, allowing both to change more freely.