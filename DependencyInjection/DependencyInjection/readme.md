Dependency Injection is a technique for simplifying a system and improving maintainability, primarily through enabling code decoupling.

Decoupling allows code components to work independently, and change independently.  It limits the impact of changes in the system - rather than changing dozens of areas of the code, a change is limited to a single section.  This both simplifies the task of changing the code, and gives us greater confidence that we didn't break something unrelated.

There are a variety of other benefits to decoupling that we talked about in the last session - testability is improved, onboarding is simplified (since new developers only need to learn pieces of the system versus the whole), etc.

Dependency Injection is a subset of a concept known as Inversion of Control.  Inversion of Control refers to the general idea of allowing some other code component to ditate when another is invoked.  This allows each component to be less concerned with the minute details of how the other works (if it's aware of the other at all).  There are many ways to achieve this, and its a very common technique with frameworks.  Developers of desktop applications are typically not writing the main event loop themselves, but rather specifying the UI and binding event handlers.  The framework is responsible for disptaching click events, etc. to the appropriate event handler code.

Similarily, server-side web application developers are usually not writing code to accept TCP sockets, parse the raw HTTP request, and then determine how to respond.  Instead, the framework handles the initial details, and 






Dependency Injection is a means of reducing system complexity and improving maintainability, primarily though de-coupling modules from one another.  We talked about a few principles and reasons why code de-coupling is beneficial last time, but it all stands to simplify individual system "modules", and allow a system to more easily adapt to changes (by limiting the interdependencies of components).  We can achieve this by ensuring each component has a clear, cohesive purpose, and makes it clear to other components how it can be used.

Decoupling code is based on the principle "program to an interface, not an implementation".










Inversion of Control (IoC)

- this is the general concept of allowing something else to be in control, and bring a particular component in to do a task.  this has a variety of benefits, but primarily helps decouple the system components.
- this is extremely common with frameworks - UI frameworks, web frameworks, etc.  essentially, we aren't responsible for writing the 'main' method.  instead, something else is doing that, and invoking our code when appropriate.
- with a windows app, the event loop is written into the framework.  we bind to specific events that occur, and tell the framework which event handlers we want to fire.
    Button.OnClick => Console.Log("Clicked!");  
    this is a form of IOC - we aren't in control of when this code gets executed.
    Same with MVC controllers - the framework is responsible for accepting incoming HTTP requests, determining which MVC controller is the appropriate handler for them (via the route table), creating the controller, and invoking the appropriate action method.
- IOC's benefits can extend beyond these types of frameworks, however.  even without our applications (once we _do_ have control), it is often beneficial to carry on the concept.
- it allows some part of the program to be responsible for overall logic flow, and other parts to be responsible for carrying out specific tasks.  this helps these concepts be decoupled, and allows each to change independently, and be tested independently.




Config v Code Bindings

- Config files allow re-configuring dependencies without recompiling (or redeploying the app).  Theoretically this could even be done at run time.
- Code often allows for more expressive bindings.  Configs can become extremely logic when dependency logic starts to vary.  Ninject uses code-based bindings:
    kernel.Bind<IService>().To<Service>();

Dependency Injection v Service Locator

Dependency Injection enables loose coupling.  Aspects of the system can change without affecting other components.

Dependency Injection often helps make code testable.  It is easy to substitute a test dependency (which the test can control and inspect) rather than the 'real' dependency.  This is effective in unit testing because we want to test one specific component - not everything it usually works with.

Dependency Injection v IoC Container

Types of DI:
- ctor injection
- property injection
...

In my opinion, ctor injection is preferred.  Ctor injection makes it so something _cannot exist_ without its dependencies, and the dependencies are well documented (being ctor parameters).  Another downside can be that the code becomes more difficult to use - the caller must supply potentially several dependencies, each of which has dependencies.  We've seen that IOC containers can help solve this problem, but this can be a hard-sell for library code, and potenitally make testing more difficult.  The library can be solved with some type of facade entry-point, which constructs objects with default dependencies.  The testing concern is usually acceptable if the dependencies are well-factored, and the client isn't doing too much (SRP).  If a class is difficult to test because it has too many or difficult to construct dependencies, refactoring may be in order.

The downside is that you cannot change the dependencies after instantitation.  It can also be difficult if you can't gain control over third party code that constructs objects.  In these cases, property injection, or another technique, might be required / helpful.

Concerning Service Locator - my biggest concern is that it hides information.  The consumer of a class has no idea what it's dependencies might be.  This can make it harder to test (identify dependencies to mock).  Some Service Locators implementations were also very limiting - a basic static implementation is essentially a global variable.  This makes testing extremely difficult because you'd need to seriailize all tests, and modify the bindings between each one.

Composition Root
- Following SRP, there should be a difference between defining what needs to be done, and actually doing it.  We might have various classes responsible for actually doing the work, and a separate one for creating all of those classes, satisfying their dependencies, etc.  this is called the composition root of the application.

In many cases, the composition root actually instantiates the object graph for the program.  There are other services which might be created later too, but the logic for doing so is typically done in the composition root.

