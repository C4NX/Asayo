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
```lua
<LuaEventHandler>:add(MyFunction);
```
:invoke([args…]) = invoke a LuaEventHandler
```lua
<LuaEventHandler>:inkoke("First string arg");
```
:remove(LuaFunction) = remove the LuaFunction of the Handler
```lua
<LuaEventHandler>:remove(MyFunction);
```

==============LoggerObject================

:info(str) = Log a str on Info Logger
```lua
<LoggerObject>:info("test");
```
:warn(str) = Log a str on Warning Logger
```lua
<LoggerObject>:warn("test");
```
:debug(str) = Log a str on Debug Logger
```lua
<LoggerObject>:debug("test");
```
:error(str) = Log a str on Error Logger
```lua
<LoggerObject>:error("test");
```
:fatal(str) = Log a str on Fatal Logger
```lua
<LoggerObject>:fatal("test");
```

==============AsayoBotObject==============

:onmessage(LuaFunction) = regiser a LuaFunction to receive message
```lua
  --Raw Message Handler
  function onmsg(args,message_obj)
	
	  local user = message_obj:user();

	  if(message_obj:isSelf()) then return; end
	  if(message_obj:isBot())then return; end
    
    --insert your code here
    
   end


  <AsayoBotObject>onmessage(onmsg);
```
:logger() = create a new logger
```lua
  local bot_logger = <AsayoBotObject>:logger();
  bot_logger:info("INFO : MY LOGGER IS HERE");
```
============DiscordUserObject============

:nick() = Get the username
```lua
  print(<DiscordUserObject>:nick());--Print the nickname
```
:discriminator() = Get the Discriminator
```lua
  print(<DiscordUserObject>:discriminator());--Print the discriminator (#0010 for exemple)
```
:avatar(size) = Get the avatar link , default size is 1024
```lua
  print(<DiscordUserObject>:avatar(1024));--Print the user avatar url as 1024x1024 pixels
```

============MessageArgsObject=============

:user() = Get a DiscordUserObject
```lua
  local user = <DiscordUserObject>:user();
  print(user:nick());--Print the user nickname
```
:channel_Id() = The the message channel id
```lua
  print(<DiscordUserObject>:channel_Id());
```
:message() = get the message string
```lua
  local str = <MessageArgsObject>:message();
  if(str == "test") then
      --do action here
  end
```
:respond(msg) = simple respond with string
```lua

```




## Events Args :

AsayoBotObject:onmessage => MessageArgsObject



