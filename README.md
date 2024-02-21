# North Star
# Architectural Principles of clean architechture
It's the rules and guidelines that drive a specific software architecture such as:
* Maintainability
* Testability
* Loose coupling

# Guiding Design Principles
* Separation of concerns (SoC) 
    * is a fundamental design principle in computer science. It involves breaking down a computer program into distinct sections, each addressing a separate concern or set of information that affects the code.
* Encapsulation
    * Encapsulation involves confining all relevant activities and data within an object, akin to enclosing something in a capsule. It shields the data and code from external intervention. Encapsulation prevents external code from being concerned with the internal workings of an object. It allows developers to present a consistent interface that remains independent of the object’s internal implementation
* Dependency Inversion (DIP)
    * High-level modules (those providing complex logic) should not directly depend on low-level modules (which offer utility features). Instead, both high-level and low-level modules should depend on abstractions. Furthermore, abstractions should not rely on implementation details; it’s the other way around—details should depend on abstractions. We want to depend on abstactions at compile time and implementations at runtime.
* Explicit Dependencies
    * The compoenents should be honest about their dependencies that they require to function properly. 
* Single Responsability
    * The componenents should have only one responsability only and the should have on reason to change. Promotes granular design of your components and it and also improves testability
* DRY
    * Focus on reducing duplication in code by encapsulating repetitive behaviour.
* Persistence Ignorance
    * Persistence Ignorance (PI) refers to types (usually classes) that need to be persisted (stored in a database or other data store), but their code remains unaffected by the choice of persistence technology.
These types are sometimes called Plain Old CLR Objects (POCOs) because they don’t need to inherit from a specific base class or implement any particular interface
* Bounded Contexts
    * In the realm of Domain-Driven Design (DDD), a Bounded Context is a pivotal pattern. It serves as a linguistic boundary, where terms and sentences can hold different meanings based on the specific context in which they are used. This linguistic delimitation aligns with the idea of ubiquitous language, which plays a crucial role in DDD.# northstar