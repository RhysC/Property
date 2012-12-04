<Query Kind="Expression">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Reactive Extensions SDK\v1.0.10621\Binaries\.NETFramework\v4.0\System.Reactive.dll</Reference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

/*
projects-
-Web
	reporting services
	auth
	audit
	logging

-Worker
	(start of workflows is off a queue - need transaction semantics to read and remove from queue)
	(calls straight into a domain service)
	
-Domain
	(Only visible by workers)
	Domain services
	Repositories
	DDD Entities and value object
	Domain events
	
-Core
	Queueing
	Repository wrappers

-DTOs
--Commands
--Request & response
	(tests to ensure all can be serialized to Json format 
		- could use refelction to 	interogated the properties 
									assign values
									store dto for comparison
									serialize to json
									deserialise and compare objects are equal