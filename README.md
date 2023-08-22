# ICT-VK-T-19-applications

Deze repository bevat applicaties die je nodig hebt voor de opdrachten van het vak Testen (ICT-VK-T-19).

Om je eigen versie van deze repository te krijgen klik je op de groene 'Clone' knop, of op de witte 'Fork' knop bovenaan.

> LET OP: zorg dat je fork een private (prive) repository is, en niet public (openbaar)!

## Debugging

_Heb je problemen met het runnen van de unit tests?_ 

Controleer dan of je de juiste versie van het test framework aanroept.
Voorbeeld: In _Stratego.csproj_ en _TestStratego.csproj_ kan je de versies in de volgende regels code vergelijken met de versie die op jouw computer is geïnstalleerd.

`<TargetFramework>netcoreapp3.1</TargetFramework>`

`<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.6.3" />`