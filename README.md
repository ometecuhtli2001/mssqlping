# mssqlping

## Synopsis
Ping a Microsoft SQL Server instance by connecting to it and getting version information.

## Motivation
My organization uses a new standard for servers which means they will no longer respond to ICMP echo requests (aka pings).  This makes it a little harder to check if a server is up and running.  At first, I used nmap to scan prot 1433 (the SQL Server port) but it was inconvenient.  I came up with this utility as a quick and easy check on SQL Server insance checks.

Check out the project wiki at https://github.com/ometecuhtli2001/mssqlping/wiki for more information.
