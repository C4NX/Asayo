bot = instance();
logger = bot:logger();

AsayoLuaVersion = "Asayo.Lua 1.1 for ASAYO BETA 1.02";

UpdateLink = "https://www.github.com/C4NX/Asayo/lom.lua";

--Utils

function ImportFunction(value) return import(value); end

function LoadModules()
	for key,value in pairs(files("Modules\\","*.lua")) do
		import(value);
	end
end

--EndUtils

function AsayoLua()
	logger:info("[ASAYO.LUA] " .. AsayoLuaVersion)
	logger:info("[ASAYO.LUA] LOADING...");
	logger:warn("[ASAYO.LUA] Report Crash in https://github.com/C4NX/Asayo/");

	LoadModules();

	commands.add("hello",function(ctx) ctx:respond("Hello man :D");  end);
end

function Update()
	logger:info("[ASAYO.LUA] Updating...")
	local r = api.get(UpdateLink);
	if(r:isSuccess() == false) then return; end
	r:readstring()
end

try(AsayoLua);