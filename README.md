# Asayo

Asayo is a beta c# discord bot who use **MoonSharp/Lua** and **DSharpPlus** to work

The bot is now not very optimized but I work on :D

#### Docs Link : [Page](https://github.com/C4NX/Asayo/blob/master/Docs/info.md)

#### Source: [Source](https://github.com/C4NX/Asayo/tree/master/Source)

#### Release: [Release](https://github.com/C4NX/Asayo/tree/master/Source)

![THUMB](https://github.com/C4NX/Asayo/blob/master/thumb.PNG "Screenshot")

## Simple Command
```lua
--uncompact
function Hello(ctx)
 ctx:respond("Hello :smile:");
end

commands.add("hello",Hello);


--compact
 commands.add("hello",function(ctx) ctx:respond("Hello :smile:"); end);
```

## Simple Command Handler (Raw)

```lua

bot = instance();
logger = bot:logger();

--Start Function
function start() 
	bot:onmessage(onmsg);--register onmsg as MessageHandler
	logger:info("My Lua Script Started");
end

--Raw Message Handler
function onmsg(args,message_obj)
	local user = message_obj:user();
  
	if(message_obj:isSelf()) then return; end
	if(message_obj:isBot())then return; end
  
	if(isPrefix(args[1],"!!")) then
		local command_name = removePrefix(args[1],"!!");
    		if(command_name == "test") then message_obj:respond("Test Respond"); end
	end
end

start();

```
# ToDo

Order | Name | Percent
--- | --- | ---
*1* | **Optimisation/Api Developpement** | **~10%**
*2* | **Guild/Channel/Member Management** | **0%**
*3* | **Configuration Management** | **~5%**
*4* | **Profil/User Management** | **~5%**

# Invite

Invite : No official Bot Invite
