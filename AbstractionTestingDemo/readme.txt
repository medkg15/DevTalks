we're going to take a step back from last session's DDD/CQS/CRQS topics and talk a bit about some of the principles that lead to these approaches.  this will primarily focus on the OOP languages which we are using most heavily, and with which i'm most familiar.  it'd be great to dig into some alternatives (e.g. FP) in another session.  (Adam)

the main question i want to answer is where do things like DDD, CQS, etc. come from, and why do they matter?  we're trying to write code that works (and continues to work), is understandable (by others), and can be maintained over the long term (adapt to changes).  this session is primarily going to focus on the code level concepts (objects, classes, etc.), rather than architectural.  the patterns we talked about last time are not purely _code_ focused patterns - many have higher-level architectural goals too (CQRS being a good example).  however, i think you'll find that many of these principles apply at the architectural level too.

there are many definitions of "good" software, and there are dozens of terms that are meant to provide guidance on what that is.  (see the pyramid of OOP concepts).  although these all tell a part of the story, it usually isn't simple to apply even a subset of these, and they can conflict with one another sometimes.  (do we want to quickly go through these?)

in my opinion, "good" software is understandable, as intuitive and simple as possible, and that i have confidence in it working properly.  although tons of considerations go into this, IMO, the heart is two things: abstraction and testability - we'll focus this talk around those.

OOP is focused on "abstraction".  abstraction is very common in software, and also in the real world.  we don't spend a lot of time thinking about x86, despite all (most) of our code eventually running as x86 instructions in the end.  we don't write our own compilers.  we don't implement basic data structures (array list, hashtable, etc.)  the real world is the same way - we go to the store for a box of nails, but (mostly) don't have to concern ourselves with the details of how those nails were made, where the materials came from, how they got to the store, etc.  instead, we simply know that we can exchange money for the nails, and that we can hammer the nails into something to hold it together.  that's the "interface" with the user - the way things can interact.  abstraction allows us to simplify our thinking and focus our efforts on solving the real problem in front of us.

OOP languages achieve abstraction via a number of features / tools, but IMO the most critical of these is encapsulation.  objects represent the combination of data and behavior, and can control access to both.  this allows objects to define their "public interface / contract" - declare the set of services they offer to others, while _not_ exposing the details of how they achieve those services.  the access control prevents other code from mucking about with the internals of that object.  this limits the object's use to its public contract - which can be clearly controlled by the developer of that object.  basically, it allows us to focus on one thing, and limit the degree of unexpected things happening.

Let's look at a StreetLight example (right click the Class in program.cs, use object explorer).  From the outside, the only things that can be done with this streetlight are to set its yellow/green intervals (via ctor args), check the current siganl for a given direction, and simulate the advance of time.
The streetlight's internal logic concerning which directions are currently red/yellow/green, the amount of time remaining, etc. are all hidden.  no other code components can mess around with these.
This helps reduce unexpected things happening to the code - the developer of the streetlight only has to deal with the known problem-space.  they can make assumptions about the state of their private variables - others cannot change them on us.

In constrast, let's say all of these were public.  If someone was given a new requirement to handle emergency vehicles, they might just start poking at our isYellow field, changing the status dictionary, etc.  This leads to breaking assumptions made elsewhere in the code, and increases complexity and coupling.  Instead, the developer (in this case, since we kept this initial implementation very basic), would likely be lead to introducing new methods, or perhaps injecting a dependency responsible for handling the different scenarios (e.g. IStreetlightStrategy).  (We'll talk about Open/Close principle later)

----------------

Let's talk more about the "public contract" offered by a code component.  For example, we might have an AddressParser which can accept a string address, and outputs the address components: street number, street name, town, etc. as separate values.  How exactly it does this isn't necessarily important to the client (caller) code.  Just the fact that we pass an address string in, and get out the address components.

Example: AddressParser / Address / Program.cs (exclude Encapsulation/Program.cs and include AddressParser/Program.cs)

Given the public contract, the developer responsible for implementing AddressParser has a (relatively) clear understanding of what's expected of them.  Further, the developer(s) who need an address parser to implement their other code can safely rely on the AddressParser's public contract without concerning themselves with the details of how it does it.  Just like the guy buying the nails probably doesn't need to know where the iron ore came from, or the heating process for making the steel.

Since c# offers tools to help define contracts - namely, interfaces, let's introduce IAddressParser.  You'll see this doesn't result in any change so far - we'll talk about that later.

This works just fine, but let's take a moment to talk about testing, and then we'll revisit this example.

-------------------

testability - we want confidence that what we've made actually works, and continues to work.  we might check this by clicking through a web page manually.  although manual testing can prove this once, as soon as you start changing things, you start losing confidence in the original thing still working, and you have to test it again.  you need to remember what needs to be tested, and how to test it, and actually do it (manually) again.  eventually, manual testing becauses too time intensive.

automating tests can help.  by writing code that tests other code, we can more quickly run tests in the future to verify nothing has broken.

there a variety of tests that can be done:
"unit testing", "integration testing", "end to end/UI testing".  usually a balance is needed - one type of testing isn't going to meet all needs.

A pyramid is often recommended - lots of unit tests, then some integration tests to verify the different components work together (but not test their deep details), and finally, a couple end-to-end / browser tests to verify the system as a whole works, and the UI works.

testing can also help "explore" the problem and help design the solution.  you often end up encountering scenarios you hadn't originally planned for (and neither had those writing the requirements).  this helps improve the quality of the software.  in the address parser - did we deal with PO boxes correctly?  what about abbreviations, st, str, rd, etc.?  tests can help us think about the problem and recognize these cases

let's look at some quick tests for the address parser.

AddressParserTests

TDD - test driven development - write tests first, then implement only the code necessary to make the test pass (red, green, refactor).  this can be rather extreme IMO

IMO, its more important that there _are_ tests than when they are written.  "any software without tests is legacy software - even if it was written today"

-------------------

now, there are a few lurking problems in the code written earlier.

SOLID

Single Responsibility Principle - a class should do one thing, and should only have one reason to change - high cohesion, low coupling.  IMO, these examples are pretty good, but its common to have too much going on in one class.  MVC controllers often get this way.  They might be executing validation logic (when its not trivial - like required/not blank/etc. - think email == email validation, etc.).  Then they might save some information to the data base.  Maybe they do some caching.  Maybe they're applying business logic to check if the request is valid.  Controllers can easily become hundreds of lines as these concepts get more complex.  SRP helps us to keep classes small and focused.

Open / Close Principle - open for extension, closed for modification.  effectively, you shouldn't have to change the implementation of an existing object to alter the overall behavior.  often, it is best to implement a new class that has the same public contract - the same c# interface, and substitute it for the original implementation.  the callers don't have to change - they're still depending on the same interface.  the only place in your program that has to change is where that interface gets associated to a real object instance.

LSP - Liskov Subsitution Principle - it should be possible to substitute the subclass for the superclass without breaking things.  a subclass must satisfy the contract of the superclass.   the decorator pattern is a perfect example of why this matters.  

I - interface segregation principle - an interface should not expose methods on which a client does not depend.  this makes code less flexible because future implementors of the interface _must_ be able to satisfy all methods, even if they cannot.  repository classes are a great example of violating this.  if something only requires "read" capability, then all of the write methods violate this principle.  CQRS which we talked about last week is a way of addressing this.

D - dependency inversion principle - "don't call us, we'll call you".  essentially, this means instead of _creating_ your dependencies (e.g. with 'new' keyword), ask for them.  there are various ways to accomplish this, but IMO, the cleanest is via ctor injection.  ask for your object's dependencies via its ctor.  therefore, the object cannot exist if the dependencies aren't satisfied.

---------------------

SOLID + testing

let's introduce a "problem" by implementing IAddressParser with a third party service - eg an HTTP API to Google Maps.

this will show us that abstractions are "leaky" - you can't hide all of the details behind an abstraction.  performance is one of the most common leaks.  in this case, what are our caller's performance expectations?  the interface tells us nothing, and that's something the developers as a whole need to manage.  

the real world is the same.  we can mostly ignore the details of how the nails got to the store, but we might start caring if we get to the store and there are no nails.  maybe the truck was late because of some traffic.  maybe the steel plant underestimated the demand for nails.  these are leaking details that _do_ start to matter to us.

-------------------

long story short, SOLID code is usually more testable.  it is rare that a code component has only a single client - usually we have at least the "real" client, and the tests.

- move IAddressParser to ctor of LetterPrinter

that said, it is easy to go overboard here.  it is also easy to introduce the wrong abstractions which just end up introducing more complexity.  don't be over-eager to find a place to fit a design pattern.  learn to recognize the places where they might be useful.

--------------------

in sum, my experience has been that seeking to make code testable also leads towards many of the other "best practices", including appropriate abstraction.  it forces the developer to think about questions like "does this logic i'm testing belong here?"  this can help to identify the appropriate abstractions, and therefore, public contracts.  it causes a shift in thinking to "how might someone else use this component?  does that make sense?"  even small shifts from "i'm going to open the source code of this class to see what it does" to "i'm going to look at the code's public contract through object explorer" can help ensure code is more understandable and properly factored.

at first, the code might look far more "complex".  you might have ten classes for something that used to be one.  however, i'd argue that when each component has its own, well-defined purpose and boundaries, things are actually far simplier.  one huge class is nearly impossible test, and chunks of it often just get copied elsewhere.  with proper abstraction /modularity, it is much easier to limit that type of issue.

that said, it is certainly possible to overboard here - more "stuff" is not necessarily better.  i have struggled a great deal with introducing _bad_ (or too idealized) abstractions.  i have come to realize that the _wrong_ abstraction is worse than _no_ abstraction.  if you don't have a clear sense of how something might be used, it is often better to hold off until you do.  all projects involve complexity, else there would be nothing to do.  keeping the required complexity understandable, while minimizing accidential complexity, is what leads to more successful projects.