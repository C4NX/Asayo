# Asayo 1.02 Doc
##### doc is not finiched

## Main Module : 

instance();  = Get Instance of Asayo Bot
```lua
 local mybot = instance();
```

logger(); = Get the Global Logger of Asayo
```lua
 local mylogger = logger();
```
try(LuaFunction,[args...]); = Try Execute a LuaFunction
```lua
 function test(args) FunctionNotExit(args); end
 try(test,"Go make some Top 1");
```

Or(value,Default); = return default value if value is Nil

event(); = Create a new LuaEventHandler Object
```lua
  local myevent = event();
```
import(path); = Import a lua file in the bot (“same to dofile()”)
```lua
  import("myluafile.lua");
```

isPrefix(str,prefix) = Test if str start with prefix
```lua
  if(isPrefix("!!help","!!")) then
  	--insert your code here
  end
```

removePrefix(str,prefix) = remove the start prefix of str
```lua
  local mystr = "!!help";
  if(isPrefix(mystr,"!!")) then
  	local command = removePrefix(mystr,"!!");--remove "!!" at start
	--insert your code here
  end
```
csformat(str,[args…]) = Format string with CSharp Formater ({0},{1} ect...)
```lua
  local str = csformat("my {0} string","cool");
```

files(dir,patern) = Get all File With Patern
```lua
  for key,value in pairs(files("MyDir\\","*.lua")) do
	import(value);--import for exemple
  end
```

embed([embed]); = create a new embed
```lua
  local myembed = embed();
  myembed:color("AB5C9B");
  local new_embed1 = embed(myembed);
  local new_embed2 = embed(myembed);
  new_embed1:description("I am fine ;D");
  new_embed2:description("Me too ;D");
```

stopwatch() = Create a stopwatch object

guildData_exset(guildid,name,value) = Create a guilddata if name not exist

guildData_set(guildid,name,value) = Set a value

guildData_get(guildid,name) = Get a value


## Api Module :

 api.get(url) = Request GET return <HttpResultObject>

## Command Module : 

 commands.add(name,LuaFunction) = Add command
 commands.remove(name) = Remove a command
 commands.disable() = Disable Commands
 commands.enable() = Enable Commands

# Objects : 

## ==============LuaEventHandler=============

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

## ==============AsayoBotObject==============

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
## ============DiscordUserObject============

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

## ============MessageArgsObject=============

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
 <MessageArgsObject>:respond("I am fine ;D");
```
:respond(msg,embed) = simple respond with string and embed
```lua
 local myembed = embed();
 myembed:color("AB5C9B");
 myembed:description("I am fine ;D");
 <MessageArgsObject>:respond("",myembed);
```

## ============HttpResultObject============

:isSuccess() = get if request success
```lua
 if(<HttpResultObject>:isSuccess()) then
      --insert your code here
 end
```
:readstring() = read string response
```lua
 local str = <HttpResultObject>:readstring();
```

## ============StopwatchObject============

:start() = Start the Stopwatch
:stop() = Stop the Stopwatch
:ms() = return ElapsedMilliseconds

## Events Args :

<AsayoBotObject>:onmessage => MessageArgsObject



