import("API//nekoslife.lua");

function respondImg(ctx,imglink,title)
	local emb = embed();
	emb:title(title);
	emb:color("AB5C9B");
	emb:image(imglink);
	ctx.respond("",emb);
end

logger:info("COMMAND INIT...");

--===============NEKOLIFE===============

commands.add("neko",function(ctx) respondImg(ctx,Neko.GetNeko(),"NEKO | NEKO.LIFE"); end);
commands.add("foxgirl",function(ctx) respondImg(ctx,Neko.GetFoxGirl(),"FOXGIRL | NEKO.LIFE"); end);
commands.add("boobs",function(ctx) respondImg(ctx,Neko.GetBoobs(),"BOOBS | NEKO.LIFE"); end);

--===============ECONOMIE===============

commands.add("daily",function(ctx)
local guild_id = ctx:guildId();
local madd = math.random(0,50);

guildData_exset(guild_id,"money",0);
local value = guildData_get(guild_id,"money");
guildData_set(guild_id,"money",value + madd);

ctx:respond("Yes, You win " .. tostring(madd) .. " point for the server :medal: ");
end);

commands.add("points",function(ctx)


local guild_id = ctx:guildId();
local madd = math.random(0,50);

guildData_exset(guild_id,"money",0);
local value = guildData_get(guild_id,"money");

ctx:respond("You have " .. tostring(value) .. " point on the server :medal: ");
end);