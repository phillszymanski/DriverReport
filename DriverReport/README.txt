I made the following assumptions:

	- the input is provided in the form of a .txt file
	- drivers must be registered before being given Trip commands; Trip commands for unregistered drivers will be ignored 
	- commands that do not follow the stucture defined in the assignment will be ignored 
		+ ex: if the command is something other than "Trip" or "Driver"
	- extraneous information that follows a valid command can be safely ignored and the command still processed
		+ ex: "Trip Dan 07:15 07:45 17.3 asdfasdf" is valid input, as the junk (asdfasdf) follows a valid command
	- if a file contains some valid commands and some invalid commands, the valid commands will be processed and the invalid commands will be ignored. Don't throw out a file due to one bad command.