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
	bot:onmessage(onmsg);
	logger:info("[ASAYO_LUA] Asayo Base Loading...");

	logger:info("[ASAYO_LUA] Loading Modules...");

	for key,value in pairs(files("AsayoModules\\","*.lua")) do
		import(value);
	end

	logger:info("[ASAYO_LUA] Asayo Base Loaded :D");
end

--Raw Message Handler
function onmsg(args,message_obj)
	
	local user = message_obj:user();

	if(message_obj:isSelf()) then return; end
	if(message_obj:isBot())then return; end

	if(args[1] == "!!report") then
		 logger:debug(Or(args[2],"No Value"));
		 ctx:respond("Report Send !");
	end

	if(isPrefix(args[1],"!!")) then
		local command_name = removePrefix(args[1],"!!");
		logger:debug("[ASAYO_LUA] Command : " .. command_name .. " from " .. tostring(user));
		command_handler:invoke(command_name,message_obj,user);

		for key,value in pairs(BasicRespondCommand) do if(command_name == key) then message_obj:respond(csformat(value,user:nick())) end end
	end
end

start();