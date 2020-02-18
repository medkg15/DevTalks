Mediator is similar to Observer, but achieves further decoupling between publishers and subscribers.  The collaborating objects never "speak" directly to one another - rather, all messaging goes through a shared "mediator".

This can be useful when the collaborating objects can change over time - e.g. magazine publishers start and stop publishing specific magazines.  The mediator can abstract away the details of tracking the current list of publishers / subscribers from the objects on the "other end".

Further, the mediator can implement business logic that doesn't "belong" with either set of collaborating objects.

Mediator is essentially what a message bus is, just at the architectural level.  allows anyone to publish events, and anyone to subscribe.