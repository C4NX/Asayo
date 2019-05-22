# Asayo

Asayo is a beta c# discord bot who use **MoonSharp/Lua** to work

The bot is now not very optimized but I work on :D

## Simple Command Handler With ASAYO.lua 
```lua
local base = embed();
base:color("AB5C9B");

function exemple_cmd_handler(Command,ctx,user)
	
	if(Command == "avatar") then
		local avatar_url = user:avatar(1024);
		local n = embed(base);
		n:description("Your avatar in 1024 pixels");
		n:title("Avatar of " .. user:nick());
		n:image(avatar_url);
		ctx:respond("",n);
		return;--close command
	end
	if(Command == "hello") then
		ctx:respond("Hello " .. user:nick() .. ", How are you ?");
		return;
	end
	if(Command == "NX") then
		ctx:respond("BG ;D");
		return;
	end
end

command_handler:add(exemple_cmd_handler);

registerRespondCommand("hello",":loudspeaker: HELLO __**{0}**__");

```

## Simple Command Handler (Raw)

```lua

bot = instance();
logger = bot:logger();

command_handler = event();
BasicRespondCommand = {};

--Utils
function registerRespondCommand(command,msg)
	BasicRespondCommand[command] = msg;
end


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

# Invite

Invite : No official Bot Invite
