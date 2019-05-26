##### *(Désoler si je fais des fautes d'orthographe)*

# Comment créer un bot discord *Asayo*

## Parti 1 : Télechargement et configuration

### Télecharger le bot

![img1](https://image.noelshack.com/fichiers/2019/21/7/1558874550-2019-05-26-14-32-26.png "")
![img2](https://image.noelshack.com/fichiers/2019/21/7/1558874689-2019-05-26-14-43-22.png "Ici la 1.02 car c'est la derniere version")

Puis Extaire le bot dans un dossier

### Configuration du bot

[Créer une application BOT (Discord developer))](https://mtxserv.com/forums/threads/creation-dun-bot-discord-creer-une-application-lui-ajouter-des-permissions.53558/) **Seulement la partie 2**

![img3](https://image.noelshack.com/fichiers/2019/21/7/1558875025-2019-05-26-14-48-35.png "Configuration du bot avec le token")

__**Asayo Fonctionne :smile:**__

## Parti 2 : Programation Du Bot (LUA)

### Créer un Module Asayo.Lua

*Verifier que le fichier Asayo.lua exist dans la racine du programe*

![img4](https://image.noelshack.com/fichiers/2019/21/7/1558875661-2019-05-26-14-59-36.png "Créer le dossier Modules")
![img5](https://image.noelshack.com/fichiers/2019/21/7/1558876011-2019-05-26-15-02-49.png "Créer un fichier .lua et Ouvrir le fichier")

__**Notre Premiere Commande**__

```lua
function TestExc(ctx)
	ctx:respond("Bonjour le jour :sunny:");
end

commands.add("test",TestExc);
```

**ctx** : *C'est le context de la commande contenent l'utilisateur qui la invoquer,la guild(le serveur),le salon,ect...*

**commands.add** : *Ajoute une commande au bot*

**ctx:respond** : *Permer de répondre a l'utilisateur* 

**TestExc** : *Est la fonction qui vas étre executer lorsque l'utilisateur tape "!!test"*

*"Test" est le nom de la commande*


__**Resultat : **__

![img6](https://image.noelshack.com/fichiers/2019/21/7/1558876892-2019-05-26-15-20-17.png "")
