This endpoint uses the generic host. 

Start by exploring the class Endpoint.

== Endpoint ==
This is the main entry point for the host. 

== Frontend ==
A fake console UI implements IWantToRunAtStartup. This will automatically hook up the class when the bus is started and stopped. Implementors
of IWantToRunAtStartup are ready for dependency injection.

== Dependency ==
A registry or module like class which uses IWantCustomInitialization to hook up a custom dependency into the container.