--https://nekos.life/ Asayo Api by C4NX
Neko = {
GetImage=function(tag)
	local r = api.get("https://nekos.life/api/v2/img/" .. tag);
	if(r:isSuccess() == false) then return ""; end
	return jparse(r:readstring()).url;
end,
GetNeko=function() return Neko.GetImage("neko"); end,
GetPoke=function() return Neko.GetImage("poke"); end,
GetFoxGirl=function() return Neko.GetImage("fox_girl"); end,
GetBoobs=function() return Neko.GetImage("boobs"); end
}