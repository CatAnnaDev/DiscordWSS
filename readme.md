# discord_msg_dumper

dump all discord msg in real time

# Get discord token from console

just copy paste this line below in discord console then copy paste your token<br>
`var req=webpackJsonp.push([[],{extra_id:(e,r,t)=>e.exports=t},[["extra_id"]]]);for(let e in req.c)if(req.c.hasOwnProperty(e)){let r=req.c[e].exports;if(r&&r.__esModule&&r.default)for(let e in r.default)"getToken"===e&&console.log(r.default.getToken())}`

<br>
dump opcode + opcode message + opcode code<br>
dump type + type message + type code<br>
dump username + discriminator<br>
rebuild url from message source<br>
resolve server name <br>
dump message data<br>
dump media link + name<br>
auto download media && print name + size in cyan // can cause issue dunno why<br>
mutli link support<br>
<br>
token = "" # authorization token in request header message (xhr type) copy past it into the Config.json<br>
<br>
slow down heartbeat interval to 41.25sec to prevent wss reconnect or crash <br>
update WSS to edit RPC<br>
<br>
Activity_type<br>
0	Game	Playing {name}<br>
1	Streaming	Streaming {details}<br>
2	Listening	Listening to {name}<br>
3	Watching	Watching {name}<br>
4	Custom	{emoji} {name}<br>
5	Competing	Competing in {name}<br>

![](https://cdn.discordapp.com/attachments/798446141200269313/951483319487459399/unknown.png)
