# Asayo 1.0 Doc
##### doc is bot finiched

## Main Module : 

instance();  = Get Instance of Asayo Bot

logger(); = Get the Global Logger of Asayo

try(LuaFunction,[args...]); = Try Execute a LuaFunction

Or(value,Default); = return default value if value is Nil

event(); = Create a new LuaEventHandler Object

import(path); = Import a lua file in the bot (“same to dofile()”)

isPrefix(str,prefix) = Test if str start with prefix

removePrefix(str,prefix) = remove the start prefix of str

csformat(str,[args…]) = Format string with CSharp Formater

files(dir,patern) = Get all File With Patern



## Objects : 

==============LuaEventHandler=============

:add(LuaFunction) = add a function in LuaEventHandler

:invoke([args…]) = invoke a LuaEventHandler

:remove(LuaFunction) = remove the LuaFunction of the Handler


==============LoggerObject================

:info(str) = Log a str on Info Logger
:warn(str) = Log a str on Warning Logger
:debug(str) = Log a str on Debug Logger
:error(str) = Log a str on Error Logger
:fatal(str) = Log a str on Fatal Logger

==============AsayoBotObject==============

:onmessage(LuaFunction) = regiser a LuaFunction to receive message
:logger() = create a new logger
============DiscordUserObject============

:nick() = Get the username
:discriminator() = Get the Discriminator
:avatar(size) = Get the avatar link , default size is 1024

============MessageArgsObject=============

:user() = Get a DiscordUserObject
:channel_Id() = The the message channel id
:message() = get the message string
:respond(msg) = simple respond with string





## Events Args :

AsayoBotObject:onmessage => MessageArgsObject



