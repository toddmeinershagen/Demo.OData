## Installation Instructions

* Had to set up empty web api project.
* Installed Microsoft.AspNet.OData
* Installed Swashbuckle.OData
* Edited the web.config - had to update the path attribute from "*." to "*.*"

<system.webServer>
	<handlers>
		<remove name="ExtensionlessUrlHandler-Integrated-4.0" />
		<remove name="OPTIONSVerbHandler" />
		<remove name="TRACEVerbHandler" />
		<add name="ExtensionlessUrlHandler-Integrated-4.0" path="*.*" verb="*" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
	</handlers>
</system.webServer>